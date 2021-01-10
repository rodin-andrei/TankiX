using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class VulcanTurbineAnimationComponent : MonoBehaviour
	{
		[SerializeField]
		private string turbineStateName;
		[SerializeField]
		private int turbineLayerIndex;
		[SerializeField]
		private string turbineCoeffName;
		[SerializeField]
		private string turbineStopName;
		[SerializeField]
		private int turbineMaxSpeedCoeff;
	}
}
