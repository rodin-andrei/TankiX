using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShotAnimationSystem : ECSSystem
	{
		public class InitialShotAnimationNode : Node
		{
			public TankGroupComponent tankGroup;

			public AnimationComponent animation;

			public ShotAnimationComponent shotAnimation;

			public AnimationPreparedComponent animationPrepared;

			public WeaponCooldownComponent weaponCooldown;

			public DiscreteWeaponEnergyComponent discreteWeaponEnergy;
		}

		public class ReadyShotAnimationNode : Node
		{
			public TankGroupComponent tankGroup;

			public AnimationComponent animation;

			public ShotAnimationComponent shotAnimation;

			public ShotAnimationReadyComponent shotAnimationReady;

			public AnimationPreparedComponent animationPrepared;
		}

		[OnEventFire]
		public void InitShotAnimation(NodeAddedEvent e, InitialShotAnimationNode weapon)
		{
			Animator animator = weapon.animation.Animator;
			float cooldownIntervalSec = weapon.weaponCooldown.CooldownIntervalSec;
			float unloadEnergyPerShot = weapon.discreteWeaponEnergy.UnloadEnergyPerShot;
			float reloadEnergyPerSec = weapon.discreteWeaponEnergy.ReloadEnergyPerSec;
			weapon.shotAnimation.Init(animator, cooldownIntervalSec, unloadEnergyPerShot, reloadEnergyPerSec);
			weapon.Entity.AddComponent<ShotAnimationReadyComponent>();
		}

		[OnEventFire]
		public void StartShotAnimation(BaseShotEvent evt, ReadyShotAnimationNode weapon)
		{
			weapon.shotAnimation.Play();
		}
	}
}
