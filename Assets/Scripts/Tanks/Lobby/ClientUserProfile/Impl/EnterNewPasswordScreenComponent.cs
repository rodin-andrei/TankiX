using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class EnterNewPasswordScreenComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private TextMeshProUGUI newPassword;
		[SerializeField]
		private TextMeshProUGUI repeatNewPassword;
		[SerializeField]
		private TextMeshProUGUI continueButton;
	}
}
