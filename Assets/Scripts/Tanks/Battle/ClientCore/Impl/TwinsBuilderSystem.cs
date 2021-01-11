using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class TwinsBuilderSystem : ECSSystem
	{
		public class WeaponNode : Node
		{
			public BattleGroupComponent battleGroup;

			public UserGroupComponent userGroup;

			public TwinsComponent twins;
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

		public class AutopilotTankNode : Node
		{
			public UserGroupComponent userGroup;

			public TankAutopilotComponent tankAutopilot;

			public AssembledTankComponent assembledTank;
		}

		[OnEventFire]
		public void BuildBot(NodeAddedEvent evt, AutopilotTankNode botTank, [Context][JoinByUser] WeaponNode weaponNode, [Context][JoinByUser] UserNode user)
		{
			BuildWeapon(botTank.Entity, weaponNode);
		}

		[OnEventFire]
		public void BuildSelf(NodeAddedEvent evt, SelfTankNode selfTank, [Context][JoinByUser] WeaponNode weaponNode, [Context][JoinByUser] UserNode user)
		{
			BuildWeapon(selfTank.Entity, weaponNode);
		}

		private void BuildWeapon(Entity tank, WeaponNode weaponNode)
		{
			Entity entity = weaponNode.Entity;
			entity.AddComponent<CooldownTimerComponent>();
			entity.AddComponent<DiscreteWeaponControllerComponent>();
			entity.AddComponent<VerticalTargetingComponent>();
			entity.AddComponent<DirectionEvaluatorComponent>();
			entity.AddComponent<WeaponShotComponent>();
			entity.AddComponent<DistanceAndAngleTargetEvaluatorComponent>();
			TargetCollectorComponent component = new TargetCollectorComponent(new TargetCollector(tank), new TargetValidator(tank));
			entity.AddComponent(component);
		}

		[OnEventFire]
		public void AddTeamEvaluator(NodeAddedEvent evt, WeaponNode weaponNode, [JoinByBattle] SingleNode<TeamBattleComponent> battle)
		{
			weaponNode.Entity.AddComponent<TeamTargetEvaluatorComponent>();
		}

		[OnEventFire]
		public void AddCTFEvaluator(NodeAddedEvent evt, WeaponNode weaponNode, [JoinByBattle] SingleNode<CTFComponent> battle)
		{
			weaponNode.Entity.AddComponent<CTFTargetEvaluatorComponent>();
		}
	}
}
