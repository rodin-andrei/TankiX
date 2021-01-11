using System.Collections;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientGraphics.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	[RequireComponent(typeof(Animator))]
	public class DoubleArmorEffectComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject effectPrefab;

		public Transform effectPoints;

		public float effectTime = 2f;

		public ArmorSoundEffectComponent soundEffect;

		[SerializeField]
		public bool changeEmission;

		public Color emissionColor;

		public Renderer renderer;

		private ParticleSystem[] effectInstances;

		private SupplyAnimationPlayer animationPlayer;

		[HideInInspector]
		public Color usualEmissionColor;

		private Material mainMaterial;

		private void Awake()
		{
			effectInstances = SupplyEffectUtil.InstantiateEffect(effectPrefab, effectPoints);
			animationPlayer = new SupplyAnimationPlayer(GetComponent<Animator>(), AnimationParameters.ARMOR_ACTIVE);
			soundEffect.Init(base.transform);
			if (changeEmission)
			{
				mainMaterial = TankMaterialsUtil.GetMainMaterial(renderer);
				usualEmissionColor = mainMaterial.GetColor("_EmissionColor");
			}
		}

		public void Play()
		{
			animationPlayer.StartAnimation();
		}

		public void Stop()
		{
			animationPlayer.StopAnimation();
		}

		private void OnArmorStart()
		{
			StartCoroutine(PlayTransitionCoroutine());
			soundEffect.BeginEffect();
			if (changeEmission)
			{
				mainMaterial.SetColor("_EmissionColor", emissionColor);
			}
		}

		private void OnArmorStop()
		{
			soundEffect.StopEffect();
			if (changeEmission)
			{
				mainMaterial.SetColor("_EmissionColor", usualEmissionColor);
			}
		}

		private IEnumerator PlayTransitionCoroutine()
		{
			for (int i = 0; i < effectInstances.Length; i++)
			{
				effectInstances[i].Play(true);
			}
			yield return new WaitForSeconds(effectTime);
			for (int j = 0; j < effectInstances.Length; j++)
			{
				effectInstances[j].Stop(true);
			}
		}
	}
}
