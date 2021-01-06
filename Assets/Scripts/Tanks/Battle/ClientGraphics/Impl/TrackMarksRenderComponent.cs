using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	internal class TrackMarksRenderComponent
	{
		public Mesh mesh;
		public bool dirty;
		public Vector3[] meshPositions;
		public Vector2[] meshUVs;
		public Vector3[] meshNormals;
		public Color[] meshColors;
		public int[] meshTris;
	}
}
