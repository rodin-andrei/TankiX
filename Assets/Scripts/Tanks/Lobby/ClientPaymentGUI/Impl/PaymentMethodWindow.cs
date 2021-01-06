using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class PaymentMethodWindow : MonoBehaviour
	{
		[SerializeField]
		private RectTransform methodsRoot;
		[SerializeField]
		private TextMeshProUGUI info;
		[SerializeField]
		private TextMeshProUGUI description;
		[SerializeField]
		private PaymentMethodContent methodPrefab;
	}
}
