using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class FlamethrowerBuilderSystem : ECSSystem
	{
		public class WeaponNode : Node
		{
			public UserGroupComponent userGroup;

			public FlamethrowerComponent flamethrower;

			public BattleGroupComponent battleGroup;
		}

		public class SelfTankNode : Node
		{
			public UserGroupComponent userGroup;

			public SelfTankComponent selfTank;

			public AssembledTankComponent assembledTank;
		}

		[OnEventFire]
		public void BuildSelf(NodeAddedEvent evt, SelfTankNode selfTank, [Context][JoinByUser] WeaponNode weaponNode, [JoinByUser] SingleNode<UserComponent> userNode)
		{
			Entity entity = weaponNode.Entity;
			entity.AddComponent<CooldownTimerComponent>();
			entity.AddComponent<StreamWeaponControllerComponent>();
			entity.AddComponent<ConicTargetingComponent>();
			entity.AddComponent(new WeaponHitComponent(false, true));
			entity.AddComponent(new StreamWeaponSimpleFeedbackControllerComponent());
			TargetCollectorComponent component = new TargetCollectorComponent(new TargetCollector(selfTank.Entity), new PenetrationTargetValidator(selfTank.Entity));
			entity.AddComponent(component);
		}
	}
}
