using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class TankCommonInstanceComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject TankCommonInstance
		{
			get;
			set;
		}

		public TankCommonInstanceComponent()
		{
		}

		public TankCommonInstanceComponent(GameObject tankCommonInstance)
		{
			TankCommonInstance = tankCommonInstance;
		}
	}
}
