using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientUserProfile.API;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientFriends.Impl
{
	public class FriendsListUIComponent : ConfirmDialogComponent
	{
		[SerializeField]
		private TextMeshProUGUI emptyFriendsListLabel;
		[SerializeField]
		private LocalizedField noFriendsOnlineText;
		[SerializeField]
		private LocalizedField noFriendsText;
		[SerializeField]
		private LocalizedField noFriendsIncomingText;
		[SerializeField]
		private GameObject addAllButton;
		[SerializeField]
		private GameObject rejectAllButton;
		[SerializeField]
		private TMP_InputField searchingInput;
		[SerializeField]
		private float inputDelayInSec;
		public FriendsUITableView tableView;
		[SerializeField]
		private FriendsShowMode defaultShowMode;
		[SerializeField]
		private Button AllFriendsButton;
		[SerializeField]
		private Button IncomnigFriendsButton;
	}
}
