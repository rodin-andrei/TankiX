using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class SuspensionRay
	{
		public SuspensionRay(Rigidbody body, Vector3 origin, Vector3 direction, ChassisConfigComponent chassisConfig, ChassisComponent chassis, float damping)
		{
		}

		public bool hadPreviousCollision;
		public bool hasCollision;
		public LayerMask layerMask;
		public Vector3 surfaceVelocity;
		public Vector3 velocity;
		public float compression;
	}
}
