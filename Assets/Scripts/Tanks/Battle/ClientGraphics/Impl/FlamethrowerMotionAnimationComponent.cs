using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class FlamethrowerMotionAnimationComponent : MonoBehaviour
	{
		[SerializeField]
		private string motionCoeffName;
		[SerializeField]
		private string stopMotionName;
		[SerializeField]
		private float idleMotionCoeff;
		[SerializeField]
		private float workingMotionCoeff;
		[SerializeField]
		private string motionStateName;
		[SerializeField]
		private int motionStateLayerIndex;
	}
}
