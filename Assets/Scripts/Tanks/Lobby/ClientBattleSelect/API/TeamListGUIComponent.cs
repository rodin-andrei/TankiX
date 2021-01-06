using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class TeamListGUIComponent : MonoBehaviour
	{
		[SerializeField]
		private GameObject joinButton;
		[SerializeField]
		private RectTransform joinButtonContainer;
		[SerializeField]
		private LobbyUserListItemComponent userListItemPrefab;
		[SerializeField]
		private LobbyUserListItemComponent customLobbyuserListItemPrefab;
		[SerializeField]
		private RectTransform scrollViewRect;
		[SerializeField]
		private TextMeshProUGUI membersCount;
	}
}
