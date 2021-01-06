using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModulesNotificationBadgeComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI text;
		[SerializeField]
		private LocalizedField newModuleAvailable;
		[SerializeField]
		private LocalizedField moduleUpgradeAvailable;
		public TankPartModuleType TankPart;
	}
}
