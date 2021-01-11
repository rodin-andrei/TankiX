using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class HammerShotAnimationSystem : ECSSystem
	{
		public class InitialHammerShotAnimationNode : Node
		{
			public MagazineWeaponComponent magazineWeapon;

			public MagazineStorageComponent magazineStorage;

			public MagazineLocalStorageComponent magazineLocalStorage;

			public AnimationComponent animation;

			public AnimationPreparedComponent animationPrepared;

			public HammerShotAnimationComponent hammerShotAnimation;

			public WeaponCooldownComponent weaponCooldown;

			public TankGroupComponent tankGroup;
		}

		public class ReadyHammerShotAnimationNode : Node
		{
			public MagazineWeaponComponent magazineWeapon;

			public MagazineStorageComponent magazineStorage;

			public MagazineLocalStorageComponent magazineLocalStorage;

			public HammerShotAnimationComponent hammerShotAnimation;

			public HammerShotAnimationReadyComponent hammerShotAnimationReady;

			public TankGroupComponent tankGroup;
		}

		public class ActiveTankNode : Node
		{
			public TankActiveStateComponent tankActiveState;

			public TankGroupComponent tankGroup;
		}

		[OnEventFire]
		public void InitHammerShotAnimation(NodeAddedEvent evt, InitialHammerShotAnimationNode weapon)
		{
			Animator animator = weapon.animation.Animator;
			float cooldownIntervalSec = weapon.weaponCooldown.CooldownIntervalSec;
			Entity entity = weapon.Entity;
			weapon.hammerShotAnimation.InitHammerShotAnimation(entity, animator, weapon.magazineWeapon.ReloadMagazineTimePerSec, cooldownIntervalSec);
			entity.AddComponent<HammerShotAnimationReadyComponent>();
		}

		[OnEventFire]
		public void PlayShot(BaseShotEvent evt, ReadyHammerShotAnimationNode weapon, [JoinByTank] ActiveTankNode tank)
		{
			if (weapon.magazineLocalStorage.CurrentCartridgeCount > 1)
			{
				weapon.hammerShotAnimation.PlayShot();
			}
			else
			{
				weapon.hammerShotAnimation.PlayShotAndReload();
			}
		}

		[OnEventComplete]
		public void Reset(NodeRemoveEvent evt, ActiveTankNode tank, [JoinByTank] ReadyHammerShotAnimationNode weapon)
		{
			weapon.hammerShotAnimation.Reset();
		}

		[OnEventFire]
		public void Reset(ExecuteEnergyInjectionEvent e, ReadyHammerShotAnimationNode weapon)
		{
			weapon.hammerShotAnimation.Reset();
		}
	}
}
