using System.Collections.Generic;
using System.Linq;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientCommunicator.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.Impl;
using Tanks.Lobby.ClientUserProfile.API;
using TMPro;
using UnityEngine;
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

		private List<UserCellData> participants = new List<UserCellData>();

		private List<UserCellData> pending = new List<UserCellData>();

		private List<UserCellData> friends = new List<UserCellData>();

		private bool friendsLoaded;

		private bool participantsLoaded;

		private bool pendingLoaded;

		private bool inputChanged;

		private float lastChangeTime;

		private ChatUserListShowMode showMode;

		[SerializeField]
		private ChatUserListShowMode defaultShowMode;

		[SerializeField]
		private Button PartipientsButton;

		[SerializeField]
		private Button FriendsButton;

		[Inject]
		public static UnityTime UnityTime
		{
			get;
			set;
		}

		private bool loaded
		{
			get
			{
				return friendsLoaded && participantsLoaded && pendingLoaded;
			}
		}

		public ChatUserListShowMode ShowMode
		{
			get
			{
				return showMode;
			}
			set
			{
				showMode = value;
				List<UserCellData> list = new List<UserCellData>();
				switch (showMode)
				{
				case ChatUserListShowMode.Participants:
					PartipientsButton.GetComponent<Animator>().SetBool("activated", true);
					FriendsButton.GetComponent<Animator>().SetBool("activated", false);
					list.AddRange(participants);
					break;
				case ChatUserListShowMode.Invite:
					PartipientsButton.GetComponent<Animator>().SetBool("activated", false);
					FriendsButton.GetComponent<Animator>().SetBool("activated", true);
					list.AddRange(friends.Where((UserCellData x) => !participants.Exists((UserCellData p) => p.id == x.id) && !pending.Exists((UserCellData p) => p.id == x.id)));
					break;
				}
				UpdateTable(list);
			}
		}

		public void AddFriends(Dictionary<long, string> FriendsIdsAndNicknames)
		{
			foreach (long key in FriendsIdsAndNicknames.Keys)
			{
				UserCellData item = new UserCellData(key, FriendsIdsAndNicknames[key]);
				friends.Add(item);
			}
			friendsLoaded = true;
			ShowMode = showMode;
		}

		public void AddParticipants()
		{
		}

		public void AddFriend(Dictionary<long, string> FriendsIdsAndNicknames)
		{
			foreach (long key in FriendsIdsAndNicknames.Keys)
			{
				UserCellData item = new UserCellData(key, FriendsIdsAndNicknames[key]);
				friends.Add(item);
			}
			friendsLoaded = true;
			ShowMode = showMode;
		}

		public void RemoveFriend(long userId)
		{
			friends.RemoveAll((UserCellData x) => x.id == userId);
			ShowMode = showMode;
		}

		public void AddFriend(long userId, string userUid)
		{
			UserCellData item = new UserCellData(userId, userUid);
			friends.Add(item);
			ShowMode = showMode;
		}

		public void UpdateTable(List<UserCellData> items)
		{
			tableView.Items = items;
			tableView.FilterString = tableView.FilterString;
		}

		private void Update()
		{
			if (loaded)
			{
				CheckContentVisibility();
				InputUpdate();
			}
		}

		public void InputUpdate()
		{
			if (inputChanged && UnityTime.time - lastChangeTime > inputDelayInSec)
			{
				UpdateFilterString();
				inputChanged = false;
			}
		}

		private void OnSearchingInputValueChanged(string value)
		{
			inputChanged = true;
			lastChangeTime = UnityTime.time;
		}

		private void UpdateFilterString()
		{
			tableView.FilterString = searchingInput.text;
		}

		private void CheckContentVisibility()
		{
			if (tableView.Items.Count == 0)
			{
				string empty = string.Empty;
				empty = noFriendsOnlineText.Value;
				if (!emptyFriendsListLabel.gameObject.activeSelf || emptyFriendsListLabel.text != empty)
				{
					emptyFriendsListLabel.text = empty;
					emptyFriendsListLabel.gameObject.SetActive(true);
				}
			}
			else if (emptyFriendsListLabel.gameObject.activeSelf)
			{
				emptyFriendsListLabel.gameObject.SetActive(false);
			}
		}

		private void Awake()
		{
			if (PartipientsButton != null)
			{
				PartipientsButton.onClick.AddListener(ShowParticipants);
			}
			if (FriendsButton != null)
			{
				FriendsButton.onClick.AddListener(ShowFriends);
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			searchingInput.text = string.Empty;
			searchingInput.scrollSensitivity = 0f;
			searchingInput.Select();
			searchingInput.onValueChanged.AddListener(OnSearchingInputValueChanged);
			ShowMode = defaultShowMode;
		}

		private void OnDisable()
		{
			pending.Clear();
			participants.Clear();
			friends.Clear();
			friendsLoaded = false;
			searchingInput.onValueChanged.RemoveListener(OnSearchingInputValueChanged);
		}

		public int GetUserDataIndexById(long userId, List<UserCellData> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].id == userId)
				{
					return i;
				}
			}
			return -1;
		}

		public void ShowParticipants()
		{
			ShowMode = ChatUserListShowMode.Participants;
		}

		public void ShowFriends()
		{
			ShowMode = ChatUserListShowMode.Invite;
		}
	}
}
