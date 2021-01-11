using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientGraphics.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TankExplosionSoundSystem : ECSSystem
	{
		public class TankExplosionNode : Node
		{
			public TankDeadStateComponent tankDeadState;

			public TankExplosionSoundComponent tankExplosionSound;

			public AssembledTankActivatedStateComponent assembledTankActivatedState;
		}

		[OnEventFire]
		public void PlayDeathSound(NodeAddedEvent evt, TankExplosionNode tank, [JoinAll] SingleNode<SoundListenerBattleStateComponent> soundListener)
		{
			tank.tankExplosionSound.Sound.Play();
		}
	}
}
