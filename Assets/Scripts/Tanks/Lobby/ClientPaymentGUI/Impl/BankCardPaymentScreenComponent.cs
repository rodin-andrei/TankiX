using Lobby.ClientPayment.Impl;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class BankCardPaymentScreenComponent : BasePaymentScreenComponent
	{
		[SerializeField]
		private Text cardRequisitesLabel;

		[SerializeField]
		private Text cardNumberLabel;

		[SerializeField]
		private Text cardExpirationDateLabel;

		[SerializeField]
		private Text cardHolderLabel;

		[SerializeField]
		private Text cardCVVLabel;

		[SerializeField]
		private Text cardCVVHint;

		[SerializeField]
		private InputField number;

		[SerializeField]
		private InputField mm;

		[SerializeField]
		private InputField yy;

		[SerializeField]
		private InputField cardHolder;

		[SerializeField]
		private InputField cvc;

		public virtual string CardRequisitesLabel
		{
			set
			{
				cardRequisitesLabel.text = value;
			}
		}

		public virtual string CardNumberLabel
		{
			set
			{
				cardNumberLabel.text = value;
			}
		}

		public virtual string CardExpirationDateLabel
		{
			set
			{
				cardExpirationDateLabel.text = value;
			}
		}

		public virtual string CardHolderLabel
		{
			set
			{
				cardHolderLabel.text = value;
			}
		}

		public virtual string CardCVVLabel
		{
			set
			{
				cardCVVLabel.text = value;
			}
		}

		public virtual string CardCVVHint
		{
			set
			{
				cardCVVHint.text = value;
			}
		}

		public string Number
		{
			get
			{
				return number.text;
			}
		}

		public string MM
		{
			get
			{
				return mm.text;
			}
		}

		public string YY
		{
			get
			{
				return yy.text;
			}
		}

		public string CardHolder
		{
			get
			{
				return cardHolder.text;
			}
		}

		public string CVC
		{
			get
			{
				return cvc.text;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			cvc.onValueChanged.AddListener(ValidateInput);
			cardHolder.onValueChanged.AddListener(ValidateInput);
			number.onValueChanged.AddListener(ValidateInput);
			mm.onValueChanged.AddListener(ValidateInput);
			yy.onValueChanged.AddListener(ValidateInput);
		}

		private void OnEnable()
		{
			cvc.text = string.Empty;
			cardHolder.text = string.Empty;
			number.text = string.Empty;
			mm.text = string.Empty;
			yy.text = string.Empty;
			ValidateInput(string.Empty);
		}

		private void ValidateInput(string input = "")
		{
			bool flag = cvc.text.Length == cvc.characterLimit && BankCardUtils.IsBankCard(number.text) && yy.text.Length == yy.characterLimit && !string.IsNullOrEmpty(cardHolder.text);
			if (flag)
			{
				int num = int.Parse(mm.text);
				flag = flag && num >= 1 && num <= 12;
			}
			continueButton.interactable = flag;
		}
	}
}
