using System;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class StopWatchComponent : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI textLabel;

		private double startTicks;

		public bool isOn;

		private double ticks
		{
			set
			{
				string text = TimeToStringsConverter.SecondsToTimerFormat(value);
				if (!text.Equals(textLabel.text))
				{
					textLabel.text = text;
				}
			}
		}

		public void RunTheStopwatch()
		{
			startTicks = TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds;
			isOn = true;
		}

		public void StopTheStopwatch()
		{
			isOn = false;
		}

		private void Update()
		{
			if (isOn && textLabel != null)
			{
				ticks = TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds - startTicks;
			}
		}
	}
}
