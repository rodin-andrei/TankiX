using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientCore.API
{
	public class ForcefieldTargetBehaviour : TargetBehaviour
	{
		public bool OwnerTeamCanShootThrough;

		public override bool CanSkip(Entity targetingOwner)
		{
			return CheckCanSkip(targetingOwner);
		}

		public override bool AcceptAsTarget(Entity targetingOwner)
		{
			return false;
		}

		private bool CheckCanSkip(Entity targetingOwner)
		{
			return OwnerTeamCanShootThrough && (base.TargetEntity.IsSameGroup<TankGroupComponent>(targetingOwner) || base.TargetEntity.IsSameGroup<TeamGroupComponent>(targetingOwner));
		}
	}
}
