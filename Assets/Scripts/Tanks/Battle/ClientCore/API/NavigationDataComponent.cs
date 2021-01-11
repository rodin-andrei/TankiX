using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class NavigationDataComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Vector3 MovePosition
		{
			get;
			set;
		}

		public bool ObstacleOnCriticalDistance
		{
			get;
			set;
		}

		public bool TankInTheFront
		{
			get;
			set;
		}

		public bool ObstacleOnAvoidanceDistance
		{
			get;
			set;
		}

		public float LastMove
		{
			get;
			set;
		}

		public float LastTurn
		{
			get;
			set;
		}

		public BehaviourTreeNode BehavouTree
		{
			get;
			set;
		}

		public PathData PathData
		{
			get;
			set;
		}
	}
}
