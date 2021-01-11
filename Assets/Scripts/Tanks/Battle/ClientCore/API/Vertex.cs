using MIConvexHull;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class Vertex : IVertex
	{
		private readonly Vector3 unityVertex;

		private readonly double[] position;

		public double[] Position
		{
			get
			{
				return position;
			}
		}

		public Vector3 UnityVertex
		{
			get
			{
				return unityVertex;
			}
		}

		public int Index
		{
			get;
			set;
		}

		public Vertex(Vector3 unityVertex)
		{
			this.unityVertex = unityVertex;
			position = new double[3]
			{
				unityVertex.x,
				unityVertex.y,
				unityVertex.z
			};
		}
	}
}
