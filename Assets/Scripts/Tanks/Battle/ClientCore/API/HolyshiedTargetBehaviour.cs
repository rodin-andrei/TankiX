using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientCore.API
{
	public class HolyshiedTargetBehaviour : TargetBehaviour
	{
		public override bool CanSkip(Entity targetingOwner)
		{
			if (base.TargetEntity.IsSameGroup<TeamGroupComponent>(targetingOwner))
			{
				return true;
			}
			return false;
		}

		public override bool AcceptAsTarget(Entity targetingOwner)
		{
			return false;
		}
	}
}
