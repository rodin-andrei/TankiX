using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class TankFallingComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public int PreviousTrackContactsCount
		{
			get;
			set;
		}

		public int PreviousCollisionContactsCount
		{
			get;
			set;
		}

		public bool IsGrounded
		{
			get;
			set;
		}

		public Vector3 PreviousVelocity
		{
			get;
			set;
		}
	}
}
