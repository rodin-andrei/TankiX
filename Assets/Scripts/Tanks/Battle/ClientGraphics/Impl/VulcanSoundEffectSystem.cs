using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Battle.ClientGraphics.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class VulcanSoundEffectSystem : ECSSystem
	{
		public class VulcanAllSoundEffectsNode : Node
		{
			public AnimationPreparedComponent animationPrepared;

			public VulcanWeaponComponent vulcanWeapon;

			public VulcanAfterShootingSoundEffectComponent vulcanAfterShootingSoundEffect;

			public VulcanChainStartSoundEffectComponent vulcanChainStartSoundEffect;

			public VulcanTurbineSoundEffectComponent vulcanTurbineSoundEffect;

			public VulcanSlowDownAfterSpeedUpSoundEffectComponent vulcanSlowDownAfterSpeedUpSoundEffect;

			public WeaponSoundRootComponent weaponSoundRoot;
		}

		public class VulcanShootingNode : Node
		{
			public WeaponStreamShootingComponent weaponStreamShooting;

			public VulcanSoundManagerComponent vulcanSoundManager;
		}

		public class VulcanSpeedUpNode : Node
		{
			public VulcanWeaponComponent vulcanWeapon;

			public VulcanWeaponStateComponent vulcanWeaponState;

			public VulcanSpeedUpComponent vulcanSpeedUp;

			public VulcanSoundManagerComponent vulcanSoundManager;

			public VulcanChainStartSoundEffectComponent vulcanChainStartSoundEffect;

			public VulcanTurbineSoundEffectComponent vulcanTurbineSoundEffect;

			public VulcanSlowDownAfterSpeedUpSoundEffectComponent vulcanSlowDownAfterSpeedUpSoundEffect;
		}

		public class VulcanIdleStateNode : Node
		{
			public VulcanIdleComponent vulcanIdle;

			public VulcanSoundManagerComponent vulcanSoundManager;
		}

		public class VulcanAfterShootingSoundNode : Node
		{
			public VulcanAfterShootingSoundEffectComponent vulcanAfterShootingSoundEffect;

			public WeaponStreamShootingComponent weaponStreamShooting;

			public VulcanSoundManagerComponent vulcanSoundManager;
		}

		public class VulcanSlowDownNode : Node
		{
			public VulcanWeaponComponent vulcanWeapon;

			public VulcanWeaponStateComponent vulcanWeaponState;

			public VulcanSlowDownComponent vulcanSlowDown;

			public VulcanSlowDownAfterSpeedUpSoundEffectComponent vulcanSlowDownAfterSpeedUpSoundEffect;

			public VulcanSoundManagerComponent vulcanSoundManager;
		}

		[OnEventFire]
		public void InitEffects(NodeAddedEvent evt, [Combine] VulcanAllSoundEffectsNode weapon, SingleNode<SoundListenerBattleStateComponent> soundListener)
		{
			Transform transform = weapon.weaponSoundRoot.transform;
			VulcanSoundManagerComponent vulcanSoundManagerComponent = new VulcanSoundManagerComponent();
			InitSoundEffect(weapon.vulcanAfterShootingSoundEffect, vulcanSoundManagerComponent, transform);
			InitSoundEffect(weapon.vulcanChainStartSoundEffect, vulcanSoundManagerComponent, transform);
			InitSoundEffect(weapon.vulcanSlowDownAfterSpeedUpSoundEffect, vulcanSoundManagerComponent, transform);
			InitSoundEffect(weapon.vulcanTurbineSoundEffect, vulcanSoundManagerComponent, transform);
			float length = weapon.vulcanTurbineSoundEffect.SoundSource.clip.length;
			float speedUpTime = weapon.vulcanWeapon.SpeedUpTime;
			weapon.vulcanTurbineSoundEffect.StartTimePerSec = length - speedUpTime;
			weapon.vulcanTurbineSoundEffect.SoundSource.time = weapon.vulcanTurbineSoundEffect.StartTimePerSec;
			weapon.Entity.AddComponent(vulcanSoundManagerComponent);
		}

		[OnEventFire]
		public void StopCurrentSoundOnIdleState(NodeAddedEvent evt, VulcanIdleStateNode weapon)
		{
			StopCurrentSound(weapon.vulcanSoundManager);
		}

		[OnEventFire]
		public void PlaySpeedUpSounds(NodeAddedEvent evt, VulcanSpeedUpNode weapon)
		{
			AudioSource soundSource = weapon.vulcanTurbineSoundEffect.SoundSource;
			AudioSource soundSource2 = weapon.vulcanChainStartSoundEffect.SoundSource;
			VulcanSoundManagerComponent vulcanSoundManager = weapon.vulcanSoundManager;
			weapon.vulcanSlowDownAfterSpeedUpSoundEffect.AdditionalStartTimeOffset = weapon.vulcanWeapon.SpeedUpTime * (1f - weapon.vulcanWeaponState.State);
			PlayNextSound(soundSource, vulcanSoundManager);
			PlaySound(soundSource2, vulcanSoundManager);
		}

		[OnEventFire]
		public void PlayShootingProcessEffect(NodeAddedEvent evt, VulcanShootingNode weapon)
		{
			PlayNextSound(null, weapon.vulcanSoundManager);
		}

		[OnEventFire]
		public void PlaySoundAfterShooting(NodeRemoveEvent evt, VulcanAfterShootingSoundNode weapon)
		{
			AudioSource soundSource = weapon.vulcanAfterShootingSoundEffect.SoundSource;
			PlayNextSound(soundSource, weapon.vulcanSoundManager);
		}

		[OnEventFire]
		public void PlaySlowDownSound(NodeAddedEvent evt, VulcanSlowDownNode weapon)
		{
			if (!weapon.vulcanSlowDown.IsAfterShooting)
			{
				AudioSource soundSource = weapon.vulcanSlowDownAfterSpeedUpSoundEffect.SoundSource;
				float num2 = (soundSource.time = weapon.vulcanSlowDownAfterSpeedUpSoundEffect.StartTimePerSec + weapon.vulcanSlowDownAfterSpeedUpSoundEffect.AdditionalStartTimeOffset);
				VulcanFadeSoundBehaviour component = soundSource.gameObject.GetComponent<VulcanFadeSoundBehaviour>();
				component.fadeDuration = weapon.vulcanWeaponState.State * weapon.vulcanWeapon.SlowDownTime;
				component.enabled = true;
				PlayNextSound(soundSource, weapon.vulcanSoundManager);
			}
		}

		private void InitSoundEffect(AbstractVulcanSoundEffectComponent soundEffectComponent, VulcanSoundManagerComponent soundManagerComponent, Transform soundRoot)
		{
			GameObject gameObject = Object.Instantiate(soundEffectComponent.EffectPrefab);
			gameObject.transform.parent = soundRoot;
			gameObject.transform.localPosition = Vector3.zero;
			AudioSource audioSource = (soundEffectComponent.SoundSource = gameObject.GetComponent<AudioSource>());
			audioSource.time = soundEffectComponent.StartTimePerSec;
			soundManagerComponent.SoundsWithDelay.Add(audioSource, soundEffectComponent.DelayPerSec);
		}

		private void PlayNextSound(AudioSource sound, VulcanSoundManagerComponent manager)
		{
			StopCurrentSound(manager);
			if (!(sound == null))
			{
				manager.CurrentSound = sound;
				PlaySound(sound, manager);
			}
		}

		private void PlaySound(AudioSource sound, VulcanSoundManagerComponent manager)
		{
			sound.PlayDelayed(manager.SoundsWithDelay[sound]);
		}

		private void StopCurrentSound(VulcanSoundManagerComponent manager)
		{
			if (!(manager.CurrentSound == null))
			{
				manager.CurrentSound.Stop();
			}
		}
	}
}
