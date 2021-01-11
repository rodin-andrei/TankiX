using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftAimingRotationConfigComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private float aimingOffsetClipping = 35f;

		[SerializeField]
		private float maxAimingCameraOffset = 30f;

		public float AimingOffsetClipping
		{
			get
			{
				return aimingOffsetClipping;
			}
		}

		public float MaxAimingCameraOffset
		{
			get
			{
				return maxAimingCameraOffset;
			}
		}
	}
}
