using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TrackMarksBuilderComponent
	{
		public Transform[] leftWheels;
		public Transform[] rightWheels;
		public Vector3[] positions;
		public Vector3[] nextPositions;
		public Vector3[] normals;
		public Vector3[] nextNormals;
		public Vector3[] directions;
		public bool[] contiguous;
		public bool[] prevHits;
		public float[] remaingDistance;
		public bool[] resetWheels;
		public float[] side;
		public float moveStep;
		public Rigidbody rigidbody;
	}
}
