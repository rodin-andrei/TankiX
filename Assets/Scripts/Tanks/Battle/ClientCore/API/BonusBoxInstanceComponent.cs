using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class BonusBoxInstanceComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject BonusBoxInstance
		{
			get;
			set;
		}

		public bool Removed
		{
			get;
			set;
		}
	}
}
