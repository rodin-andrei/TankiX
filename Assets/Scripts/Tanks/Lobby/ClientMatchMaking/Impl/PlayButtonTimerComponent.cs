using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class PlayButtonTimerComponent : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI timerTitleLabel;
		[SerializeField]
		private TextMeshProUGUI timerTextLabel;
		[SerializeField]
		private LocalizedField matchBeginInTitle;
		[SerializeField]
		private LocalizedField matchBeginIn;
		[SerializeField]
		private LocalizedField matchBeginingTitle;
		public bool isOn;
	}
}
