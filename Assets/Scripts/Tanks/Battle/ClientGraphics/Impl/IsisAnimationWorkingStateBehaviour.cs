using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class IsisAnimationWorkingStateBehaviour : StateMachineBehaviour
	{
		[SerializeField]
		private string startLoopName;
		[SerializeField]
		private string stopLoopName;
	}
}
