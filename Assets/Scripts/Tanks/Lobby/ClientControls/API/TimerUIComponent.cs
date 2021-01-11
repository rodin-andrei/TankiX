using System;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	public class TimerUIComponent : MonoBehaviour
	{
		[SerializeField]
		private Text minutesText;

		[SerializeField]
		private Text secondsText;

		private float secondsLeft;

		private int previousSecondsLeft;

		public float SecondsLeft
		{
			get
			{
				return secondsLeft;
			}
			set
			{
				secondsLeft = value;
				UpdateTextFields();
			}
		}

		public void Awake()
		{
			secondsLeft = 0f;
			previousSecondsLeft = -1;
		}

		private bool ValidateSecondsChanging(int intSecondsLeft)
		{
			if (intSecondsLeft == previousSecondsLeft)
			{
				return false;
			}
			previousSecondsLeft = intSecondsLeft;
			return true;
		}

		private void UpdateTextFields()
		{
			int num = (int)secondsLeft;
			if (ValidateSecondsChanging(num))
			{
				if (minutesText != null)
				{
					TimeSpan timeSpan = new TimeSpan(0, 0, 0, num);
					secondsText.text = AddLeadingZero(timeSpan.Seconds);
					minutesText.text = ((int)timeSpan.TotalMinutes).ToString();
				}
				else
				{
					secondsText.text = num.ToString();
				}
			}
		}

		private string AddLeadingZero(int seconds)
		{
			return ((seconds >= 10) ? string.Empty : "0") + seconds;
		}
	}
}
