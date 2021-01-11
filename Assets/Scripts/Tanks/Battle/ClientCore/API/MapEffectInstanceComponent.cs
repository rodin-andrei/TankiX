using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class MapEffectInstanceComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject Instance
		{
			get;
			set;
		}

		public MapEffectInstanceComponent(GameObject instance)
		{
			Instance = instance;
		}
	}
}
