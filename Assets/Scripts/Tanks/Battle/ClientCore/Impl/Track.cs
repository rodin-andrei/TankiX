using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class Track
	{
		public SuspensionRay[] rays;

		public float animationSpeed;

		public int side;

		public int numContacts;

		public Vector3 averageSurfaceVelocity = Vector3.zero;

		public Vector3 averageVelocity = Vector3.zero;

		[Inject]
		public static UnityTime UnityTime
		{
			get;
			set;
		}

		public Track(Rigidbody rigidbody, int numRays, Vector3 trackCenterPosition, float trackLength, ChassisConfigComponent chassisConfig, ChassisComponent chassis, int side, float damping)
		{
			this.side = side;
			CreateSuspensionRays(rigidbody, numRays, trackCenterPosition, trackLength, chassisConfig, chassis, damping);
		}

		public void UpdateRigidbody(Rigidbody rigidbody)
		{
			SuspensionRay[] array = rays;
			foreach (SuspensionRay suspensionRay in array)
			{
				suspensionRay.rigidbody = rigidbody;
			}
		}

		public void SetRayсastLayerMask(LayerMask layerMask)
		{
			for (int i = 0; i < rays.Length; i++)
			{
				rays[i].layerMask = layerMask;
			}
		}

		public bool UpdateSuspensionContacts(float dt, float updatePeriod)
		{
			numContacts = 0;
			averageSurfaceVelocity = Vector3.zero;
			averageVelocity = Vector3.zero;
			bool flag = true;
			for (int i = 0; i < rays.Length; i++)
			{
				SuspensionRay suspensionRay = rays[i];
				suspensionRay.Update(dt, updatePeriod);
				flag &= suspensionRay.hasCollision;
				if (suspensionRay.hasCollision)
				{
					numContacts++;
					averageSurfaceVelocity += suspensionRay.surfaceVelocity;
					averageVelocity += suspensionRay.velocity;
				}
			}
			if (!flag && updatePeriod > 0f)
			{
				for (int j = 0; j < rays.Length; j++)
				{
					rays[j].ResetContinuousRaycast();
				}
			}
			if (numContacts > 1)
			{
				averageSurfaceVelocity /= (float)numContacts;
				averageVelocity /= (float)numContacts;
			}
			return flag;
		}

		public void SetAnimationSpeed(float targetValue, float delta)
		{
			if (animationSpeed < targetValue)
			{
				float num = animationSpeed + delta;
				animationSpeed = ((!(num > targetValue)) ? num : targetValue);
			}
			else if (animationSpeed > targetValue)
			{
				float num = animationSpeed - delta;
				animationSpeed = ((!(num < targetValue)) ? num : targetValue);
			}
		}

		private void CreateSuspensionRays(Rigidbody rigidbody, int numRays, Vector3 trackCenterPosition, float trackLength, ChassisConfigComponent chassisConfig, ChassisComponent chassis, float damping)
		{
			rays = new SuspensionRay[numRays];
			float num = trackLength / (float)(rays.Length - 1);
			for (int i = 0; i < numRays; i++)
			{
				Vector3 origin = new Vector3(trackCenterPosition.x, trackCenterPosition.y, trackCenterPosition.z + 0.5f * trackLength - (float)i * num);
				rays[i] = new SuspensionRay(rigidbody, origin, Vector3.down, chassisConfig, chassis, damping);
			}
		}
	}
}
