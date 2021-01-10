using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GarageItemsScreenComponent : MonoBehaviour
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
	}
}
