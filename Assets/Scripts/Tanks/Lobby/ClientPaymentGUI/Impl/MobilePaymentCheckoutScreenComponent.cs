using Tanks.Lobby.ClientNavigation.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class MobilePaymentCheckoutScreenComponent : LocalizedScreenComponent
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
	}
}
