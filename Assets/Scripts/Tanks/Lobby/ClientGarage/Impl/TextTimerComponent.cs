using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class TextTimerComponent : LocalizedControl
	{
		[SerializeField]
		private TextMeshProUGUI timerText;
		[SerializeField]
		private int timeUnitNumber;
	}
}
