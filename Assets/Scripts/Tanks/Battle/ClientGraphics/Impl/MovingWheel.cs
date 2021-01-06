using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class MovingWheel : Wheel
	{
		public MovingWheel(Transform obj) : base(default(Transform))
		{
		}

		public Vector3 objOffset;
	}
}
