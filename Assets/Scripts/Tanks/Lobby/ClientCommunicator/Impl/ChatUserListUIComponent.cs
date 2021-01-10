using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientCommunicator.API;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientCommunicator.Impl
{
	public class ChatUserListUIComponent : ConfirmDialogComponent
	{
		[SerializeField]
		private TextMeshProUGUI emptyFriendsListLabel;
		[SerializeField]
		private LocalizedField noFriendsOnlineText;
		[SerializeField]
		private TMP_InputField searchingInput;
		[SerializeField]
		private float inputDelayInSec;
		[SerializeField]
		private ChatUserListUITableView tableView;
		[SerializeField]
		private ChatUserListShowMode defaultShowMode;
		[SerializeField]
		private Button PartipientsButton;
		[SerializeField]
		private Button FriendsButton;
	}
}
