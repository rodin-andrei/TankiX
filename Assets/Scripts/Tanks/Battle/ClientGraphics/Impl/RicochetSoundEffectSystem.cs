using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Battle.ClientGraphics.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class RicochetSoundEffectSystem : ECSSystem
	{
		public class RicochetSoundEffectNode : Node
		{
			public RicochetBounceSoundEffectComponent ricochetBounceSoundEffect;

			public RicochetTargetHitSoundEffectComponent ricochetTargetHitSoundEffect;

			public TankGroupComponent tankGroup;

			public AnimationPreparedComponent animationPrepared;
		}

		public class BulletNode : Node
		{
			public TankGroupComponent tankGroup;

			public RicochetBulletComponent ricochetBullet;
		}

		[OnEventFire]
		public void InstantiateEffectOnStaticHit(RicochetBulletBounceEvent e, BulletNode bullet, [JoinByTank] RicochetSoundEffectNode weapon, [JoinAll] SingleNode<SoundListenerBattleStateComponent> soundListener)
		{
			Vector3 worldSpaceBouncePosition = e.WorldSpaceBouncePosition;
			weapon.ricochetBounceSoundEffect.PlayEffect(worldSpaceBouncePosition);
		}

		[OnEventFire]
		public void InstantiateEffectOnTargetHit(BulletHitEvent e, BulletNode bullet, [JoinByTank] RicochetSoundEffectNode weapon, [JoinAll] SingleNode<SoundListenerBattleStateComponent> soundListener)
		{
			Vector3 position = e.Position;
			weapon.ricochetTargetHitSoundEffect.PlayEffect(position);
		}
	}
}
