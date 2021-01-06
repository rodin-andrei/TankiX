using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class Track
	{
		public Track(Rigidbody rigidbody, int numRays, Vector3 trackCenterPosition, float trackLength, ChassisConfigComponent chassisConfig, ChassisComponent chassis, int side, float damping)
		{
		}

		public float animationSpeed;
		public int side;
		public int numContacts;
		public Vector3 averageSurfaceVelocity;
		public Vector3 averageVelocity;
	}
}
