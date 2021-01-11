using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Battle.ClientGraphics.Impl;

namespace tanks.modules.battle.ClientCore.Scripts.Impl.Tank.Effect.Kamikadze
{
	public class KamikadzeEffectSystem : ECSSystem
	{
		public class KamikadzeEffectNode : Node
		{
			public KamikadzeEffectComponent kamikadzeEffect;
		}

		public class SelfTankNode : Node
		{
			public SelfTankComponent selfTank;

			public AssembledTankActivatedStateComponent assembledTankActivatedState;

			public TankActiveStateComponent tankActiveState;

			public RigidbodyComponent rigidbody;

			public ModuleVisualEffectObjectsComponent moduleVisualEffectObjects;
		}

		[OnEventFire]
		public void EnableEffect(SelfTankExplosionEvent e, SelfTankNode selfTank, [JoinByTank] KamikadzeEffectNode effectNode)
		{
			ScheduleEvent<StartSplashEffectEvent>(effectNode);
		}
	}
}
