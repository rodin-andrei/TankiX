using Tanks.Lobby.ClientNavigation.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class QiwiWalletScreenComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private InputField account;
		[SerializeField]
		private Receipt receipt;
		[SerializeField]
		private Text accountText;
		[SerializeField]
		private Text continueButton;
		[SerializeField]
		private Button button;
		[SerializeField]
		private QiwiAccountFormatterComponent formatter;
	}
}
