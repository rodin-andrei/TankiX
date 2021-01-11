using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientFriends.Impl
{
	public class FriendsScreenLocalizationComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
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

		public string EmptyListNotificationText
		{
			set
			{
				emptyListNotificationText.text = value;
			}
		}

		public string AcceptedFriendHeader
		{
			set
			{
				acceptedFriendHeader.text = value;
			}
		}

		public string PossibleFriendHeader
		{
			set
			{
				possibleFriendHeader.text = value;
			}
		}

		public string SearchButtonText
		{
			set
			{
				searchButtonText.text = value;
			}
		}

		public string SearchUserHint
		{
			set
			{
				searchUserHint.text = value;
			}
		}

		public string SearchUserError
		{
			set
			{
				searchUserError.text = value;
			}
		}

		public string ProfileButtonText
		{
			set
			{
				profileButtonText.text = value;
			}
		}

		public string SpectateButtonText
		{
			set
			{
				spectateButtonText.text = value;
			}
		}

		public string AcceptButtonText
		{
			set
			{
				acceptButtonText.text = value;
			}
		}

		public string RejectButtonText
		{
			set
			{
				rejectButtonText.text = value;
			}
		}

		public string RevokeButtonText
		{
			set
			{
				revokeButtonText.text = value;
			}
		}

		public string RemoveButtonText
		{
			set
			{
				removeButtonText.text = value;
			}
		}

		public string RemoveButtonConfirmText
		{
			set
			{
				removeButtonConfirmText.text = value;
			}
		}

		public string RemoveButtonCancelText
		{
			set
			{
				removeButtonCancelText.text = value;
			}
		}
	}
}
