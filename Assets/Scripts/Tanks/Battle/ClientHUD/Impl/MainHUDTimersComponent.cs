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
	}
}
