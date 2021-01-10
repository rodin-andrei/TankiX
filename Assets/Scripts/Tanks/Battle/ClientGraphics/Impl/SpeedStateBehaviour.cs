using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class SpeedStateBehaviour : StateMachineBehaviour
	{
		[SerializeField]
		private string startSpeedLoopName;
		[SerializeField]
		private string stopSpeedLoopName;
	}
}
