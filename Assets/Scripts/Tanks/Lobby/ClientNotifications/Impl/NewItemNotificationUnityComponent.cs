using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientGraphics.Impl;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientNotifications.Impl
{
	public class NewItemNotificationUnityComponent : BehaviourComponent
	{
		public Slider upgradeSlider;

		public AnimatedValueComponent upgradeAnimator;

		public int count;

		[SerializeField]
		private TextMeshProUGUI headerElement;

		[SerializeField]
		private GameObject containerContent;

		[SerializeField]
		private TextMeshProUGUI itemNameElement;

		[SerializeField]
		private ImageSkin itemIconSkin;

		[SerializeField]
		private ImageSkin resourceIconSkin;

		[SerializeField]
		private GameObject itemContent;

		[SerializeField]
		private GameObject resourceContent;

		[SerializeField]
		private Image borderImg;

		[SerializeField]
		private TextMeshProUGUI rarityNameElement;

		[SerializeField]
		private GameObject rareEffect;

		[SerializeField]
		private GameObject epicEffect;

		[SerializeField]
		private GameObject legendaryEffect;

		[SerializeField]
		private LocalizedField commonText;

		[SerializeField]
		private LocalizedField rareText;

		[SerializeField]
		private LocalizedField epicText;

		[SerializeField]
		private LocalizedField legendaryText;

		[SerializeField]
		public Material[] cardMaterial;

		public OutlineObject outline;

		public ModuleCardView view;

		[SerializeField]
		private GameObject cardElement;

		public TextMeshProUGUI HeaderElement
		{
			get
			{
				return headerElement;
			}
		}

		public TextMeshProUGUI ItemNameElement
		{
			get
			{
				return itemNameElement;
			}
		}

		public bool ContainerContent
		{
			set
			{
				containerContent.SetActive(value);
			}
		}

		public void SetItemImage(string spriteUid)
		{
			itemIconSkin.SpriteUid = spriteUid;
			itemContent.SetActive(true);
		}

		public void SetItemIcon(string spriteUid)
		{
			resourceIconSkin.SpriteUid = spriteUid;
			resourceContent.SetActive(true);
		}

		public void SetCardElement(int tier)
		{
			GetComponentInParent<LayoutElement>().preferredWidth = 300f;
			cardElement.SetActive(true);
			containerContent.SetActive(false);
			Renderer component = cardElement.GetComponent<Renderer>();
			component.sharedMaterial = cardMaterial[tier - 1];
		}

		public void SetItemRarity(GarageItem item)
		{
			Color rarityColor = item.Rarity.GetRarityColor();
			itemNameElement.color = rarityColor;
			borderImg.color = rarityColor;
			rarityNameElement.color = new Color(rarityColor.r, rarityColor.g, rarityColor.b, 0.3f);
			if (item.IsVisualItem)
			{
				switch (item.Rarity)
				{
				case ItemRarityType.COMMON:
					rarityNameElement.text = string.Format("[{0}]", commonText.Value);
					break;
				case ItemRarityType.RARE:
					rarityNameElement.text = string.Format("[{0}]", rareText.Value);
					rareEffect.SetActive(true);
					break;
				case ItemRarityType.EPIC:
					rarityNameElement.text = string.Format("[{0}]", epicText.Value);
					epicEffect.SetActive(true);
					break;
				case ItemRarityType.LEGENDARY:
					rarityNameElement.text = string.Format("[{0}]", legendaryText.Value);
					legendaryEffect.SetActive(true);
					break;
				}
			}
			else
			{
				rarityNameElement.gameObject.SetActive(false);
			}
		}
	}
}
