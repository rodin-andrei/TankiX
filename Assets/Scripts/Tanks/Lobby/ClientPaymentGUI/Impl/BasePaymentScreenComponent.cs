using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class BasePaymentScreenComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private Receipt receipt;
		[SerializeField]
		private Text payButtonLabel;
		[SerializeField]
		protected Button continueButton;
	}
}
