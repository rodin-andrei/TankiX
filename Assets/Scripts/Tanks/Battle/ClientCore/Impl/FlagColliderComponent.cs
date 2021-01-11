using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class FlagColliderComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public BoxCollider boxCollider
		{
			get;
			set;
		}

		public FlagColliderComponent()
		{
		}

		public FlagColliderComponent(BoxCollider boxCollider)
		{
			this.boxCollider = boxCollider;
		}
	}
}
