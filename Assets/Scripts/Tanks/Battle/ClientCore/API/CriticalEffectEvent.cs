using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class CriticalEffectEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
	{
		public GameObject EffectPrefab
		{
			get;
			set;
		}

		public Vector3 LocalPosition
		{
			get;
			set;
		}
	}
}
