using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class TankCollidersUnityComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public static readonly string BOUNDS_COLLIDER_NAME = "bounds";

		public static readonly string TANK_TO_STATIC_COLLIDER_NAME = "tank_to_static";

		public static readonly string TANK_TO_STATIC_TOP_COLLIDER_NAME = "top";

		public static readonly string TANK_TO_TANK_COLLIDER_NAME = "tank_to_tank";

		public static readonly string TARGETING_COLLIDER_NAME = "target";

		public static readonly string FRICTION_COLLIDERS_ROOT_NAME = "friction";

		public float a = 0.82f;

		public float inclineSubstraction = 0.1f;

		public PhysicMaterial lowFrictionMaterial;

		public PhysicMaterial highFrictionMaterial;

		private void Awake()
		{
			GetBoundsCollider().enabled = false;
		}

		public Vector3 GetBoundsCenterGlobal()
		{
			BoxCollider boundsCollider = GetBoundsCollider();
			return boundsCollider.transform.TransformPoint(boundsCollider.center);
		}

		public BoxCollider GetBoundsCollider()
		{
			return FindChildCollider(BOUNDS_COLLIDER_NAME).GetComponent<BoxCollider>();
		}

		public Collider GetTankToTankCollider()
		{
			return FindChildCollider(TANK_TO_TANK_COLLIDER_NAME).GetComponent<Collider>();
		}

		public Collider GetTargetingCollider()
		{
			return FindChildCollider(TARGETING_COLLIDER_NAME).GetComponent<Collider>();
		}

		public Collider GetTankToStaticTopCollider()
		{
			return FindChildCollider(TANK_TO_STATIC_TOP_COLLIDER_NAME).GetComponent<Collider>();
		}

		private GameObject FindChildCollider(string childName)
		{
			Collider[] componentsInChildren = base.transform.GetComponentsInChildren<Collider>(true);
			foreach (Collider collider in componentsInChildren)
			{
				if (collider.name.Equals(childName, StringComparison.OrdinalIgnoreCase))
				{
					return collider.gameObject;
				}
			}
			throw new ColliderNotFoundException(this, childName);
		}
	}
}
