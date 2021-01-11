using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class TankCollidersComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public BoxCollider BoundsCollider
		{
			get;
			set;
		}

		public Collider TankToTankCollider
		{
			get;
			set;
		}

		public Collider TankToStaticTopCollider
		{
			get;
			set;
		}

		public List<GameObject> TargetingColliders
		{
			get;
			set;
		}

		public List<GameObject> VisualTriggerColliders
		{
			get;
			set;
		}

		public List<Collider> TankToStaticColliders
		{
			get;
			set;
		}

		public Vector3 Extends
		{
			get;
			set;
		}
	}
}
