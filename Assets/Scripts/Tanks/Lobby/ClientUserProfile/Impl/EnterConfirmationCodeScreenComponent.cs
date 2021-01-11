using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class EnterConfirmationCodeScreenComponent : LocalizedScreenComponent, NoScaleScreen
	{
		[SerializeField]
		private TextMeshProUGUI confirmationHintWithUserEmail;

		[SerializeField]
		private TextMeshProUGUI confirmationCodeText;

		[SerializeField]
		private ConfirmationCodeSendAgainComponent confirmationCodeSendAgainComponent;

		[SerializeField]
		private Color emailColor = Color.green;

		public string ConfirmationHintWithUserEmail
		{
			set
			{
				confirmationHintWithUserEmail.text = value;
			}
		}

		public string ConfirmationHint
		{
			get;
			set;
		}

		public string ConfirmationCodeText
		{
			get
			{
				return confirmationCodeText.text;
			}
			set
			{
				confirmationCodeText.text = value;
			}
		}

		public string InvalidCodeMessage
		{
			get;
			set;
		}

		public Color EmailColor
		{
			get
			{
				return emailColor;
			}
		}

		public void ResetSendAgainTimer(long emailSendThresholdInSeconds)
		{
			if (confirmationCodeSendAgainComponent != null)
			{
				confirmationCodeSendAgainComponent.ShowTimer(emailSendThresholdInSeconds);
			}
		}
	}
}
