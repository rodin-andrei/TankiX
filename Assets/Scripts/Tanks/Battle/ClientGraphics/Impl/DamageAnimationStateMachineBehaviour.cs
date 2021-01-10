using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class DamageAnimationStateMachineBehaviour : StateMachineBehaviour
	{
		[SerializeField]
		private string startLoopName;
		[SerializeField]
		private string stopLoopName;
	}
}
