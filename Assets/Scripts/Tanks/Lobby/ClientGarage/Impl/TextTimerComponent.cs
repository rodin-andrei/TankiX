using System;
using System.Text;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class TextTimerComponent : LocalizedControl
	{
		private Date endDate = new Date(float.NegativeInfinity);

		[SerializeField]
		private TextMeshProUGUI timerText;

		[SerializeField]
		private int timeUnitNumber = 2;

		public Date EndDate
		{
			get
			{
				return endDate;
			}
			set
			{
				endDate = value;
				if (!float.IsInfinity(endDate.UnityTime))
				{
					base.gameObject.SetActive(true);
				}
			}
		}

		public string TimerText
		{
			private get;
			set;
		}

		public string Day
		{
			private get;
			set;
		}

		public string Hour
		{
			private get;
			set;
		}

		public string Minute
		{
			private get;
			set;
		}

		public string Second
		{
			private get;
			set;
		}

		public bool ActiveWhenTimeIsUp
		{
			private get;
			set;
		}

		protected void OnDisable()
		{
			EndDate = new Date(float.NegativeInfinity);
		}

		private void Update()
		{
			if (float.IsInfinity(EndDate.UnityTime))
			{
				base.gameObject.SetActive(false);
				return;
			}
			float num = EndDate.UnityTime - Date.Now.UnityTime;
			if (num <= 0f)
			{
				base.gameObject.SetActive(ActiveWhenTimeIsUp);
				timerText.text = string.Empty;
				return;
			}
			int num2 = 0;
			TimeSpan timeSpan = TimeSpan.FromSeconds(num);
			StringBuilder stringBuilder = new StringBuilder();
			if (num2 < timeUnitNumber && timeSpan.Days > 0)
			{
				num2++;
				AppendTime(stringBuilder, timeSpan.Days, Day);
			}
			if (num2 < timeUnitNumber && timeSpan.Hours > 0)
			{
				num2++;
				AppendTime(stringBuilder, timeSpan.Hours, Hour);
			}
			if (num2 < timeUnitNumber && timeSpan.Minutes > 0)
			{
				num2++;
				AppendTime(stringBuilder, timeSpan.Minutes, Minute);
			}
			if (num2 < timeUnitNumber)
			{
				num2++;
				AppendTime(stringBuilder, timeSpan.Seconds, Second);
			}
			timerText.text = TimerText.Replace("{TIME}", stringBuilder.ToString());
		}

		private void AppendTime(StringBuilder builder, int time, string unit)
		{
			if (builder.Length > 0)
			{
				builder.Append(" ");
			}
			builder.Append(time);
			builder.Append(unit);
		}
	}
}
