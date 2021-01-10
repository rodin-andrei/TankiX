using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class PlayButtonComponent : EventMappingComponent
	{
		public GameObject cancelSearchButton;
		public GameObject goToLobbyButton;
		public GameObject exitLobbyButton;
		public MatchSearchingGUIComponent matchSearchingGui;
		[SerializeField]
		private LocalizedField playersInLobby;
		[SerializeField]
		private TextMeshProUGUI gameModeTitleLabel;
		[SerializeField]
		private TextMeshProUGUI playersInLobbyLabel;
	}
}
