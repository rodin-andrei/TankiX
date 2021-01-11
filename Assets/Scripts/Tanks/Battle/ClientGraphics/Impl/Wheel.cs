using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class Wheel
	{
		public float radius;

		public Transform obj;

		private float rotation;

		public Wheel(Transform obj)
		{
			this.obj = obj;
		}

		public void SetRotation(float angle)
		{
			obj.localRotation *= Quaternion.AngleAxis(angle - rotation, Vector3.right);
			rotation = angle;
		}
	}
}
