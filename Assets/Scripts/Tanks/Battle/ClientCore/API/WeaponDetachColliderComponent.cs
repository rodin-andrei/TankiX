using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientResources.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class WeaponDetachColliderComponent : WarmableResourceBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private MeshCollider collider;

		[SerializeField]
		private Rigidbody rigidbody;

		public MeshCollider Collider
		{
			get
			{
				return collider;
			}
		}

		public Rigidbody Rigidbody
		{
			get
			{
				return rigidbody;
			}
		}

		public override void WarmUp()
		{
			collider.enabled = true;
		}

		private void Awake()
		{
			rigidbody.detectCollisions = false;
		}
	}
}
