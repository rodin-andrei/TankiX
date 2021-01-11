using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class PathData
	{
		public float timeToRecalculatePath;

		public int currentPathIndex;

		public Vector3[] currentPath;
	}
}
