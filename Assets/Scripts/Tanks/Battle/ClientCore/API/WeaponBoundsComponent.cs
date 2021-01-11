using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class WeaponBoundsComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Bounds WeaponBounds
		{
			get;
			set;
		}

		public WeaponBoundsComponent()
		{
		}

		public WeaponBoundsComponent(Bounds weaponBounds)
		{
			WeaponBounds = weaponBounds;
		}
	}
}
