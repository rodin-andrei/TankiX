using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModulesScreenUIComponent : BehaviourComponent
	{
		[SerializeField]
		private SlotUIComponent[] slots;
		[SerializeField]
		private CanvasGroup turretSlots;
		[SerializeField]
		private CanvasGroup hullSlots;
		[SerializeField]
		private ModuleCardItemUIComponent moduleCardItemUiComponentPrefab;
		[SerializeField]
		private ModuleCardsTierUI[] tiersUi;
		[SerializeField]
		private TextMeshProUGUI moduleName;
		[SerializeField]
		private TextMeshProUGUI moduleDesc;
		[SerializeField]
		private TextMeshProUGUI moduleFlavorText;
		[SerializeField]
		private ImageSkin moduleIcon;
		[SerializeField]
		private TextMeshProUGUI tankPartItemName;
		[SerializeField]
		private TextMeshProUGUI moduleTypeName;
		[SerializeField]
		private TextMeshProUGUI currentUpgradeLevel;
		[SerializeField]
		private TextMeshProUGUI nextUpgradeLevel;
		[SerializeField]
		private TextMeshProUGUI upgradeTitle;
		[SerializeField]
		private LocalizedField activeType;
		[SerializeField]
		private LocalizedField passiveType;
		[SerializeField]
		private LocalizedField upgradeLevel;
		[SerializeField]
		private LocalizedField hullHealth;
		[SerializeField]
		private LocalizedField turretDamage;
		[SerializeField]
		private ModulesPropertiesUIComponent modulesProperties;
		[SerializeField]
		private TankPartItemPropertiesUIComponent tankPartItemPropertiesUI;
		[SerializeField]
		private TutorialShowTriggerComponent upgradeModuleTrigger;
	}
}
