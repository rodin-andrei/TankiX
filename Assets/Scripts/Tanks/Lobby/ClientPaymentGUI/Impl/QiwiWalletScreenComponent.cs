using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class QiwiWalletScreenComponent : LocalizedScreenComponent, PaymentScreen
	{
		[SerializeField]
		private InputField account;

		private string errorText;

		[SerializeField]
		private Receipt receipt;

		[SerializeField]
		private Text accountText;

		[SerializeField]
		private Text continueButton;

		[SerializeField]
		private Button button;

		[SerializeField]
		private QiwiAccountFormatterComponent formatter;

		public string Account
		{
			get
			{
				return "+" + account.text.Replace(" ", string.Empty);
			}
		}

		public string ErrorText
		{
			get
			{
				return errorText;
			}
			set
			{
				errorText = value;
			}
		}

		public Receipt Receipt
		{
			get
			{
				return receipt;
			}
		}

		public string AccountText
		{
			set
			{
				accountText.text = value;
			}
		}

		public string ContinueButton
		{
			set
			{
				continueButton.text = value;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			account.onValueChanged.AddListener(Check);
			Check(account.text);
		}

		private void Check(string text)
		{
			button.interactable = formatter.IsValidPhoneNumber;
		}

		public void DisableContinueButton()
		{
			button.interactable = false;
		}
	}
}
