using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class ProfileScreenLocalizationComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Text logoutButtonText;

		[SerializeField]
		private Text logoutButtonConfirmText;

		[SerializeField]
		private Text logoutButtonCancelText;

		[SerializeField]
		private Text requestFriendButtonText;

		[SerializeField]
		private Text revokeFriendButtonText;

		[SerializeField]
		private Text acceptFriendButtonText;

		[SerializeField]
		private Text rejectFriendButtonText;

		[SerializeField]
		private Text removeFriendButtonText;

		[SerializeField]
		private Text removeFriendButtonConfirmText;

		[SerializeField]
		private Text removeFriendButtonCancelText;

		[SerializeField]
		private Text goToConfirmEmailScreenButtonText;

		[SerializeField]
		private Text goToChangeUIDScreenButtonText;

		[SerializeField]
		private Text goToPromoCodesScreenButtonText;

		[SerializeField]
		private Text enterAsSpectatorButtonText;

		public string RequestFriendButtonText
		{
			set
			{
				requestFriendButtonText.text = value.ToUpper();
			}
		}

		public string RevokeFriendButtonText
		{
			set
			{
				revokeFriendButtonText.text = value.ToUpper();
			}
		}

		public string AcceptFriendButtonText
		{
			set
			{
				acceptFriendButtonText.text = value.ToUpper();
			}
		}

		public string RejectFriendButtonText
		{
			set
			{
				rejectFriendButtonText.text = value.ToUpper();
			}
		}

		public string RemoveFriendButtonText
		{
			set
			{
				removeFriendButtonText.text = value.ToUpper();
			}
		}

		public string RemoveFriendButtonConfirmText
		{
			set
			{
				removeFriendButtonConfirmText.text = value.ToUpper();
			}
		}

		public string RemoveFriendButtonCancelText
		{
			set
			{
				removeFriendButtonCancelText.text = value.ToUpper();
			}
		}

		public string LogoutButtonText
		{
			set
			{
				logoutButtonText.text = value.ToUpper();
			}
		}

		public string LogoutButtonConfirmText
		{
			set
			{
				logoutButtonConfirmText.text = value.ToUpper();
			}
		}

		public string LogoutButtonCancelText
		{
			set
			{
				logoutButtonCancelText.text = value.ToUpper();
			}
		}

		public string GoToConfirmEmailScreenButtonText
		{
			set
			{
				goToConfirmEmailScreenButtonText.text = value.ToUpper();
			}
		}

		public string GoToChangeUIDScreenButtonText
		{
			set
			{
				goToChangeUIDScreenButtonText.text = value.ToUpper();
			}
		}

		public string GoToPromoCodesScreenButtonText
		{
			set
			{
				goToPromoCodesScreenButtonText.text = value.ToUpper();
			}
		}

		public string EnterAsSpectatorButtonText
		{
			set
			{
				enterAsSpectatorButtonText.text = value.ToUpper();
			}
		}

		public string ProfileHeaderText
		{
			get;
			set;
		}

		public string MyProfileHeaderText
		{
			get;
			set;
		}

		public string FriendsProfileHeaderText
		{
			get;
			set;
		}

		public string OfferFriendShipText
		{
			get;
			set;
		}

		public string FriendRequestSentText
		{
			get;
			set;
		}
	}
}
