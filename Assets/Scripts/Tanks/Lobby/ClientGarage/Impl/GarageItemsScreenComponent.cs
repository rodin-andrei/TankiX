using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GarageItemsScreenComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject buyButton;

		[SerializeField]
		private GameObject xBuyButton;

		[SerializeField]
		private MountLabelComponent mountLabel;

		[SerializeField]
		private MountItemButtonComponent mountItemButton;

		[SerializeField]
		private ItemPropertiesButtonComponent itemPropertiesButton;

		[SerializeField]
		private UserRankRestrictionDescriptionGUIComponent userRankRestrictionDescription;

		[SerializeField]
		private UpgradeLevelRestrictionDescriptionGUIComponent upgradeLevelRestrictionDescription;

		[SerializeField]
		private Text onlyInContainerLabel;

		[SerializeField]
		private GoToContainersScreenButtonComponent containersButton;

		public GameObject BuyButton
		{
			get
			{
				return buyButton;
			}
		}

		public GameObject XBuyButton
		{
			get
			{
				return xBuyButton;
			}
		}

		public MountLabelComponent MountLabel
		{
			get
			{
				return mountLabel;
			}
		}

		public MountItemButtonComponent MountItemButton
		{
			get
			{
				return mountItemButton;
			}
		}

		public ItemPropertiesButtonComponent ItemPropertiesButton
		{
			get
			{
				return itemPropertiesButton;
			}
		}

		public UserRankRestrictionDescriptionGUIComponent UserRankRestrictionDescription
		{
			get
			{
				return userRankRestrictionDescription;
			}
		}

		public UpgradeLevelRestrictionDescriptionGUIComponent UpgradeLevelRestrictionDescription
		{
			get
			{
				return upgradeLevelRestrictionDescription;
			}
		}

		public bool OnlyInContainerUIVisibility
		{
			set
			{
				onlyInContainerLabel.gameObject.SetActive(value);
				containersButton.gameObject.SetActive(value);
			}
		}

		public bool OnlyInContainerLabelVisibility
		{
			set
			{
				onlyInContainerLabel.gameObject.SetActive(value);
			}
		}

		public bool InContainerButtonVisibility
		{
			set
			{
				containersButton.gameObject.SetActive(value);
			}
		}

		public string OnlyInContainerLabel
		{
			set
			{
				onlyInContainerLabel.text = value;
			}
		}
	}
}
