using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class ShaftAimingStraightTargetingEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
	{
		public TargetingData TargetingData
		{
			get;
			set;
		}

		public Vector3 WorkingDirection
		{
			get;
			set;
		}
	}
}
