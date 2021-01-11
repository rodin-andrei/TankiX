using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class DroneOwnerComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		private Entity incarnation;

		private Rigidbody rigidbody;

		public Entity Incarnation
		{
			get
			{
				return incarnation;
			}
			set
			{
				incarnation = value;
			}
		}

		public Rigidbody Rigidbody
		{
			get
			{
				return rigidbody;
			}
			set
			{
				rigidbody = value;
			}
		}
	}
}
