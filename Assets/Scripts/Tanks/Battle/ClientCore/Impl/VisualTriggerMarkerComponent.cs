using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class VisualTriggerMarkerComponent : MonoBehaviour
	{
		[SerializeField]
		private MeshCollider visualTriggerMeshCollider;

		public MeshCollider VisualTriggerMeshCollider
		{
			get
			{
				return visualTriggerMeshCollider;
			}
		}
	}
}
