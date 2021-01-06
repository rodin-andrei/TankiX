using UnityEngine.EventSystems;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using Tanks.Lobby.ClientFriends.Impl;
using TMPro;

namespace Tanks.Lobby.ClientFriends.API
{
	public class InviteFriendsPopupComponent : UIBehaviour
	{
		[SerializeField]
		private UITableViewCell inviteToLobbyCell;
		[SerializeField]
		private UITableViewCell inviteToSquadCell;
		[SerializeField]
		private InviteMode currentInviteMode;
		[SerializeField]
		private InviteFriendsUIComponent inviteFriends;
		[SerializeField]
		private TextMeshProUGUI inviteHeader;
		[SerializeField]
		private LocalizedField inviteToLobbyLocalizationFiled;
		[SerializeField]
		private LocalizedField inviteToSquadLocalizationFiled;
	}
}
