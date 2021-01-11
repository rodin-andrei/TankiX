using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class MainHUDTimersComponent : BehaviourComponent
	{
		[SerializeField]
		private Timer timer;

		[SerializeField]
		private Timer warmingUpTimer;

		[SerializeField]
		private Animator hudAnimator;

		[SerializeField]
		private GameObject warmingUpTimerContainer;

		[SerializeField]
		private GameObject mainTimerContainer;

		public Timer Timer
		{
			get
			{
				return timer;
			}
		}

		public Timer WarmingUpTimer
		{
			get
			{
				return warmingUpTimer;
			}
		}

		public void ShowWarmingUpTimer()
		{
			warmingUpTimerContainer.SetActive(true);
			mainTimerContainer.SetActive(false);
		}

		public void HideWarmingUpTimer()
		{
			warmingUpTimerContainer.SetActive(false);
			mainTimerContainer.SetActive(true);
		}

		private void OnDisable()
		{
			HideWarmingUpTimer();
		}
	}
}
