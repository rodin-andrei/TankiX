using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class TankFallEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
	{
		public float FallingPower
		{
			get;
			set;
		}

		public TankFallingType FallingType
		{
			get;
			set;
		}

		public Transform FallingTransform
		{
			get;
			set;
		}

		public Vector3 Velocity
		{
			get;
			set;
		}
	}
}
