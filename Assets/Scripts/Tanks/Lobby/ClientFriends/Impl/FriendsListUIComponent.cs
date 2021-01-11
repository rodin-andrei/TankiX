using System.Collections.Generic;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.Impl;
using Tanks.Lobby.ClientUserProfile.API;
using TMPro;
using UnityEngine;
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

		private List<UserCellData> incoming = new List<UserCellData>();

		private List<UserCellData> accepted = new List<UserCellData>();

		private List<UserCellData> outgoing = new List<UserCellData>();

		private bool loaded;

		private bool inputChanged;

		private float lastChangeTime;

		private FriendsShowMode showMode;

		[SerializeField]
		private FriendsShowMode defaultShowMode;

		[SerializeField]
		private Button AllFriendsButton;

		[SerializeField]
		private Button IncomnigFriendsButton;

		[Inject]
		public static UnityTime UnityTime
		{
			get;
			set;
		}

		public FriendsShowMode ShowMode
		{
			get
			{
				return showMode;
			}
			set
			{
				showMode = value;
				List<UserCellData> list = new List<UserCellData>();
				switch (ShowMode)
				{
				case FriendsShowMode.AcceptedAndOutgoing:
					AllFriendsButton.GetComponent<Animator>().SetBool("activated", true);
					IncomnigFriendsButton.GetComponent<Animator>().SetBool("activated", false);
					list.AddRange(accepted);
					list.AddRange(outgoing);
					break;
				case FriendsShowMode.Incoming:
					AllFriendsButton.GetComponent<Animator>().SetBool("activated", false);
					IncomnigFriendsButton.GetComponent<Animator>().SetBool("activated", true);
					list.AddRange(incoming);
					break;
				default:
					list.AddRange(accepted);
					break;
				}
				UpdateTable(list);
				ResetButtons();
			}
		}

		public void AddFriends(Dictionary<long, string> FriendsIdsAndNicknames, FriendType friendType)
		{
			foreach (long key in FriendsIdsAndNicknames.Keys)
			{
				AddItem(key, FriendsIdsAndNicknames[key], friendType);
			}
			loaded = true;
			ShowMode = showMode;
		}

		public void AddItem(long userId, string userUid, FriendType friendType)
		{
			UserCellData item = new UserCellData(userId, userUid);
			switch (friendType)
			{
			case FriendType.Incoming:
				incoming.Add(item);
				break;
			case FriendType.Outgoing:
				outgoing.Add(item);
				break;
			default:
				accepted.Add(item);
				break;
			}
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
				switch (ShowMode)
				{
				case FriendsShowMode.AcceptedAndOutgoing:
					empty = noFriendsText.Value;
					break;
				case FriendsShowMode.Incoming:
					empty = noFriendsIncomingText.Value;
					break;
				default:
					empty = noFriendsOnlineText.Value;
					break;
				}
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
			if (AllFriendsButton != null)
			{
				AllFriendsButton.onClick.AddListener(ShowAcceptedAndOutgoingFriends);
			}
			if (IncomnigFriendsButton != null)
			{
				IncomnigFriendsButton.onClick.AddListener(ShowIncomingFriends);
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			searchingInput.text = string.Empty;
			searchingInput.scrollSensitivity = 0f;
			searchingInput.onValueChanged.AddListener(OnSearchingInputValueChanged);
			ShowMode = defaultShowMode;
			Invoke("ActivateInputField", 0.5f);
		}

		private void ActivateInputField()
		{
			searchingInput.ActivateInputField();
		}

		private void OnDisable()
		{
			CancelInvoke();
			incoming.Clear();
			accepted.Clear();
			outgoing.Clear();
			loaded = false;
			searchingInput.onValueChanged.RemoveListener(OnSearchingInputValueChanged);
		}

		public void RemoveItem(long userId, bool toRight)
		{
			int userDataIndexById = GetUserDataIndexById(userId, incoming);
			if (userDataIndexById != -1)
			{
				incoming.RemoveAt(userDataIndexById);
			}
			else
			{
				userDataIndexById = GetUserDataIndexById(userId, accepted);
				if (userDataIndexById != -1)
				{
					accepted.RemoveAt(userDataIndexById);
				}
				else
				{
					userDataIndexById = GetUserDataIndexById(userId, outgoing);
					if (userDataIndexById != -1)
					{
						outgoing.RemoveAt(userDataIndexById);
					}
				}
			}
			tableView.RemoveUser(userId, toRight);
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

		public void ShowAcceptedAndOutgoingFriends()
		{
			ShowMode = FriendsShowMode.AcceptedAndOutgoing;
		}

		public void ShowIncomingFriends()
		{
			ShowMode = FriendsShowMode.Incoming;
		}

		public void ResetButtons()
		{
			if (!(addAllButton == null) && !(rejectAllButton == null))
			{
				addAllButton.SetActive(false);
				rejectAllButton.SetActive(false);
			}
		}

		public void EnableAddAllButton()
		{
			addAllButton.SetActive(true);
			rejectAllButton.SetActive(false);
		}

		public void DisableAddAllButton()
		{
			addAllButton.SetActive(true);
		}

		public void EnableRejectAllButton()
		{
			addAllButton.SetActive(false);
			rejectAllButton.SetActive(true);
		}

		public void DisableRejectAllButton()
		{
			rejectAllButton.SetActive(true);
		}

		public void ClearIncoming(bool moveToAccepted)
		{
			List<UserCellData> list = new List<UserCellData>(incoming);
			incoming.Clear();
			foreach (UserCellData item in list)
			{
				tableView.RemoveUser(item.id, !moveToAccepted);
				if (moveToAccepted)
				{
					AddItem(item.id, item.uid, FriendType.Accepted);
				}
			}
		}

		private void ItemClearDone(UserListItemComponent item)
		{
			item.transform.SetParent(null, false);
			Object.Destroy(item.gameObject);
		}
	}
}
