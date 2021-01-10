using UnityEngine.UI;
using UnityEngine;

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
	}
}
