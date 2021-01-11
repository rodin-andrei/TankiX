using System.Collections.Generic;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientFriends.Impl
{
	public class CantInviteFriendIntoSquadDialogComponent : ConfirmDialogComponent
	{
		[SerializeField]
		private TextMeshProUGUI message;

		[SerializeField]
		private LocalizedField messageLocalizedField;

		public void Show(string friendUid, List<Animator> animators = null)
		{
			message.text = string.Format(messageLocalizedField.Value, "<color=orange>" + friendUid + "</color>", "\n");
			Show(animators);
		}
	}
}
