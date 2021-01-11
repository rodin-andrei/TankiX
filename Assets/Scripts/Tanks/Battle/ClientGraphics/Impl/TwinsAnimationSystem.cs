using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TwinsAnimationSystem : ECSSystem
	{
		public class InitialTwinsAnimationNode : Node
		{
			public TwinsAnimationComponent twinsAnimation;

			public MuzzlePointComponent muzzlePoint;

			public AnimationComponent animation;

			public AnimationPreparedComponent animationPrepared;

			public WeaponCooldownComponent weaponCooldown;

			public DiscreteWeaponEnergyComponent discreteWeaponEnergy;
		}

		public class ReadyTwinsAnimationNode : Node
		{
			public TwinsAnimationComponent twinsAnimation;

			public TwinsAnimationReadyComponent twinsAnimationReady;

			public MuzzlePointComponent muzzlePoint;

			public AnimationComponent animation;

			public AnimationPreparedComponent animationPrepared;
		}

		[OnEventFire]
		public void InitTwinsAnimation(NodeAddedEvent evt, InitialTwinsAnimationNode weapon)
		{
			Animator animator = weapon.animation.Animator;
			float cooldownIntervalSec = weapon.weaponCooldown.CooldownIntervalSec;
			float unloadEnergyPerShot = weapon.discreteWeaponEnergy.UnloadEnergyPerShot;
			float reloadEnergyPerSec = weapon.discreteWeaponEnergy.ReloadEnergyPerSec;
			weapon.twinsAnimation.Init(animator, cooldownIntervalSec, unloadEnergyPerShot, reloadEnergyPerSec);
			weapon.Entity.AddComponent<TwinsAnimationReadyComponent>();
		}

		[OnEventFire]
		public void PlayTwinsShotAnimation(BaseShotEvent evt, ReadyTwinsAnimationNode weapon)
		{
			int currentIndex = new MuzzleVisualAccessor(weapon.muzzlePoint).GetCurrentIndex();
			weapon.twinsAnimation.Play(currentIndex);
		}
	}
}
