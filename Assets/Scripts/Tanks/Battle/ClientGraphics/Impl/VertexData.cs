using System;
using UnityEngine;
using Tanks.Battle.ClientGraphics.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public struct VertexData
	{
		public VertexData(Vector3 vertex, Vector3 normal, SurfaceType surfaceType) : this()
		{
		}

		public Vector3 vertex;
		public Vector3 normal;
		public SurfaceType surfaceType;
	}
}
