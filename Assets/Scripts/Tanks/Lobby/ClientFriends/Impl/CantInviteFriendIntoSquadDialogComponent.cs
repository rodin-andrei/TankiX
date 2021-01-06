using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientFriends.Impl
{
	public class CantInviteFriendIntoSquadDialogComponent : ConfirmDialogComponent
	{
		[SerializeField]
		private TextMeshProUGUI message;
		[SerializeField]
		private LocalizedField messageLocalizedField;
	}
}
