using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class ExchangeConfirmationWindow : LocalizedControl
	{
		[SerializeField]
		private Text questionText;
		[SerializeField]
		private TextMeshProUGUI confirmText;
		[SerializeField]
		private TextMeshProUGUI cancelText;
		[SerializeField]
		private Text forText;
		[SerializeField]
		private Button confirm;
		[SerializeField]
		private Button cancel;
		[SerializeField]
		private Text crystalsText;
		[SerializeField]
		private Text xCrystalsText;
	}
}
