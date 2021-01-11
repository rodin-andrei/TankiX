using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientGraphics.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class CaseSoundEffectSystem : ECSSystem
	{
		public class InitialCaseEjectionSoundEffectNode : Node
		{
			public CaseEjectionSoundEffectComponent caseEjectionSoundEffect;

			public WeaponSoundRootComponent weaponSoundRoot;

			public AnimationPreparedComponent animationPrepared;

			public TankGroupComponent tankGroup;
		}

		public class ReadyCaseEjectionSoundEffectNode : Node
		{
			public CaseEjectionSoundEffectComponent caseEjectionSoundEffect;

			public CaseEjectionSoundEffectReadyComponent caseEjectionSoundEffectReady;

			public WeaponSoundRootComponent weaponSoundRoot;

			public TankGroupComponent tankGroup;
		}

		public class InitialCaseEjectorMovementSoundEffectNode : Node
		{
			public CaseEjectorOpeningSoundEffectComponent caseEjectorOpeningSoundEffect;

			public CaseEjectorClosingSoundEffectComponent caseEjectorClosingSoundEffect;

			public CaseEjectorMovementTriggerComponent caseEjectorMovementTrigger;

			public WeaponSoundRootComponent weaponSoundRoot;

			public TankGroupComponent tankGroup;
		}

		public class ReadyCaseEjectorMovementSoundEffectNode : Node
		{
			public CaseEjectorOpeningSoundEffectComponent caseEjectorOpeningSoundEffect;

			public CaseEjectorClosingSoundEffectComponent caseEjectorClosingSoundEffect;

			public CaseEjectorMovementSoundEffectReadyComponent caseEjectorMovementSoundEffectReady;

			public WeaponSoundRootComponent weaponSoundRoot;

			public TankGroupComponent tankGroup;
		}

		[OnEventFire]
		public void InitCaseEjectionSound(NodeAddedEvent evt, [Combine] InitialCaseEjectionSoundEffectNode weapon, SingleNode<SoundListenerBattleStateComponent> soundListener)
		{
			Transform transform = weapon.weaponSoundRoot.gameObject.transform;
			PrepareCaseSoundEffect(weapon.caseEjectionSoundEffect, transform);
			if (!weapon.Entity.HasComponent<CaseEjectionSoundEffectReadyComponent>())
			{
				weapon.Entity.AddComponent<CaseEjectionSoundEffectReadyComponent>();
			}
		}

		[OnEventFire]
		public void PlayCaseEjectionSound(CartridgeCaseEjectionEvent evt, ReadyCaseEjectionSoundEffectNode weapon)
		{
			weapon.caseEjectionSoundEffect.Source.Play();
		}

		[OnEventFire]
		public void InitCaseEjectorMovementEffects(NodeAddedEvent evt, [Combine] InitialCaseEjectorMovementSoundEffectNode weapon, SingleNode<SoundListenerBattleStateComponent> soundListener)
		{
			Transform transform = weapon.weaponSoundRoot.gameObject.transform;
			PrepareCaseSoundEffect(weapon.caseEjectorOpeningSoundEffect, transform);
			PrepareCaseSoundEffect(weapon.caseEjectorClosingSoundEffect, transform);
			Entity entity = weapon.Entity;
			weapon.caseEjectorMovementTrigger.Entity = entity;
			if (!entity.HasComponent<CaseEjectorMovementSoundEffectReadyComponent>())
			{
				entity.AddComponent<CaseEjectorMovementSoundEffectReadyComponent>();
			}
		}

		[OnEventFire]
		public void PlayEjectorOpeningEffect(CaseEjectorOpenEvent evt, ReadyCaseEjectorMovementSoundEffectNode weapon)
		{
			weapon.caseEjectorClosingSoundEffect.Source.Stop();
			weapon.caseEjectorOpeningSoundEffect.Source.Play();
		}

		[OnEventFire]
		public void PlayEjectorClosingEffect(CaseEjectorCloseEvent evt, ReadyCaseEjectorMovementSoundEffectNode weapon)
		{
			weapon.caseEjectorOpeningSoundEffect.Source.Stop();
			weapon.caseEjectorClosingSoundEffect.Source.Play();
		}

		private void PrepareCaseSoundEffect(CaseSoundEffectComponent caseSoundEffect, Transform root)
		{
			GameObject caseSoundAsset = caseSoundEffect.CaseSoundAsset;
			AudioSource audioSource2 = (caseSoundEffect.Source = InstantiateCaseSoundEffect(caseSoundAsset, root));
		}

		private AudioSource InstantiateCaseSoundEffect(GameObject prefab, Transform root)
		{
			GameObject gameObject = Object.Instantiate(prefab);
			gameObject.transform.parent = root;
			gameObject.transform.localPosition = Vector3.zero;
			return gameObject.GetComponent<AudioSource>();
		}
	}
}
