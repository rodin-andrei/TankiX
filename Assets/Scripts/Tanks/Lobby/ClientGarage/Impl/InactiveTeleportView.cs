using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class InactiveTeleportView : MonoBehaviour
	{
		public GameObject percentText;
		public GameObject successTeleportationText;
		public TextMeshProUGUI timerText;
		public TextMeshProUGUI successTimerText;
		public LocalizedField timerTextStr;
		public Image fill;
	}
}
