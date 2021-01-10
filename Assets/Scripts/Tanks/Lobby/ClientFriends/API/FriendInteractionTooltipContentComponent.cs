using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientFriends.API
{
	public class FriendInteractionTooltipContentComponent : InteractionTooltipContent
	{
		[SerializeField]
		private Button profileButton;
		[SerializeField]
		private Button chatButton;
		[SerializeField]
		private Button enterAsSpectatorButton;
		[SerializeField]
		private Button removeButton;
		[SerializeField]
		private Button inviteToSquadButton;
		[SerializeField]
		private Button requestToSquadButton;
		[SerializeField]
		private Button requestToSquadWasSentButton;
		[SerializeField]
		private Button squadIsFullButton;
		public LocalizedField inviteToSquadResponce;
		public LocalizedField requestToSquadResponce;
	}
}
