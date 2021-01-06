using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	internal class UserInteractionsTooltipContent : ECSBehaviour
	{
		public GameObject addToFriendsButton;
		public GameObject muteButton;
		public GameObject reportButton;
		public GameObject copyNameButton;
		public GameObject responceMessagePrefab;
		public float displayTime;
		public LocalizedField requrestSendLocalization;
		public LocalizedField requestFriendshipLocalization;
		public LocalizedField muteStateLocalization;
		public LocalizedField unmuteStateLocalization;
		public LocalizedField addToFriendsResponce;
		public LocalizedField activateBlockResponce;
		public LocalizedField deactivateBlockResponce;
		public LocalizedField reportResponce;
		public LocalizedField copied;
	}
}
