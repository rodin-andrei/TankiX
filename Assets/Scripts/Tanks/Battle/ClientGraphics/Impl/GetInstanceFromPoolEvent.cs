using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class GetInstanceFromPoolEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
	{
		public GameObject Prefab;

		public Transform Instance;

		public float AutoRecycleTime = -1f;
	}
}
