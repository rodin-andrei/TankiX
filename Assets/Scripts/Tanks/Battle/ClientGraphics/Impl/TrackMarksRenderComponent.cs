using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	internal class TrackMarksRenderComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Mesh mesh;

		public bool dirty;

		public TrackRenderData[] trackRenderDatas;

		public Vector3[] meshPositions;

		public Vector2[] meshUVs;

		public Vector3[] meshNormals;

		public Color[] meshColors;

		public int[] meshTris;

		public void Clear()
		{
			mesh.Clear();
			for (int i = 0; i < trackRenderDatas.Length; i++)
			{
				trackRenderDatas[i].Reset();
			}
			for (int j = 0; j < meshPositions.Length; j++)
			{
				meshPositions[j] = Vector3.zero;
				meshUVs[j] = Vector2.zero;
				meshNormals[j] = Vector3.zero;
				meshColors[j] = Color.white;
			}
			for (int k = 0; k < meshTris.Length; k++)
			{
				meshTris[k] = 0;
			}
		}
	}
}
