using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientFriends.Impl
{
	public class FriendsScreenLocalizationComponent : MonoBehaviour
	{
		[SerializeField]
		private Text emptyListNotificationText;
		[SerializeField]
		private Text acceptedFriendHeader;
		[SerializeField]
		private Text possibleFriendHeader;
		[SerializeField]
		private Text searchButtonText;
		[SerializeField]
		private Text searchUserHint;
		[SerializeField]
		private Text searchUserError;
		[SerializeField]
		private Text profileButtonText;
		[SerializeField]
		private Text spectateButtonText;
		[SerializeField]
		private Text acceptButtonText;
		[SerializeField]
		private Text rejectButtonText;
		[SerializeField]
		private Text revokeButtonText;
		[SerializeField]
		private Text removeButtonText;
		[SerializeField]
		private Text removeButtonConfirmText;
		[SerializeField]
		private Text removeButtonCancelText;
	}
}
