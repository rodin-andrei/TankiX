using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class EnterNewPasswordScreenComponent : LocalizedScreenComponent, NoScaleScreen
	{
		[SerializeField]
		private TextMeshProUGUI newPassword;

		[SerializeField]
		private TextMeshProUGUI repeatNewPassword;

		[SerializeField]
		private TextMeshProUGUI continueButton;

		public virtual string NewPassword
		{
			set
			{
				newPassword.text = value;
			}
		}

		public virtual string RepeatNewPassword
		{
			set
			{
				repeatNewPassword.text = value;
			}
		}

		public virtual string ContinueButton
		{
			set
			{
				continueButton.text = value;
			}
		}
	}
}
