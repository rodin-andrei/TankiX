using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class EnterConfirmationCodeScreenComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private TextMeshProUGUI confirmationHintWithUserEmail;
		[SerializeField]
		private TextMeshProUGUI confirmationCodeText;
		[SerializeField]
		private ConfirmationCodeSendAgainComponent confirmationCodeSendAgainComponent;
		[SerializeField]
		private Color emailColor;
	}
}
