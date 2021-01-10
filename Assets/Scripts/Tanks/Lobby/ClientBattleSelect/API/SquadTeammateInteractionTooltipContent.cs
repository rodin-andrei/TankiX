using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class SquadTeammateInteractionTooltipContent : InteractionTooltipContent
	{
		[SerializeField]
		private Button profileButton;
		[SerializeField]
		private Button leaveSquadButton;
		[SerializeField]
		private Button removeFromSquadButton;
		[SerializeField]
		private Button giveLeaderButton;
		[SerializeField]
		private Button addFriendButton;
		[SerializeField]
		private Button friendRequestSentButton;
		[SerializeField]
		private Button changeAvatarButton;
		public LocalizedField friendRequestResponce;
	}
}
