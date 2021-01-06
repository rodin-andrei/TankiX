using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SelectedModuleView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI moduleName;
		[SerializeField]
		private GameObject property;
		[SerializeField]
		private Transform upgrade;
		[SerializeField]
		public GameObject ResearchButton;
		[SerializeField]
		public GameObject UpgradeCRYButton;
		[SerializeField]
		private GameObject UpgradeXCRYButton;
		[SerializeField]
		private GameObject BuyBlueprints;
		[SerializeField]
		private string damageIcon;
		[SerializeField]
		private string armorIcon;
		[SerializeField]
		private LocalizedField buyCRY;
		[SerializeField]
		private LocalizedField buyXCRY;
		[SerializeField]
		private LocalizedField bonusDamage;
		[SerializeField]
		private LocalizedField bonusArmor;
		[SerializeField]
		private LocalizedField localizeLVL;
		[SerializeField]
		private TextMeshProUGUI notEnoughText;
		[SerializeField]
		private LocalizedField notEnoughActivate;
		[SerializeField]
		private LocalizedField notEnoughUpgrade;
	}
}
