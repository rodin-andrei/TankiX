using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class MapWayPointsComponent : MonoBehaviour
	{
		[SerializeField]
		private Vector3[] wayPoints;
		[SerializeField]
		private int[] bestWays;
	}
}
