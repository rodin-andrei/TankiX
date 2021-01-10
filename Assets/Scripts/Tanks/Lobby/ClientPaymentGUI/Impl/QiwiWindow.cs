using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class QiwiWindow : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI info;
		[SerializeField]
		private QiwiAccountFormatterComponent account;
		[SerializeField]
		private Animator continueButton;
	}
}
