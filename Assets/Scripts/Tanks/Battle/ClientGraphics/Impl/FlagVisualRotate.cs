using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class FlagVisualRotate : MonoBehaviour
	{
		public GameObject flag;

		public Transform tank;

		public float timerUpsideDown;

		public float scale;

		public float origin;

		public float distanceForRotateFlag;

		private Transform child;

		private float targetAngle;

		private float curentAngle;

		private float timeSinceUpsideDown;

		private Vector3 direction;

		private Vector3 newPos;

		private Vector3 deltaPos;

		private Vector3 oldPos;

		public Component sprite;

		public Sprite3D spriteComponent;

		private void Start()
		{
			child = flag.transform.GetChild(0);
			spriteComponent = flag.transform.GetComponent<Sprite3D>();
		}

		private void Update()
		{
			if (flag.transform.parent == null)
			{
				return;
			}
			newPos = tank.position;
			deltaPos = newPos - oldPos;
			direction = tank.InverseTransformDirection(deltaPos);
			if (direction.z > distanceForRotateFlag)
			{
				targetAngle = 0f;
			}
			if (direction.z < 0f - distanceForRotateFlag)
			{
				targetAngle = -180f;
			}
			curentAngle = Mathf.LerpAngle(curentAngle, targetAngle - flag.transform.parent.localEulerAngles.y, Time.deltaTime);
			child.transform.localEulerAngles = new Vector3(0f, curentAngle, 0f);
			oldPos = tank.position;
			if (flag.transform.up.y <= 0f)
			{
				timeSinceUpsideDown += Time.deltaTime;
				if (timeSinceUpsideDown >= timerUpsideDown)
				{
					spriteComponent.scale = scale;
					spriteComponent.originY = origin;
				}
			}
			else
			{
				timeSinceUpsideDown = 0f;
				spriteComponent.scale = 0f;
				spriteComponent.originY = origin;
			}
		}
	}
}
