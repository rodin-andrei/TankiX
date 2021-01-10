using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class GetInstanceFromPoolEvent : Event
	{
		public GameObject Prefab;
		public Transform Instance;
		public float AutoRecycleTime;
	}
}
