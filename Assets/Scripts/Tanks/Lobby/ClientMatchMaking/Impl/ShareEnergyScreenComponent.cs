using Platform.Library.ClientUnityIntegration.API;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class ShareEnergyScreenComponent : BehaviourComponent
	{
		[SerializeField]
		private Button startButton;
		[SerializeField]
		private Button exitButton;
		[SerializeField]
		private Button hideButton;
		[SerializeField]
		private TextMeshProUGUI readyPlayers;
		[SerializeField]
		private LocalizedField notAllPlayersReady;
		[SerializeField]
		private LocalizedField allPlayersReady;
		[SerializeField]
		private CircleProgressBar teleportPriceProgressBar;
	}
}
