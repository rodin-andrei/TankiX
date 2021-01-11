using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientGarage.Impl;

namespace Tanks.Battle.ClientCore.API
{
	public class TutorialHitTriggersSystem : ECSSystem
	{
		public class SelfTankNode : Node
		{
			public SelfTankComponent selfTank;

			public HealthComponent health;

			public LastHealthComponent lastHealth;
		}

		[OnEventFire]
		public void TankGetHit(HealthChangedEvent e, SelfTankNode selfTank, [JoinAll] SingleNode<TutorialFirstDamageTriggerComponent> firstDamageTrigger)
		{
			if (selfTank.health.CurrentHealth < selfTank.lastHealth.LastHealth)
			{
				firstDamageTrigger.component.GetComponent<TutorialShowTriggerComponent>().Triggered();
			}
		}
	}
}
