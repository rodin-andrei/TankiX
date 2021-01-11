using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class PlayButtonTimerComponent : MonoBehaviour
	{
		public delegate void TimerExpired();

		public TimerExpired onTimerExpired;

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

		private Date startTime;

		private float _ticks;

		public bool isOn;

		private bool matchBeginning;

		private float ticks
		{
			get
			{
				return _ticks;
			}
			set
			{
				_ticks = value;
				string text = ((!matchBeginning) ? (matchBeginIn.Value + " ") : string.Empty) + TimeToStringsConverter.SecondsToTimerFormat(value);
				if (!text.Equals(timerTextLabel.text))
				{
					timerTextLabel.text = text;
				}
			}
		}

		public void RunTheTimer(Date startTime, bool matchBeginnig)
		{
			matchBeginning = matchBeginnig;
			if (matchBeginnig)
			{
				timerTitleLabel.text = matchBeginingTitle.Value;
			}
			else
			{
				timerTitleLabel.text = matchBeginInTitle.Value;
			}
			this.startTime = startTime;
			ticks = startTime - Date.Now;
			isOn = true;
		}

		public void StopTheTimer()
		{
			isOn = false;
		}

		private void Update()
		{
			if (!isOn || !(timerTextLabel != null))
			{
				return;
			}
			ticks = startTime - Date.Now;
			if (ticks <= 0f)
			{
				ticks = 0f;
				isOn = false;
				if (onTimerExpired != null)
				{
					onTimerExpired();
				}
			}
		}

		private void OnDestroy()
		{
			onTimerExpired = null;
		}
	}
}
