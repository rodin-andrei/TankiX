using System;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class WaitingAnswerUIComponent : BehaviourComponent
	{
		[SerializeField]
		protected Slider slider;

		[SerializeField]
		protected GameObject waitingIcon;

		[SerializeField]
		protected GameObject inviteButton;

		[SerializeField]
		protected GameObject alreadyInLabel;

		public float maxTimerValue = 10f;

		private float _timer;

		private bool waiting;

		private float timer
		{
			get
			{
				return _timer;
			}
			set
			{
				_timer = value;
				slider.value = 1f - timer / maxTimerValue;
			}
		}

		public bool Waiting
		{
			set
			{
				waiting = value;
				if (!waiting)
				{
					timer = 0f;
				}
				slider.gameObject.SetActive(waiting);
				waitingIcon.SetActive(waiting);
				inviteButton.SetActive(!waiting);
				alreadyInLabel.SetActive(false);
			}
		}

		private void Update()
		{
			if (waiting)
			{
				timer += Time.deltaTime;
				if (timer > maxTimerValue)
				{
					Waiting = false;
				}
			}
		}

		public void SetTimer(DateTime inviteTime)
		{
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = now - inviteTime;
			if (timeSpan.TotalSeconds > (double)maxTimerValue)
			{
				Waiting = false;
				return;
			}
			timer = timeSpan.Seconds;
			Waiting = true;
		}

		private void OnDisable()
		{
			slider.gameObject.SetActive(false);
			waitingIcon.SetActive(false);
			inviteButton.SetActive(false);
		}
	}
}
