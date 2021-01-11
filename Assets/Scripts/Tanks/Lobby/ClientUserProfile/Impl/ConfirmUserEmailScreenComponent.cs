using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class ConfirmUserEmailScreenComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private Text confirmationHintWithUserEmail;

		[SerializeField]
		private Text sendNewsText;

		[SerializeField]
		private Text confirmText;

		[SerializeField]
		private Text sendAgainText;

		[SerializeField]
		private Text rightPanelHint;

		[SerializeField]
		private Text confirmationCodeText;

		[SerializeField]
		private Color emailColor = Color.green;

		[SerializeField]
		private GameObject cancelButton;

		[SerializeField]
		private GameObject changeEmailButton;

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

		public string SendAgainText
		{
			set
			{
				sendAgainText.text = value.ToUpper();
			}
		}

		public string RightPanelHint
		{
			set
			{
				rightPanelHint.text = value;
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

		private void OnEnable()
		{
			cancelButton.SetActive(false);
			changeEmailButton.SetActive(true);
			rightPanelHint.gameObject.SetActive(true);
		}

		public void ActivateCancel()
		{
			cancelButton.SetActive(true);
			changeEmailButton.SetActive(false);
			rightPanelHint.gameObject.SetActive(false);
		}
	}
}
