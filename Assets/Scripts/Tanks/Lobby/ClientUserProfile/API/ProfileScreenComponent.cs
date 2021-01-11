using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class ProfileScreenComponent : BehaviourComponent, NoScaleScreen
	{
		[SerializeField]
		private TextMeshProUGUI otherPlayerNickname;

		[SerializeField]
		private GameObject addToFriendRow;

		[SerializeField]
		private GameObject friendRequestRow;

		[SerializeField]
		private GameObject revokeFriendRow;

		[SerializeField]
		private GameObject removeFriendRow;

		[SerializeField]
		private GameObject enterBattleAsSpectatorRow;

		[SerializeField]
		private ImageListSkin leagueBorder;

		[SerializeField]
		private ImageSkin avatar;

		[SerializeField]
		private GameObject _premiumFrame;

		public GameObject selfUserAccountButtonsTab;

		public GameObject otherUserAccountButtonsTab;

		[SerializeField]
		private Color friendColor;

		public ImageListSkin LeagueBorder
		{
			get
			{
				return leagueBorder;
			}
		}

		public ImageSkin Avatar
		{
			get
			{
				return avatar;
			}
		}

		public bool IsPremium
		{
			set
			{
				_premiumFrame.SetActive(value);
			}
		}

		public TextMeshProUGUI OtherPlayerNickname
		{
			get
			{
				return otherPlayerNickname;
			}
		}

		public GameObject AddToFriendRow
		{
			get
			{
				return addToFriendRow;
			}
		}

		public GameObject FriendRequestRow
		{
			get
			{
				return friendRequestRow;
			}
		}

		public GameObject RemoveFriendRow
		{
			get
			{
				return removeFriendRow;
			}
		}

		public GameObject RevokeFriendRow
		{
			get
			{
				return revokeFriendRow;
			}
		}

		public GameObject EnterBattleAsSpectatorRow
		{
			get
			{
				return enterBattleAsSpectatorRow;
			}
		}

		private void OnEnable()
		{
			AddToFriendRow.SetActive(false);
			friendRequestRow.SetActive(false);
			revokeFriendRow.SetActive(false);
			removeFriendRow.SetActive(false);
			enterBattleAsSpectatorRow.SetActive(false);
			otherPlayerNickname.gameObject.SetActive(false);
		}

		public void SetPlayerColor(bool playerIsFriend)
		{
			otherPlayerNickname.color = ((!playerIsFriend) ? Color.white : friendColor);
		}

		public void HideOnNewItemNotificationShow()
		{
			GetComponent<Animator>().SetBool("newItemNotification", true);
		}

		public void ShowOnNewItemNotificationCLose()
		{
			GetComponent<Animator>().SetBool("newItemNotification", false);
		}
	}
}
