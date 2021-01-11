using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientResources.API;
using Platform.Library.ClientResources.Impl;
using Platform.Library.ClientUnityIntegration.API;
using SharpCompress.Compressor;
using SharpCompress.Compressor.Deflate;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientNavigation.API;
using Tanks.Lobby.ClientUserProfile.API;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class NewsSystem : ECSSystem
	{
		public class NewsContainerNode : Node
		{
			public NewsContainerComponent newsContainer;
		}

		public class NewsItemNode : Node
		{
			public NewsItemComponent newsItem;
		}

		public class NewsItemWithUINode : NewsItemNode
		{
			public NewsItemUIComponent newsItemUI;

			public ButtonMappingComponent buttonMapping;
		}

		public class NewsItemWithPreviewDataNode : NewsItemWithUINode
		{
			public NewsItemImageDataComponent newsItemImageData;
		}

		public class NewsItemWithCetralIconNode : NewsItemWithUINode
		{
			public NewsItemCentralIconDataComponent newsItemCentralIconData;
		}

		public class NewsItemWithSaleNode : NewsItemWithUINode
		{
			public NewsItemSaleLabelComponent newsItemSaleLabel;
		}

		public class UserNode : Node
		{
			public SelfUserComponent selfUser;

			public UserUidComponent userUid;

			public UserRankComponent userRank;
		}

		private static string ID = "{ID}";

		private static string RANK = "{RANK}";

		private static string UID = "{UID}";

		private static string LOCALE = "{LOCALE}";

		private HashSet<long> seenNews = new HashSet<long>();

		private bool newsContainerSeen;

		private GameObject badge;

		private Dictionary<string, Texture> textureCache = new Dictionary<string, Texture>();

		[OnEventFire]
		[Conditional("DEBUG")]
		public void Debug(NodeAddedEvent e, NewsItemNode newsItem)
		{
			base.Log.InfoFormat("Add NewsItem: {0}", newsItem.newsItem.Data);
		}

		[OnEventFire]
		public void Register(NodeAddedEvent e, SingleNode<ClientLocaleComponent> locale)
		{
		}

		[OnEventFire]
		public void CreateUI(NodeAddedEvent e, [Combine] NewsItemNode newsItem, NewsContainerNode container)
		{
			CreateUIIfNeed(newsItem, container);
		}

		[OnEventFire]
		public void DeleteUI1(NodeRemoveEvent e, NewsItemNode newsItem, [JoinAll] NewsContainerNode container)
		{
			DeleteUIIfExists(newsItem, true);
		}

		[OnEventFire]
		public void DeleteUI2(NodeRemoveEvent e, NewsContainerNode container, [JoinAll][Combine] NewsItemNode newsItem)
		{
			DeleteUIIfExists(newsItem, false);
		}

		[OnEventFire]
		public void UpdateUI(NewsItemUpdatedEvent e, NewsItemNode newsItem, [JoinAll] NewsContainerNode container)
		{
			base.Log.InfoFormat("Update NewsItem: {0}", newsItem);
			DeleteUIIfExists(newsItem, true);
			CreateUIIfNeed(newsItem, container);
		}

		[OnEventFire]
		public void InitUI(NodeAddedEvent e, NewsItemWithUINode newsItem)
		{
			NewsItem data = newsItem.newsItem.Data;
			newsItem.newsItemUI.HeaderText = data.HeaderText;
			if (!string.IsNullOrEmpty(data.Tooltip))
			{
				newsItem.newsItemUI.Tooltip = data.Tooltip;
			}
			if (data.Date.Year > 2000)
			{
				newsItem.newsItemUI.DateText = data.Date.ToString("dd.MM.yyyy");
			}
			if (!string.IsNullOrEmpty(data.PreviewImageGuid))
			{
				base.Log.InfoFormat("Request load PreviewImage: {0}", data.PreviewImageGuid);
				ScheduleEvent(new AssetRequestEvent().Init<NewsItemImageDataComponent>(data.PreviewImageGuid), newsItem);
			}
			else if (!string.IsNullOrEmpty(data.PreviewImageUrl))
			{
				Texture value;
				if (textureCache.TryGetValue(data.PreviewImageUrl, out value))
				{
					base.Log.InfoFormat("Get PreviewImage from cache: {0}", data.PreviewImageUrl);
					SetImage(newsItem, value);
				}
				else
				{
					base.Log.InfoFormat("Load PreviewImage: {0}", data.PreviewImageUrl);
					if (!newsItem.Entity.HasComponent<UrlComponent>())
					{
						newsItem.Entity.AddComponent(new UrlComponent
						{
							Url = data.PreviewImageUrl,
							Caching = false,
							NoErrorEvent = true
						});
					}
				}
			}
			if (!string.IsNullOrEmpty(data.CentralIconGuid))
			{
				base.Log.InfoFormat("Request load CentralIcon: {0}", data.CentralIconGuid);
				ScheduleEvent(new AssetRequestEvent().Init<NewsItemCentralIconDataComponent>(data.CentralIconGuid), newsItem);
			}
		}

		[OnEventFire]
		public void AssetLoadComplete(NodeAddedEvent e, NewsItemWithPreviewDataNode newsItem)
		{
			base.Log.InfoFormat("AssetLoadComplete {0}", newsItem.newsItemImageData.Data);
			Texture2D rawImage = (Texture2D)newsItem.newsItemImageData.Data;
			newsItem.newsItemUI.ImageContainer.SetRawImage(rawImage);
			ConfigureImage(newsItem);
		}

		[OnEventFire]
		public void UrlLoadComplete(LoadCompleteEvent e, NewsItemWithUINode newsItem)
		{
			WWWLoader wWWLoader = (WWWLoader)newsItem.Entity.GetComponent<UrlLoaderComponent>().Loader;
			Texture texture = LoadTexture(wWWLoader);
			if (!IsErrorImage(texture))
			{
				base.Log.InfoFormat("PreviewImage loaded: {0}", wWWLoader.URL);
				textureCache[wWWLoader.URL] = texture;
				SetImage(newsItem, texture);
			}
			else
			{
				base.Log.ErrorFormat("Image decode failed: {0} bytesDownloaded={1} bytesLength={2}", wWWLoader.URL, wWWLoader.WWW.bytesDownloaded, wWWLoader.WWW.bytes.Length);
			}
		}

		[OnEventFire]
		public void SetSale(NodeAddedEvent e, NewsItemWithSaleNode newsItem)
		{
			base.Log.InfoFormat("SetSale: {0}", newsItem.newsItemSaleLabel.Text);
			newsItem.newsItemUI.SaleIconVisible = true;
			newsItem.newsItemUI.SaleIconText = newsItem.newsItemSaleLabel.Text;
		}

		[OnEventFire]
		public void CetralIconLoadComplete(NodeAddedEvent e, NewsItemWithCetralIconNode newsItem)
		{
			base.Log.InfoFormat("CetralIconLoadComplete {0}", newsItem.newsItemCentralIconData.Data);
			Texture2D centralIcon = (Texture2D)newsItem.newsItemCentralIconData.Data;
			newsItem.newsItemUI.SetCentralIcon(centralIcon);
		}

		[OnEventFire]
		public void OnClick(ButtonClickEvent e, NewsItemWithUINode newsItem, [JoinAll] UserNode user, [JoinByUser] SingleNode<ClientLocaleComponent> clientLocale)
		{
			CheckForTutorialEvent checkForTutorialEvent = new CheckForTutorialEvent();
			ScheduleEvent(checkForTutorialEvent, newsItem);
			if (checkForTutorialEvent.TutorialIsActive)
			{
				return;
			}
			base.Log.InfoFormat("OnClickNewsItem: {0}", newsItem);
			if (!string.IsNullOrEmpty(newsItem.newsItem.Data.InternalUrl))
			{
				ScheduleEvent(new NavigateLinkEvent
				{
					Link = newsItem.newsItem.Data.InternalUrl
				}, newsItem);
				return;
			}
			string externalUrl = newsItem.newsItem.Data.ExternalUrl;
			if (!string.IsNullOrEmpty(externalUrl))
			{
				externalUrl = externalUrl.Replace(ID, user.Entity.Id.ToString());
				externalUrl = externalUrl.Replace(RANK, user.userRank.Rank.ToString());
				externalUrl = externalUrl.Replace(UID, user.userUid.Uid);
				externalUrl = externalUrl.Replace(LOCALE, clientLocale.component.LocaleCode);
				Application.OpenURL(externalUrl);
			}
		}

		private void CreateUIIfNeed(NewsItemNode newsItem, NewsContainerNode container)
		{
			if (NeedHideNewsItem(newsItem))
			{
				base.Log.InfoFormat("Hide newsItem: {0}", newsItem);
				return;
			}
			Transform containerTransform = container.newsContainer.GetContainerTransform(newsItem.newsItem.Data.Layout);
			if (containerTransform == null)
			{
				base.Log.ErrorFormat("Container for NewsItem not found: {0}", newsItem.newsItem.Data);
				return;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(container.newsContainer.newsItemPrefab);
			gameObject.GetComponent<RectTransform>().SetParent(containerTransform, false);
			gameObject.GetComponent<EntityBehaviour>().BuildEntity(newsItem.Entity);
			seenNews.Add(newsItem.Entity.Id);
			SetAsFirstSiblingIfLessShown(newsItem, containerTransform, gameObject);
		}

		private void SetAsFirstSiblingIfLessShown(NewsItemNode newsItem, Transform containerTransform, GameObject itemObject)
		{
			if (containerTransform.childCount > 1)
			{
				EntityBehaviour component = containerTransform.GetChild(0).GetComponent<EntityBehaviour>();
				if (component != null && component.Entity.HasComponent<NewsItemComponent>())
				{
					NewsItemComponent component2 = component.Entity.GetComponent<NewsItemComponent>();
					if (newsItem.newsItem.ShowCount < component2.ShowCount)
					{
						base.Log.InfoFormat("Reorder item to first: {0}", newsItem);
						itemObject.GetComponent<RectTransform>().SetAsFirstSibling();
						newsItem.newsItem.ShowCount++;
						component2.ShowCount--;
					}
					else
					{
						newsItem.newsItem.ShowCount = component2.ShowCount;
					}
				}
			}
			else
			{
				newsItem.newsItem.ShowCount++;
			}
		}

		private bool NeedHideNewsItem(NewsItemNode newsItem)
		{
			NewsItemFilterEvent newsItemFilterEvent = new NewsItemFilterEvent();
			ScheduleEvent(newsItemFilterEvent, newsItem);
			return newsItemFilterEvent.Hide;
		}

		private void DeleteUIIfExists(NewsItemNode newsItem, bool immediate)
		{
			bool flag = newsItem.Entity.HasComponent<NewsItemUIComponent>();
			base.Log.InfoFormat("DeleteUIIfExists: {0} {1}", flag, newsItem);
			if (flag)
			{
				NewsItemUIComponent component = newsItem.Entity.GetComponent<NewsItemUIComponent>();
				component.gameObject.GetComponent<EntityBehaviour>().RemoveUnityComponentsFromEntity();
				if (immediate)
				{
					UnityEngine.Object.DestroyImmediate(component.gameObject);
				}
				else
				{
					UnityEngine.Object.Destroy(component.gameObject);
				}
			}
		}

		private void SetImage(NewsItemWithUINode newsItem, Texture texture)
		{
			newsItem.newsItemUI.ImageContainer.SetRawImage(texture);
			ConfigureImage(newsItem);
		}

		private void ConfigureImage(NewsItemWithUINode newsItem)
		{
			newsItem.newsItemUI.ImageContainer.FitInParent = newsItem.newsItem.Data.PreviewImageFitInParent;
		}

		private Texture2D LoadTexture(WWWLoader loader)
		{
			if (loader.WWW.responseHeaders.ContainsKey("Content-Encoding") && loader.WWW.responseHeaders["Content-Encoding"].Equals("gzip"))
			{
				base.Log.WarnFormat("LoadTexture image is gzipped: {0}", loader.URL);
				byte[] data = DecompressGzip(loader.Bytes, loader.WWW.bytesDownloaded * 2);
				Texture2D texture2D = new Texture2D(2, 2);
				return (!texture2D.LoadImage(data, true)) ? null : texture2D;
			}
			Texture2D texture2D2 = new Texture2D(2, 2, TextureFormat.ARGB32, false, false);
			loader.WWW.LoadImageIntoTexture(texture2D2);
			return texture2D2;
		}

		private static byte[] DecompressGzip(byte[] bytes, int bufferSize)
		{
			using (GZipStream gZipStream = new GZipStream(new MemoryStream(bytes), CompressionMode.Decompress))
			{
				byte[] array = new byte[bufferSize];
				int num = 0;
				int num2 = 0;
				while ((num2 = gZipStream.Read(array, num, array.Length - num)) > 0)
				{
					num += num2;
				}
				byte[] array2 = new byte[num];
				Array.Copy(array, array2, num);
				return array2;
			}
		}

		private static bool IsErrorImage(Texture tex)
		{
			return (bool)tex && tex.name == string.Empty && tex.height == 8 && tex.width == 8 && tex.filterMode == FilterMode.Bilinear && tex.anisoLevel == 1 && tex.wrapMode == TextureWrapMode.Repeat && tex.mipMapBias == 0f;
		}
	}
}
