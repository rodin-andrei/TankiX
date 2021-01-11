using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftAimingCameraConfigEffectComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private float activationStateTargetFOV = 40f;

		[SerializeField]
		private float workingStateMinFOV = 23f;

		[SerializeField]
		private float recoveringFOVSpeed = 30f;

		public float RecoveringFovSpeed
		{
			get
			{
				return recoveringFOVSpeed;
			}
			set
			{
				recoveringFOVSpeed = value;
			}
		}

		public float ActivationStateTargetFov
		{
			get
			{
				return activationStateTargetFOV;
			}
			set
			{
				activationStateTargetFOV = value;
			}
		}

		public float WorkingStateMinFov
		{
			get
			{
				return workingStateMinFOV;
			}
			set
			{
				workingStateMinFOV = value;
			}
		}
	}
}
