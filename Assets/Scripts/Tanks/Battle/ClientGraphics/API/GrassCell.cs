using System;
using System.Collections.Generic;
using Tanks.Battle.ClientGraphics.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	[Serializable]
	public class GrassCell
	{
		public List<GrassPosition> grassPositions = new List<GrassPosition>();

		public Vector3 center;

		public int lightmapId;
	}
}
