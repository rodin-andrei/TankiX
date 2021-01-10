using Platform.Library.ClientResources.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class WeaponDetachColliderComponent : WarmableResourceBehaviour
	{
		[SerializeField]
		private MeshCollider collider;
		[SerializeField]
		private Rigidbody rigidbody;
	}
}
