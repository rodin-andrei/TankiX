using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class StarterPackTimerComponent : MonoBehaviour
	{
		public delegate void TimerExpired();

		public TimerExpired onTimerExpired;

		[SerializeField]
		private TextMeshProUGUI timerTextLabel;

		private Date startTime;

		public bool isOn;

		private float _ticks;

		private float ticks
		{
			get
			{
				return _ticks;
			}
			set
			{
				_ticks = value;
				string text = SecondsToHoursTimerFormat(value);
				if (!text.Equals(timerTextLabel.text))
				{
					timerTextLabel.text = text;
				}
			}
		}

		public void StopTimer()
		{
			ticks = 0f;
			isOn = false;
		}

		public void RunTimer(float remaining)
		{
			startTime = Date.Now + remaining;
			ticks = startTime - Date.Now;
			isOn = true;
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

		private string SecondsToHoursTimerFormat(double seconds)
		{
			int num = (int)(seconds / 60.0);
			int num2 = (int)(seconds - (double)(num * 60));
			int num3 = (int)((float)num / 60f);
			num -= num3 * 60;
			return string.Format("{0:0}:{1:00}:{2:00}", num3, num, num2);
		}
	}
}
