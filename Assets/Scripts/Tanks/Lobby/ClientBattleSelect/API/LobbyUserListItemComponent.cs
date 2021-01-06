using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class LobbyUserListItemComponent : BehaviourComponent
	{
		public bool selfUser;
		public GameObject userInfo;
		public GameObject userSearchingText;
		public GameObject userLabelPrefab;
		[SerializeField]
		private TextMeshProUGUI turretName;
		[SerializeField]
		private TextMeshProUGUI hullName;
		[SerializeField]
		private TextMeshProUGUI turretIcon;
		[SerializeField]
		private TextMeshProUGUI hullIcon;
		[SerializeField]
		private GameObject readyButton;
		[SerializeField]
		private TextMeshProUGUI statusLabel;
		[SerializeField]
		private LocalizedField notReadyText;
		[SerializeField]
		private LocalizedField readyText;
		[SerializeField]
		private LocalizedField inBattleText;
		[SerializeField]
		private Color notReadyColor;
		[SerializeField]
		private Color readyColor;
		[SerializeField]
		private GameObject lobbyMasterIcon;
		[SerializeField]
		private Button buttonScript;
	}
}
