using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientGraphics.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	[RequireComponent(typeof(Animator))]
	public class NitroEffectComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		private bool prepared;

		public Animator animator;

		public Renderer renderer;

		public LightContainer lightContainer;

		public GameObject effectPrefab;

		public Transform effectPoints;

		public SpeedSoundEffectComponent soundEffect;

		public int burningTimeInMs = 500;

		private SupplyAnimationPlayer animationPlayer;

		private ParticleSystem[] effectInstances;

		private SmoothHeater smoothHeater;

		private int effectInstancesCount;

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
			animationPlayer = new SupplyAnimationPlayer(animator, AnimationParameters.SPEED_ACTIVE);
			effectInstances = SupplyEffectUtil.InstantiateEffect(effectPrefab, effectPoints);
			soundEffect.Init(base.transform);
			Material materialForNitroDetails = TankMaterialsUtil.GetMaterialForNitroDetails(renderer);
			smoothHeater = ((!settings.LightIsEnabled) ? new SmoothHeater(burningTimeInMs, materialForNitroDetails, this) : new SmoothHeaterLighting(burningTimeInMs, materialForNitroDetails, this, lightContainer));
			effectInstancesCount = effectInstances.Length;
			prepared = true;
		}

		public void Play()
		{
			animationPlayer.StartAnimation();
		}

		public void Stop()
		{
			animationPlayer.StopAnimation();
		}

		private void OnSpeedStart()
		{
			soundEffect.BeginEffect();
		}

		private void OnSpeedStarted()
		{
			smoothHeater.Heat();
			for (int i = 0; i < effectInstancesCount; i++)
			{
				effectInstances[i].Play(true);
			}
		}

		private void OnSpeedStop()
		{
			smoothHeater.Cool();
			for (int i = 0; i < effectInstancesCount; i++)
			{
				effectInstances[i].Stop(true);
			}
			soundEffect.StopEffect();
		}

		private void Update()
		{
			smoothHeater.Update();
		}
	}
}
