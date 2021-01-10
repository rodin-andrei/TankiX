using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class ShopDialogs : ECSBehaviour
	{
		[SerializeField]
		private PaymentMethodWindow paymentMethod;
		[SerializeField]
		private PlatboxWindow platbox;
		[SerializeField]
		private AdyenWindow adyen;
		[SerializeField]
		private QiwiWindow qiwi;
		[SerializeField]
		private PlatboxCheckoutWindow platboxCheckout;
		[SerializeField]
		private PaymentProcessWindow process;
		[SerializeField]
		private WarningWindowComponent warning;
		[SerializeField]
		private PaymentErrorWindow error;
		[SerializeField]
		private LocalizedField forText;
		[SerializeField]
		private PaletteColorField xCrystalsColor;
	}
}
