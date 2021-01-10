using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModuleCardItemUIComponent : BehaviourComponent
	{
		public ModuleBehaviourType Type;
		public TankPartModuleType TankPart;
		[SerializeField]
		private ImageSkin icon;
		[SerializeField]
		private TextMeshProUGUI levelLabel;
		[SerializeField]
		private TextMeshProUGUI moduleName;
		[SerializeField]
		private GameObject selectBorder;
		[SerializeField]
		private Slider upgradeSlider;
		[SerializeField]
		private TextMeshProUGUI upgradeLabel;
		[SerializeField]
		private GameObject activeBorder;
		[SerializeField]
		private GameObject passiveBorder;
		[SerializeField]
		private LocalizedField activateAvailableLocalizedField;
		[SerializeField]
		private LocalizedField upgradeAvailableLocalizedField;
		[SerializeField]
		private TextMeshProUGUI upgradeAvailableText;
		[SerializeField]
		private float notMountableAlpha;
		public bool mountable;
	}
}
