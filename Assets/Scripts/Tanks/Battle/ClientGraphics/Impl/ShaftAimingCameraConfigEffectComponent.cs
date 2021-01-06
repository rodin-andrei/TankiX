using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftAimingCameraConfigEffectComponent : MonoBehaviour
	{
		[SerializeField]
		private float activationStateTargetFOV;
		[SerializeField]
		private float workingStateMinFOV;
		[SerializeField]
		private float recoveringFOVSpeed;
	}
}
