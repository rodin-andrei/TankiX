using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl.Payguru
{
	public class PayguruDialogComponent : EntityBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI label;
		[SerializeField]
		private ScrollRect scrollRect;
		[SerializeField]
		private PayguruBankItem itemPrefab;
	}
}
