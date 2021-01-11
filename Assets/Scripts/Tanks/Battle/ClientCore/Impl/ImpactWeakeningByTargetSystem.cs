using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class ImpactWeakeningByTargetSystem : AbstractImpactSystem
	{
		public class ImpactNode : Node
		{
			public ImpactComponent impact;

			public DamageWeakeningByTargetComponent damageWeakeningByTarget;
		}

		[OnEventFire]
		public void PrepareImpactOnHit(HitEvent evt, ImpactNode weapon)
		{
			ImpactComponent impact = weapon.impact;
			DamageWeakeningByTargetComponent damageWeakeningByTarget = weapon.damageWeakeningByTarget;
			ApplyImpactByTargetWeakening(weapon.Entity, evt.Targets, impact.ImpactForce, damageWeakeningByTarget.DamagePercent);
		}
	}
}
