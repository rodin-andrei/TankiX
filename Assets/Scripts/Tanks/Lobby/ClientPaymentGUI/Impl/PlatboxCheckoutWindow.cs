using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class PlatboxCheckoutWindow : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI transactionNumberValue;
		[SerializeField]
		private TextMeshProUGUI priceValue;
		[SerializeField]
		private GameObject receiptObject;
		[SerializeField]
		private TextMeshProUGUI crystalsAmountValue;
		[SerializeField]
		private TextMeshProUGUI specialOfferText;
		[SerializeField]
		private TextMeshProUGUI phoneNumberValue;
	}
}
