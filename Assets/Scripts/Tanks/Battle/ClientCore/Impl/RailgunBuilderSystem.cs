using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class RailgunBuilderSystem : ECSSystem
	{
		public class WeaponNode : Node
		{
			public UserGroupComponent userGroup;

			public RailgunComponent railgun;

			public RailgunChargingWeaponComponent railgunChargingWeapon;

			public BattleGroupComponent battleGroup;
		}

		public class SelfTankNode : Node
		{
			public UserGroupComponent userGroup;

			public SelfTankComponent selfTank;

			public AssembledTankComponent assembledTank;
		}

		public class TankNode : Node
		{
			public UserGroupComponent userGroup;

			public TankComponent tank;

			public AssembledTankComponent assembledTank;
		}

		public class AutopilotTankNode : Node
		{
			public UserGroupComponent userGroup;

			public TankAutopilotComponent tankAutopilot;

			public AssembledTankComponent assembledTank;
		}

		[OnEventFire]
		public void BuildSelf(NodeAddedEvent evt, SelfTankNode selfTank, [Context][JoinByUser] WeaponNode weaponNode, [JoinByUser] SingleNode<UserComponent> userNode)
		{
			BuildWeapon(selfTank.Entity, weaponNode);
		}

		private void BuildWeapon(Entity tank, WeaponNode weaponNode)
		{
			Entity entity = weaponNode.Entity;
			entity.AddComponent<CooldownTimerComponent>();
			entity.AddComponent<ChargingWeaponControllerComponent>();
			entity.AddComponent<ReadyRailgunChargingWeaponComponent>();
			entity.AddComponent<VerticalSectorsTargetingComponent>();
			entity.AddComponent<DirectionEvaluatorComponent>();
			entity.AddComponent<WeaponShotComponent>();
			entity.AddComponent(new WeaponHitComponent(true, false));
			entity.AddComponent<DistanceAndAngleTargetEvaluatorComponent>();
		}

		[OnEventFire]
		public void BuildAll(NodeAddedEvent evt, TankNode selfTank, [Context][JoinByUser] WeaponNode weaponNode)
		{
			Entity entity = weaponNode.Entity;
			TargetCollectorComponent component = new TargetCollectorComponent(new TargetCollector(selfTank.Entity), new PenetrationTargetValidator(selfTank.Entity));
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
