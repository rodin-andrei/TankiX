using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class FreezeMotionAnimationComponent : MonoBehaviour
	{
		[SerializeField]
		private float idleAnimationSpeedMultiplier;
		[SerializeField]
		private float workingAnimationSpeedMultiplier;
		[SerializeField]
		private string freezeAnimationSpeedCoeffName;
		[SerializeField]
		private float coefAcceleration;
	}
}
