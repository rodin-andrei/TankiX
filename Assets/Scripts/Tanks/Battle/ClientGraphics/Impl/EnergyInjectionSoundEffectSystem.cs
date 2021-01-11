using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class EnergyInjectionSoundEffectSystem : ECSSystem
	{
		public class SelfTankNode : Node
		{
			public SelfTankComponent selfTank;

			public AssembledTankActivatedStateComponent assembledTankActivatedState;

			public EnergyInjectionSoundEffectComponent energyInjectionSoundEffect;
		}

		[OnEventFire]
		public void PlayEnergyInjectionSoundEffect(ExecuteEnergyInjectionEvent e, SingleNode<EnergyInjectionEffectComponent> effect, [JoinByTank] SelfTankNode tank)
		{
			tank.energyInjectionSoundEffect.Sound.StopImmediately();
			tank.energyInjectionSoundEffect.Sound.FadeIn();
		}
	}
}
