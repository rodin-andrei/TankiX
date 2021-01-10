using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class StarterPackTimerComponent : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI timerTextLabel;
		public bool isOn;
	}
}
