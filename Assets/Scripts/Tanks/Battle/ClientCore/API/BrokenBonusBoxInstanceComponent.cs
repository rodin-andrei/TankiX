using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class BrokenBonusBoxInstanceComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject Instance
		{
			get;
			set;
		}

		public BrokenBonusBoxInstanceComponent(GameObject instance)
		{
			Instance = instance;
		}
	}
}
