using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class FreeCameraController : MonoBehaviour
	{
		public float xSpeed = 250f;

		public float ySpeed = 120f;

		public float yMinLimit = -20f;

		public float yMaxLimit = 80f;

		public float moveSpeed = 1f;

		private float x;

		private float y;

		private void Start()
		{
			Init();
		}

		private void OnEnable()
		{
			Init();
		}

		private void Init()
		{
			Vector3 eulerAngles = base.transform.localRotation.eulerAngles;
			x = eulerAngles.y;
			y = eulerAngles.x;
		}

		private void LateUpdate()
		{
			if (GUIUtility.hotControl != 0 || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				return;
			}
			if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
			{
				x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
				y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
				y = ClampAngle(y, yMinLimit, yMaxLimit);
			}
			Quaternion localRotation = Quaternion.Euler(y, x, 0f);
			base.transform.localRotation = localRotation;
			if (Input.GetMouseButton(1))
			{
				Vector3 translation = default(Vector3);
				translation.x = moveSpeed * Input.GetAxis("Horizontal");
				translation.y = moveSpeed * Input.GetAxis("Deep");
				translation.z = moveSpeed * Input.GetAxis("Vertical");
				if ((double)translation.x != 0.0 || (double)translation.y != 0.0 || (double)translation.z != 0.0)
				{
					base.transform.Translate(translation);
				}
			}
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
