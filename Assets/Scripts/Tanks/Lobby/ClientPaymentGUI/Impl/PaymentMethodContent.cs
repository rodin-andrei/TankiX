using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class PaymentMethodContent : MonoBehaviour
	{
		[SerializeField]
		private ImageListSkin skin;
		[SerializeField]
		private TextMeshProUGUI text;
		[SerializeField]
		private GameObject saleItem;
		[SerializeField]
		private GameObject saleItemLabelEmpty;
		[SerializeField]
		private GameObject saleItemXtraLabelEmpty;
		[SerializeField]
		private TextMeshProUGUI saleItemLabelText;
	}
}
