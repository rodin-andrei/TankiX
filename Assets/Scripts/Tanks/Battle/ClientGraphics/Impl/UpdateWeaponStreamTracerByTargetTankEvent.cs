using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateWeaponStreamTracerByTargetTankEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
	{
		public GameObject WeaponStreamTracerInstance
		{
			get;
			set;
		}

		public WeaponStreamTracerBehaviour WeaponStreamTracerBehaviour
		{
			get;
			set;
		}

		public HitTarget Hit
		{
			get;
			set;
		}
	}
}
