using Platform.Library.ClientUnityIntegration.API;
using UnityEngine.UI;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class DailyBonusScreenComponent : BehaviourComponent
	{
		public DailyBonusMapView mapView;
		public DailyBonusTeleportView teleportView;
		public TeleportHeaderView teleportHeaderView;
		public Button takeBonusButton;
		public Button takeContainerButton;
		public Button takeDetailTarget;
		public CellsProgressBar cellsProgressBar;
		public LocalizedField noItemsFound;
		public LocalizedField itemsFound;
		public LocalizedField allItemsFound;
		public TextMeshProUGUI foundItemsLabel;
	}
}
