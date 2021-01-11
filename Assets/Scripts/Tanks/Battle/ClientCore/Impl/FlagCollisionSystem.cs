using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class FlagCollisionSystem : ECSSystem
	{
		public class TankNode : Node
		{
			public TankComponent tank;

			public TankActiveStateComponent tankActiveState;

			public TeamGroupComponent teamGroup;

			public TankSyncComponent tankSync;

			public BattleGroupComponent battleGroup;
		}

		public class FlagNode : Node
		{
			public FlagComponent flag;

			public FlagInstanceComponent flagInstance;

			public TeamGroupComponent teamGroup;

			public FlagColliderComponent flagCollider;

			public BattleGroupComponent battleGroup;
		}

		[OnEventFire]
		public void SendCollisionEvent(TankFlagCollisionEvent e, TankNode tank, [JoinByBattle] SingleNode<RoundActiveStateComponent> round, [Context][JoinByBattle] FlagNode flag)
		{
			ScheduleEvent<SendTankMovementEvent>(tank);
			NewEvent<FlagCollisionRequestEvent>().Attach(tank).Attach(flag).Schedule();
		}
	}
}
