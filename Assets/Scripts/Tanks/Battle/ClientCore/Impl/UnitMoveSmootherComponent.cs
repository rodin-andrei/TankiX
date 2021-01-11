using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class UnitMoveSmootherComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private float smoothingSpeed = 5f;

		private Vector3 smoothPositionDelta;

		private Quaternion smoothRotationDelta;

		private Vector3 lastPosition;

		private Quaternion lastRotation;

		private Rigidbody body;

		private void Start()
		{
			body = GetComponentInParent<Rigidbody>();
		}

		public void BeforeSetMovement()
		{
			lastPosition = base.transform.position;
			lastRotation = base.transform.rotation;
		}

		public void AfterSetMovement()
		{
			base.transform.position = lastPosition;
			base.transform.rotation = lastRotation;
			smoothPositionDelta = base.transform.localPosition;
			smoothRotationDelta = base.transform.localRotation;
			LateUpdate();
		}

		private void LateUpdate()
		{
			if ((bool)body)
			{
				smoothPositionDelta = Vector3.Lerp(smoothPositionDelta, Vector3.zero, smoothingSpeed * Time.deltaTime);
				smoothRotationDelta = Quaternion.Slerp(smoothRotationDelta, Quaternion.identity, smoothingSpeed * Time.smoothDeltaTime);
				base.transform.SetLocalPositionSafe(smoothPositionDelta);
				base.transform.SetLocalRotationSafe(smoothRotationDelta);
				body.centerOfMass = smoothPositionDelta;
			}
		}
	}
}
