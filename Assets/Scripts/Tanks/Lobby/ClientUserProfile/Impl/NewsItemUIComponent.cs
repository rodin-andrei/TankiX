using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class NewsItemUIComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Text headerText;

		[SerializeField]
		private Text dateText;

		[SerializeField]
		private NewsImageContainerComponent imageContainer;

		[SerializeField]
		private RectTransform centralIconTransform;

		[SerializeField]
		private RectTransform saleIconTransform;

		[SerializeField]
		private Text saleIconText;

		[SerializeField]
		private GameObject border;

		public bool noSwap;

		private string tooltip = string.Empty;

		public string HeaderText
		{
			get
			{
				return headerText.text;
			}
			set
			{
				headerText.text = value;
			}
		}

		public string DateText
		{
			get
			{
				return dateText.text;
			}
			set
			{
				dateText.text = value;
			}
		}

		public bool SaleIconVisible
		{
			get
			{
				return saleIconTransform.gameObject.activeSelf;
			}
			set
			{
				saleIconTransform.gameObject.SetActive(value);
			}
		}

		public string SaleIconText
		{
			get
			{
				return saleIconText.text;
			}
			set
			{
				saleIconText.text = value;
			}
		}

		public string Tooltip
		{
			get
			{
				return tooltip;
			}
			set
			{
				tooltip = value;
				TooltipShowBehaviour component = GetComponent<TooltipShowBehaviour>();
				if (component != null)
				{
					component.TipText = tooltip;
				}
			}
		}

		public NewsImageContainerComponent ImageContainer
		{
			get
			{
				return imageContainer;
			}
		}

		public GameObject Border
		{
			get
			{
				return border;
			}
		}

		public void SetCentralIcon(Texture2D texture)
		{
			RawImage rawImage = centralIconTransform.gameObject.AddComponent<RawImage>();
			rawImage.texture = texture;
			rawImage.SetNativeSize();
		}
	}
}
