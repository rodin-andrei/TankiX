using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class BonusParachuteInstanceComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject BonusParachuteInstance
		{
			get;
			set;
		}

		public BonusParachuteInstanceComponent(GameObject bonusParachuteInstance)
		{
			BonusParachuteInstance = bonusParachuteInstance;
		}
	}
}
