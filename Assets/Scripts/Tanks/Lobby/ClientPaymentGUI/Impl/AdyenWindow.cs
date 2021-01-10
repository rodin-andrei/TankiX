using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class AdyenWindow : ECSBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI info;
		[SerializeField]
		private Animator continueButton;
		[SerializeField]
		private TMP_InputField cardNumber;
		[SerializeField]
		private TMP_InputField mm;
		[SerializeField]
		private TMP_InputField yy;
		[SerializeField]
		private TMP_InputField cvc;
		[SerializeField]
		private TMP_InputField cardHolder;
	}
}
