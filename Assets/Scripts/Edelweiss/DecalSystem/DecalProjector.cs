using UnityEngine;

namespace Edelweiss.DecalSystem
{
	public class DecalProjector : DecalProjectorBase
	{
		public DecalProjector(Vector3 a_Position, Quaternion a_Rotation, Vector3 a_Scale, float a_CullingAngle, float a_meshOffset, int a_UV1RectangleIndex, int a_UV2RectangleIndex)
		{
		}

		public Vector3 position;
		public Quaternion rotation;
		public Vector3 scale;
		public float cullingAngle;
		public float meshOffset;
		public int uv1RectangleIndex;
		public int uv2RectangleIndex;
		public Color vertexColor;
	}
}
