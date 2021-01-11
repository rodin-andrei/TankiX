using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientGraphics.Impl;

namespace Tanks.Battle.ClientCore.Impl
{
	public class BonusTakingSystem : ECSSystem
	{
		public class SelfTankNode : Node
		{
			public TankSyncComponent tankSync;

			public TankActiveStateComponent tankActiveState;
		}

		[Not(typeof(BonusActiveStateComponent))]
		public class NotActiveBonusNode : Node
		{
			public BonusComponent bonus;
		}

		[OnEventFire]
		public void TakeBonus(TriggerEnterEvent e, SingleNode<BonusActiveStateComponent> bonus, SelfTankNode tank)
		{
			ScheduleEvent<SendTankMovementEvent>(tank);
			NewEvent<BonusTakingRequestEvent>().Attach(bonus).Attach(tank).Schedule();
		}

		[OnEventComplete]
		public void DestroyBonusBox(BonusTakenEvent e, SingleNode<BonusBoxInstanceComponent> bonus)
		{
			bonus.component.BonusBoxInstance.RecycleObject();
		}
	}
}
