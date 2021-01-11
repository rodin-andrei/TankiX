using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public abstract class DamageAnimationStateMachineBehaviour : StateMachineBehaviour
	{
		[SerializeField]
		private string startLoopName = "startDamageLoop";

		[SerializeField]
		private string stopLoopName = "stopDamageLoop";

		protected int startLoopID;

		protected int stopLoopID;

		private void Awake()
		{
			startLoopID = Animator.StringToHash(startLoopName);
			stopLoopID = Animator.StringToHash(stopLoopName);
		}
	}
}
