using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class BonusRegionInstanceComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject BonusRegionInstance
		{
			get;
			set;
		}

		public BonusRegionInstanceComponent()
		{
		}

		public BonusRegionInstanceComponent(GameObject bonusRegionInstance)
		{
			BonusRegionInstance = bonusRegionInstance;
		}
	}
}
