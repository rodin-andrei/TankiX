using TMPro;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	[RequireComponent(typeof(Animator))]
	public class Timer : MonoBehaviour
	{
		public static float battleTime;

		private bool firstUpdateTime = true;

		private Animator animator;

		private TextMeshProUGUI text;

		private float lastTime;

		private float intLastTime;

		private bool autoUpdate;

		private Animator Animator
		{
			get
			{
				if (animator == null)
				{
					animator = GetComponent<Animator>();
				}
				return animator;
			}
		}

		private TextMeshProUGUI Text
		{
			get
			{
				if (text == null)
				{
					text = GetComponent<TextMeshProUGUI>();
				}
				return text;
			}
		}

		public void Set(float time)
		{
			if (!Mathf.Approximately(time, lastTime))
			{
				Animator.SetFloat("Speed", (time < 10f) ? 1 : 0);
				Animator.SetBool("Grow", time < 60f);
				int num = (int)time;
				if (firstUpdateTime)
				{
					UpdateTextTime(num);
				}
				else if ((float)num != intLastTime)
				{
					UpdateTextTime(num);
				}
				lastTime = time;
				intLastTime = num;
				battleTime = intLastTime;
			}
		}

		public void Set(float time, bool autoUpdate)
		{
			this.autoUpdate = autoUpdate;
			Set(time);
		}

		private void Update()
		{
			if (autoUpdate && lastTime > 0f)
			{
				Set(lastTime - Time.deltaTime);
			}
		}

		private void UpdateTextTime(int time)
		{
			firstUpdateTime = false;
			Text.text = FormatTime(time);
		}

		private string FormatTime(int time)
		{
			return string.Format("{00}:{1:00}", time / 60, time % 60);
		}
	}
}
