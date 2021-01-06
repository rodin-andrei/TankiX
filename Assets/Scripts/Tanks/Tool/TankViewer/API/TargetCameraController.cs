using UnityEngine;

namespace Tanks.Tool.TankViewer.API
{
	public class TargetCameraController : MonoBehaviour
	{
		public Transform target;
		public float distance;
		public float xSpeed;
		public float ySpeed;
		public float yMinLimit;
		public float yMaxLimit;
		public float moveSpeed;
		public float autoRotateSpeed;
		public Transform defaultCameraTransform;
	}
}
