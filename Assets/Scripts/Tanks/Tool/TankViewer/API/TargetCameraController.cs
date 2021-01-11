using UnityEngine;

namespace Tanks.Tool.TankViewer.API
{
	public class TargetCameraController : MonoBehaviour
	{
		public Transform target;

		public float distance = 10f;

		public float xSpeed = 250f;

		public float ySpeed = 120f;

		public float yMinLimit = -20f;

		public float yMaxLimit = 80f;

		public float moveSpeed = 1f;

		public float autoRotateSpeed = 1f;

		public Transform defaultCameraTransform;

		private float x;

		private float y;

		private int rotationMode;

		public bool AutoRotate
		{
			get;
			set;
		}

		public void SetDefaultTransform()
		{
			if (defaultCameraTransform != null)
			{
				base.transform.rotation = defaultCameraTransform.rotation;
				base.transform.position = defaultCameraTransform.position;
				distance = Vector3.Distance(base.transform.position, target.position);
			}
			Vector3 eulerAngles = base.transform.localRotation.eulerAngles;
			x = eulerAngles.y;
			y = eulerAngles.x;
		}

		private void Start()
		{
			SetDefaultTransform();
		}

		private void LateUpdate()
		{
			if (target == null)
			{
				return;
			}
			if (AutoRotate)
			{
				base.transform.RotateAround(target.position, Vector3.up, Time.deltaTime * autoRotateSpeed);
				Vector3 eulerAngles = base.transform.localRotation.eulerAngles;
				x = eulerAngles.y;
				y = eulerAngles.x;
				return;
			}
			distance -= Input.GetAxis("Mouse ScrollWheel");
			if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
			{
				x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
				y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
				y = ClampAngle(y, yMinLimit, yMaxLimit);
			}
			Quaternion quaternion = Quaternion.Euler(y, x, 0f);
			base.transform.localRotation = quaternion;
			Vector3 localPosition = target.position + quaternion * new Vector3(0f, 0f, 0f - distance);
			base.transform.localPosition = localPosition;
		}

		private static float ClampAngle(float angle, float min, float max)
		{
			if (angle < -360f)
			{
				angle += 360f;
			}
			if (angle > 360f)
			{
				angle -= 360f;
			}
			return Mathf.Clamp(angle, min, max);
		}
	}
}
