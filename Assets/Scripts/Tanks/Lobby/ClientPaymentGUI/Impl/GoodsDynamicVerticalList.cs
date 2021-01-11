using System;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientControls.API.List;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class GoodsDynamicVerticalList : MonoBehaviour
	{
		[Serializable]
		public class ItemContent
		{
			public RectTransform Prefab;

			public int Height;
		}

		[Serializable]
		public class ContentAdapter
		{
			public ItemContent Content;

			public CommentedListDataProvider DataProvider;
		}

		[SerializeField]
		public enum GoodsType
		{
			XCrystals,
			SpecialOffer
		}

		[Serializable]
		public class GoodsContentAdapter : ContentAdapter
		{
			public GoodsType Type;
		}

		private const int commentSize = 200;

		[SerializeField]
		private GameObject commentPrefab;

		[SerializeField]
		private RectTransform item;

		[SerializeField]
		private List<GoodsContentAdapter> Adapters;

		[SerializeField]
		private int spacing;

		[SerializeField]
		private RectTransform viewport;

		private Dictionary<GoodsType, List<ListItem>> generatedItems = new Dictionary<GoodsType, List<ListItem>>();

		private List<Text> Comments = new List<Text>();

		private RectTransform rectTransform;

		private int visibleItemsCount;

		private float end
		{
			get
			{
				return rectTransform.anchoredPosition.y + viewport.rect.height;
			}
		}

		private float start
		{
			get
			{
				return rectTransform.anchoredPosition.y;
			}
		}

		private void Awake()
		{
			Adapters.Find((GoodsContentAdapter x) => x.Type == GoodsType.XCrystals).DataProvider = GetComponent<XCrystalsDataProvider>();
			Adapters.Find((GoodsContentAdapter x) => x.Type == GoodsType.SpecialOffer).DataProvider = GetComponent<SpecialOfferDataProvider>();
			rectTransform = GetComponent<RectTransform>();
		}

		private void UpdateBounds(ListDataProvider provider)
		{
			UpdateSize();
		}

		private void UpdateSize()
		{
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, viewport.rect.width - 1f);
			int height = 0;
			Adapters.ForEach(delegate(GoodsContentAdapter x)
			{
				height += (x.Content.Height + spacing) * x.DataProvider.Data.Count;
				height += x.DataProvider.CommentCount * 200;
			});
			height -= spacing;
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
			if ((float)height < rectTransform.anchoredPosition.y)
			{
				rectTransform.anchoredPosition = new Vector2(0f, Math.Max(0f, (float)height - viewport.rect.height));
			}
		}

		private void Update()
		{
			Layout();
		}

		private void OnEnable()
		{
			foreach (GoodsContentAdapter adapter in Adapters)
			{
				adapter.DataProvider.DataChanged += UpdateBounds;
			}
		}

		private void OnDisable()
		{
			foreach (GoodsContentAdapter adapter in Adapters)
			{
				adapter.DataProvider.DataChanged -= UpdateBounds;
			}
			rectTransform.anchoredPosition = new Vector2(0f, 0f);
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0f);
		}

		private void OnItemSelect(ListItem listItem)
		{
			foreach (GoodsContentAdapter adapter in Adapters)
			{
				Entity entity = adapter.DataProvider as Entity;
				if (entity != null && entity.HasComponent<SelectedListItemComponent>())
				{
					entity.RemoveComponent<SelectedListItemComponent>();
				}
			}
		}

		private void Layout()
		{
			int num = 0;
			float num2 = 0f;
			float num3 = 0f;
			int num4 = 0;
			int num5 = 0;
			foreach (GoodsContentAdapter adapter in Adapters)
			{
				if (!generatedItems.ContainsKey(adapter.Type))
				{
					generatedItems[adapter.Type] = new List<ListItem>();
				}
				num4 = 0;
				foreach (object datum in adapter.DataProvider.Data)
				{
					if (num3 - start > end)
					{
						break;
					}
					num2 = num3 + (float)adapter.Content.Height;
					if (num2 >= start)
					{
						if (num4 == generatedItems[adapter.Type].Count)
						{
							RectTransform rectTransform = UnityEngine.Object.Instantiate(item);
							ListItem component = rectTransform.GetComponent<ListItem>();
							component.SetContent(UnityEngine.Object.Instantiate(adapter.Content.Prefab));
							generatedItems[adapter.Type].Add(component);
							rectTransform.SetParent(this.rectTransform, false);
							Vector2 vector3 = (rectTransform.anchorMax = (rectTransform.anchorMin = new Vector2(0f, 1f)));
							rectTransform.pivot = new Vector2(0f, 1f);
						}
						else
						{
							generatedItems[adapter.Type][num4].gameObject.SetActive(true);
						}
						RectTransform component2 = generatedItems[adapter.Type][num4].GetComponent<RectTransform>();
						component2.anchoredPosition = new Vector2(0f, 0f - num3);
						component2.sizeDelta = new Vector2(viewport.rect.width, adapter.Content.Height);
						generatedItems[adapter.Type][num4].Data = datum;
						num4++;
						if (adapter.DataProvider.HasComment(datum))
						{
							if (num5 == Comments.Count)
							{
								GameObject gameObject = UnityEngine.Object.Instantiate(commentPrefab);
								Text component3 = gameObject.GetComponent<Text>();
								component3.transform.SetParent(this.rectTransform, false);
								Comments.Add(component3);
							}
							else
							{
								Comments[num5].gameObject.SetActive(true);
							}
							Comments[num5].text = adapter.DataProvider.GetComment(datum);
							RectTransform component4 = Comments[num5].GetComponent<RectTransform>();
							component4.anchoredPosition = new Vector2(0f, 0f - num2);
							component4.sizeDelta = new Vector2(viewport.rect.width, 200f);
							num5++;
							num2 += 200f;
						}
					}
					num3 = num2 + (float)spacing;
				}
				for (int i = num4; i < generatedItems[adapter.Type].Count; i++)
				{
					generatedItems[adapter.Type][i].gameObject.SetActive(false);
				}
				for (int j = num5; j < Comments.Count; j++)
				{
					Comments[j].gameObject.SetActive(false);
				}
			}
		}
	}
}
