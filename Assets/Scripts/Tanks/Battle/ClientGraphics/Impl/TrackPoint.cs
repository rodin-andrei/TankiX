using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TrackPoint
	{
		public TrackPoint(Vector3 position, Transform trackPoint, Vector3 trackPointOffset)
		{
		}

		public Vector3 initialPosition;
		public Transform obj;
		public Vector3 objOffset;
		public float desiredVerticalPosition;
		public Vector3 currentPosition;
		public float velocity;
	}
}
