using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateWeaponStreamHitGraphicsByTargetTankEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
	{
		public ParticleSystem HitTargetParticleSystem
		{
			get;
			set;
		}

		public Light HitTargetLight
		{
			get;
			set;
		}

		public HitTarget TankHit
		{
			get;
			set;
		}

		public float HitOffset
		{
			get;
			set;
		}
	}
}
