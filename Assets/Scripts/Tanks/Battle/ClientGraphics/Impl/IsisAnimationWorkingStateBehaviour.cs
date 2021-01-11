using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class IsisAnimationWorkingStateBehaviour : StateMachineBehaviour
	{
		[SerializeField]
		private string startLoopName = "startWorkingLoop";

		[SerializeField]
		private string stopLoopName = "stopWorkingLoop";

		private int startLoopID;

		private int stopLoopID;

		private void Awake()
		{
			startLoopID = Animator.StringToHash(startLoopName);
			stopLoopID = Animator.StringToHash(stopLoopName);
		}

		private new void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
		{
			animator.SetTrigger(startLoopID);
		}

		private new void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
		{
			animator.SetTrigger(stopLoopID);
		}
	}
}
