using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class SpeedStateBehaviour : StateMachineBehaviour
	{
		[SerializeField]
		private string startSpeedLoopName = "startSpeedLoop";

		[SerializeField]
		private string stopSpeedLoopName = "stopSpeedLoop";

		private int startSpeedLoopID;

		private int stopSpeedLoopID;

		private void Awake()
		{
			startSpeedLoopID = Animator.StringToHash(startSpeedLoopName);
			stopSpeedLoopID = Animator.StringToHash(stopSpeedLoopName);
		}

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			animator.SetTrigger(startSpeedLoopID);
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			animator.SetTrigger(stopSpeedLoopID);
		}
	}
}
