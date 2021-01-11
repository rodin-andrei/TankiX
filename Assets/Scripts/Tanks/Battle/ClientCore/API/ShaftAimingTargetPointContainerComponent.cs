using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class ShaftAimingTargetPointContainerComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Vector3 Point
		{
			get;
			set;
		}

		public bool IsInsideTankPart
		{
			get;
			set;
		}

		public float PrevVerticalAngle
		{
			get;
			set;
		}
	}
}
