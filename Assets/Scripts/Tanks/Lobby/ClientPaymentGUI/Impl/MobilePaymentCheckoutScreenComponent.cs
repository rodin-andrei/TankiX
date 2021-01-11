using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class MobilePaymentCheckoutScreenComponent : LocalizedScreenComponent, PaymentScreen
	{
		[SerializeField]
		private Text paymentMethodLabel;

		[SerializeField]
		private Text paymentMethodValue;

		[SerializeField]
		private Text successLabel;

		[SerializeField]
		private Text transactionNumberLabel;

		[SerializeField]
		private Text transactionNumberValue;

		[SerializeField]
		private Text priceLabel;

		[SerializeField]
		private Text priceValue;

		[SerializeField]
		private Text crystalsAmountLabel;

		[SerializeField]
		private GameObject receiptObject;

		[SerializeField]
		private Text crystalsAmountValue;

		[SerializeField]
		private Text specialOfferText;

		[SerializeField]
		private Text phoneNumberLabel;

		[SerializeField]
		private Text phoneNumberValue;

		[SerializeField]
		private Text aboutLabel;

		[SerializeField]
		private Text rightPanelHint;

		public virtual string PaymentMethodLabel
		{
			set
			{
				paymentMethodLabel.text = value;
			}
		}

		public virtual string PaymentMethodValue
		{
			set
			{
				paymentMethodValue.text = value;
			}
		}

		public virtual string SuccessLabel
		{
			set
			{
				successLabel.text = value;
			}
		}

		public virtual string TransactionNumberLabel
		{
			set
			{
				transactionNumberLabel.text = value;
			}
		}

		public virtual string PriceLabel
		{
			set
			{
				priceLabel.text = value;
			}
		}

		public virtual string CrystalsAmountLabel
		{
			set
			{
				crystalsAmountLabel.text = value;
			}
		}

		public virtual string PhoneNumberLabel
		{
			set
			{
				phoneNumberLabel.text = value;
			}
		}

		public virtual string AboutLabel
		{
			set
			{
				aboutLabel.text = value;
			}
		}

		public virtual string RightPanelHint
		{
			set
			{
				rightPanelHint.text = value;
			}
		}

		public void SetTransactionNumber(string transactionNumber)
		{
			transactionNumberValue.text = transactionNumber;
		}

		public void SetPrice(double price, string currency)
		{
			priceValue.text = price.ToStringSeparatedByThousands() + " " + currency;
		}

		public void SetCrystalsAmount(long amount)
		{
			receiptObject.SetActive(true);
			crystalsAmountValue.text = amount.ToStringSeparatedByThousands();
		}

		public void SetSpecialOfferText(string text)
		{
			specialOfferText.gameObject.SetActive(true);
			specialOfferText.text = text;
		}

		public void SetPhoneNumber(string phoneNumber)
		{
			phoneNumberValue.text = phoneNumber;
		}

		private void OnDisable()
		{
			receiptObject.SetActive(false);
			specialOfferText.gameObject.SetActive(false);
		}
	}
}
