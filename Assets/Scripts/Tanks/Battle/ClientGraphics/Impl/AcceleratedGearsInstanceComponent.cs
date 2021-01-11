using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class AcceleratedGearsInstanceComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject Instance
		{
			get;
			set;
		}

		public AcceleratedGearsInstanceComponent(GameObject instance)
		{
			Instance = instance;
		}
	}
}
