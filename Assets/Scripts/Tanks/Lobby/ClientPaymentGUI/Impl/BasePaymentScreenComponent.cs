using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class BasePaymentScreenComponent : LocalizedScreenComponent, PaymentScreen
	{
		[SerializeField]
		private Receipt receipt;

		[SerializeField]
		private Text payButtonLabel;

		[SerializeField]
		protected Button continueButton;

		public Receipt Receipt
		{
			get
			{
				return receipt;
			}
		}

		public virtual string PayButtonLabel
		{
			set
			{
				payButtonLabel.text = value;
			}
		}
	}
}
