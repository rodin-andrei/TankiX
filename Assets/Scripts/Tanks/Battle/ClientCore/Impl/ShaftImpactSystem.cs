using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class ShaftImpactSystem : AbstractImpactSystem
	{
		public class ShaftAimingImpactNode : Node
		{
			public ShaftAimingImpactComponent shaftAimingImpact;

			public ImpactComponent impact;
		}

		[OnEventFire]
		public void ApplyBaseHitImpact(HitEvent evt, ShaftAimingImpactNode weapon)
		{
			ImpactComponent impact = weapon.impact;
			List<HitTarget> targets = evt.Targets;
			int count = targets.Count;
			float impactForce = impact.ImpactForce;
			for (int i = 0; i < count; i++)
			{
				HitTarget target = targets[i];
				PrepareImpactForHitTarget(weapon.Entity, target, impactForce);
			}
		}

		[OnEventFire]
		public void MakeAimingHitImpact(SelfShaftAimingHitEvent evt, ShaftAimingImpactNode weapon)
		{
			MakeImpactOnAnyAimingShot(evt.HitPower, evt.Targets, weapon);
		}

		[OnEventFire]
		public void MakeAimingHitImpact(RemoteShaftAimingHitEvent evt, ShaftAimingImpactNode weapon)
		{
			MakeImpactOnAnyAimingShot(evt.HitPower, evt.Targets, weapon);
		}

		private void MakeImpactOnAnyAimingShot(float aimingHitPower, List<HitTarget> targets, ShaftAimingImpactNode weapon)
		{
			float impactForce = weapon.impact.ImpactForce;
			float maxImpactForce = weapon.shaftAimingImpact.MaxImpactForce;
			float maxImpactForce2 = (maxImpactForce - impactForce) * aimingHitPower;
			int count = targets.Count;
			for (int i = 0; i < count; i++)
			{
				HitTarget target = targets[i];
				PrepareImpactForHitTarget(weapon.Entity, target, maxImpactForce2);
			}
		}
	}
}
