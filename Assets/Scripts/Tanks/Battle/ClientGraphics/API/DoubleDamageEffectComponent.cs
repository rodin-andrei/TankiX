using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientGraphics.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	[RequireComponent(typeof(Animator))]
	public class DoubleDamageEffectComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		private bool prepared;

		public Animator animator;

		public LightContainer light;

		public Renderer renderer;

		public DoubleDamageSoundEffectComponent soundEffect;

		public Color emissionColor;

		public int burningTimeInMs = 500;

		private SupplyAnimationPlayer animationPlayer;

		private Material ddDetailsMaterial;

		private Material mainMaterial;

		[HideInInspector]
		public Color usualEmissionColor;

		private SmoothHeater smoothHeater;

		public bool Prepared
		{
			get
			{
				return prepared;
			}
		}

		private void Awake()
		{
			base.enabled = false;
		}

		public void InitEffect(SupplyEffectSettingsComponent settings)
		{
			animationPlayer = new SupplyAnimationPlayer(animator, AnimationParameters.DAMAGE_ACTIVE);
			mainMaterial = TankMaterialsUtil.GetMainMaterial(renderer);
			ddDetailsMaterial = TankMaterialsUtil.GetMaterialForDoubleDamageDetails(renderer);
			soundEffect.Init(base.transform);
			usualEmissionColor = mainMaterial.GetColor("_EmissionColor");
			smoothHeater = ((!settings.LightIsEnabled) ? new SmoothHeater(burningTimeInMs, ddDetailsMaterial, this) : new SmoothHeaterLighting(burningTimeInMs, ddDetailsMaterial, this, light));
			prepared = true;
		}

		public void Reset()
		{
			mainMaterial.SetColor("_EmissionColor", usualEmissionColor);
		}

		public void Play()
		{
			animationPlayer.StartAnimation();
		}

		public void Stop()
		{
			animationPlayer.StopAnimation();
		}

		private void OnDamageStart()
		{
			soundEffect.BeginEffect();
			mainMaterial.SetColor("_EmissionColor", emissionColor);
		}

		private void OnDamageStarted()
		{
			smoothHeater.Heat();
		}

		private void OnDamageStop()
		{
			smoothHeater.Cool();
			soundEffect.StopEffect();
			mainMaterial.SetColor("_EmissionColor", usualEmissionColor);
		}

		private void Update()
		{
			smoothHeater.Update();
		}
	}
}
