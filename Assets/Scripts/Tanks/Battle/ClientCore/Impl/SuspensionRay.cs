using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class SuspensionRay
	{
		public bool hadPreviousCollision;

		public bool hasCollision;

		public RaycastHit rayHit;

		public LayerMask layerMask;

		public Vector3 surfaceVelocity;

		public Vector3 velocity;

		public float compression;

		private Vector3 origin;

		private Vector3 direction;

		private ChassisConfigComponent chassisConfig;

		private ChassisComponent chassis;

		private Vector3 globalOrigin;

		private Vector3 globalDirection;

		private float prevCompression;

		private float damping;

		private float nextRaycastUpdateTime;

		private RaycastHit lastRayHit;

		private bool lastCollision;

		public Rigidbody rigidbody
		{
			private get;
			set;
		}

		public SuspensionRay(Rigidbody body, Vector3 origin, Vector3 direction, ChassisConfigComponent chassisConfig, ChassisComponent chassis, float damping)
		{
			rigidbody = body;
			this.origin = origin;
			this.direction = direction;
			this.chassisConfig = chassisConfig;
			this.chassis = chassis;
			this.damping = damping;
			ConvertToGlobal();
			rayHit.distance = chassisConfig.MaxRayLength;
			rayHit.point = globalOrigin + globalDirection * chassisConfig.MaxRayLength;
		}

		public void Update(float dt, float updatePeriod)
		{
			Raycast(updatePeriod);
			if (hasCollision)
			{
				ApplySpringForce(dt);
				CalculateSurfaceVelocity();
				velocity = rigidbody.GetPointVelocity(rayHit.point);
			}
			else
			{
				surfaceVelocity = Vector3.zero;
				velocity = Vector3.zero;
				rayHit.distance = chassisConfig.MaxRayLength;
				rayHit.point = globalOrigin + globalDirection * chassisConfig.MaxRayLength;
			}
		}

		private void Raycast(float updatePeriod)
		{
			ConvertToGlobal();
			prevCompression = chassisConfig.MaxRayLength - rayHit.distance;
			hadPreviousCollision = hasCollision;
			hasCollision = ContinuousRayCast(new Ray(globalOrigin, globalDirection), out rayHit, chassisConfig.MaxRayLength, layerMask, updatePeriod);
		}

		public void ResetContinuousRaycast()
		{
			nextRaycastUpdateTime = 0f;
		}

		private bool ContinuousRayCast(Ray ray, out RaycastHit rayHit, float range, int layerMask, float period)
		{
			if (Time.timeSinceLevelLoad > nextRaycastUpdateTime)
			{
				lastCollision = Physics.Raycast(ray, out lastRayHit, range, layerMask);
				rayHit = lastRayHit;
				nextRaycastUpdateTime = Time.timeSinceLevelLoad + period;
				return lastCollision;
			}
			rayHit = lastRayHit;
			return lastCollision;
		}

		private void ConvertToGlobal()
		{
			globalDirection = rigidbody.transform.TransformDirection(direction);
			globalOrigin = rigidbody.transform.TransformPoint(origin);
		}

		public void ApplySpringForce(float dt)
		{
			compression = chassisConfig.MaxRayLength - rayHit.distance;
			float num = (compression - prevCompression) * damping / dt;
			float num2 = Mathf.Max(chassis.SpringCoeff * compression + num, 0f);
			rigidbody.AddForceAtPositionSafe(globalDirection * (0f - num2), globalOrigin);
		}

		private void CalculateSurfaceVelocity()
		{
			if (rayHit.rigidbody != null)
			{
				surfaceVelocity = rayHit.rigidbody.GetPointVelocity(rayHit.point);
			}
			else
			{
				surfaceVelocity = Vector3.zero;
			}
		}

		public Vector3 GetGlobalOrigin()
		{
			return globalOrigin;
		}

		public Vector3 GetGlobalDirection()
		{
			return globalDirection;
		}
	}
}
