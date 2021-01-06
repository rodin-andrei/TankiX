using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class Receipt : LocalizedControl
	{
		[SerializeField]
		private Text price;
		[SerializeField]
		private Text total;
		[SerializeField]
		private ReceiptItem receiptItemPrefab;
		[SerializeField]
		private RectTransform receiptItemsContainer;
		[SerializeField]
		private Text priceLabel;
		[SerializeField]
		private GameObject totalObject;
		[SerializeField]
		private Text specialOfferText;
		[SerializeField]
		private Text totalLabel;
	}
}
