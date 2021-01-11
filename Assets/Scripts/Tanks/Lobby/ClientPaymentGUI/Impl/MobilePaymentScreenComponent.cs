using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class MobilePaymentScreenComponent : BasePaymentScreenComponent, PaymentScreen
	{
		[SerializeField]
		private Text mobilePhoneLabel;

		[SerializeField]
		private Text phoneCountryCode;

		[SerializeField]
		private InputField phoneNumber;

		public virtual string MobilePhoneLabel
		{
			set
			{
				mobilePhoneLabel.text = value;
			}
		}

		public virtual string PhoneCountryCode
		{
			get
			{
				return phoneCountryCode.text;
			}
			set
			{
				phoneCountryCode.text = value;
			}
		}

		public virtual string PhoneNumber
		{
			get
			{
				return phoneNumber.text;
			}
			set
			{
				phoneNumber.text = value;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			phoneNumber.onValueChanged.AddListener(ValidateInput);
		}

		private void OnEnable()
		{
			phoneNumber.text = string.Empty;
			ValidateInput(string.Empty);
		}

		private void ValidateInput(string input = "")
		{
			continueButton.interactable = phoneNumber.text.Length == phoneNumber.characterLimit;
		}
	}
}
