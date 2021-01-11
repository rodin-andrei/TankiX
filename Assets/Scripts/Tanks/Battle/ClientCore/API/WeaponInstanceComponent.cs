using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class WeaponInstanceComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject WeaponInstance
		{
			get;
			set;
		}

		public WeaponInstanceComponent()
		{
		}

		public WeaponInstanceComponent(GameObject weaponInstance)
		{
			WeaponInstance = weaponInstance;
		}
	}
}
