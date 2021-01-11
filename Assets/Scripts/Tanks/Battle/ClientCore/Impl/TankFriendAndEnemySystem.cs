using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class TankFriendAndEnemySystem : ECSSystem
	{
		[Not(typeof(EnemyComponent))]
		public class RemoteTankNode : Node
		{
			public RemoteTankComponent remoteTank;

			public BattleGroupComponent battleGroup;
		}

		public class TeamTankNode : RemoteTankNode
		{
			public TeamGroupComponent teamGroup;
		}

		public class SelfBattleUserNode : Node
		{
			public SelfBattleUserComponent selfBattleUser;

			public BattleGroupComponent battleGroup;
		}

		public class SelfBattleUserAsTank : SelfBattleUserNode
		{
			public UserInBattleAsTankComponent userInBattleAsTank;

			public TeamGroupComponent teamGroup;
		}

		public class SelfBattleUserAsSpectator : SelfBattleUserNode
		{
			public UserInBattleAsSpectatorComponent userInBattleAsSpectator;
		}

		[OnEventFire]
		public void SetSelfTankAsDefined(NodeAddedEvent e, SingleNode<SelfTankComponent> tank)
		{
			tank.Entity.AddComponent<TankFriendlyEnemyStatusDefinedComponent>();
		}

		[OnEventFire]
		public void AddEnemyComponent(NodeAddedEvent e, [Combine] RemoteTankNode tank, [JoinByBattle] SingleNode<DMComponent> dmBattle)
		{
			tank.Entity.AddComponent<EnemyComponent>();
			tank.Entity.AddComponent<TankFriendlyEnemyStatusDefinedComponent>();
		}

		[OnEventFire]
		public void AddEnemyComponent(NodeAddedEvent e, [Combine] TeamTankNode tank, [Context][JoinByBattle] SelfBattleUserAsTank userAsTank)
		{
			if (!tank.teamGroup.Key.Equals(userAsTank.teamGroup.Key))
			{
				tank.Entity.AddComponent<EnemyComponent>();
			}
			tank.Entity.AddComponent<TankFriendlyEnemyStatusDefinedComponent>();
		}

		[OnEventFire]
		public void DefineForSpec(NodeAddedEvent e, [Combine] RemoteTankNode tank, [Context][JoinByBattle] SelfBattleUserAsSpectator userAsSpectator)
		{
			tank.Entity.AddComponent<TankFriendlyEnemyStatusDefinedComponent>();
		}
	}
}
