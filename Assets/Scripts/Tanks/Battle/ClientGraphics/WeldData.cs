using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics
{
	public class WeldData
	{
		private float percision;

		private long dimension;

		private HashSet<long> weldHashSet = new HashSet<long>();

		public WeldData(float minValue, float maxValue)
		{
			percision = 1f / minValue;
			dimension = (long)(maxValue * percision);
			if (dimension * dimension * dimension > long.MaxValue)
			{
				throw new Exception("maxValue is too big");
			}
		}

		public bool AddValue(Vector3 position)
		{
			return weldHashSet.Add(GetWeldHash(position));
		}

		private long GetWeldHash(Vector3 position)
		{
			return (long)(position.x * percision) % dimension + (long)(position.y * percision) % dimension * dimension * 2 + (long)(position.z * percision) % dimension * dimension * dimension * 4;
		}
	}
}
