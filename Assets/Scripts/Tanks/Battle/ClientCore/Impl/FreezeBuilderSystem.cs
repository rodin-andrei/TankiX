using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class FreezeBuilderSystem : ECSSystem
	{
		public class WeaponNode : Node
		{
			public UserGroupComponent userGroup;

			public FreezeComponent freeze;

			public BattleGroupComponent battleGroup;
		}

		public class SelfTankNode : Node
		{
			public UserGroupComponent userGroup;

			public SelfTankComponent selfTank;

			public AssembledTankComponent assembledTank;
		}

		public class UserNode : Node
		{
			public UserGroupComponent userGroup;

			public UserComponent user;
		}

		[OnEventFire]
		public void BuildSelf(NodeAddedEvent evt, SelfTankNode selfTank, [Context][JoinByUser] WeaponNode weaponNode, [Context][JoinByUser] UserNode user)
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
