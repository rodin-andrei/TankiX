using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientGraphics.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class TankOutlineMapEffectComponent : BehaviourComponent
	{
		private enum States
		{
			IDLE,
			ACTIVATION,
			WORKING,
			BLINKER,
			DEACTIVATION
		}

		private const string GLOBAL_OUTLINE_EFFECT_NAME = "_GlobalTankOutlineEffectAlpha";

		private const string WORLD_SPACE_CENTER_NAME = "_WorldSpaceEffectCenter";

		private const string TANK_OUTLINE_EFFECT_RADIUS = "_TankOutlineEffectRadius";

		private const string GLOBAL_WORKING_COEFF = "_WorkingOutlineCoeff";

		private const string GLOBAL_TANK_OUTLINE_MULTIPLIER = "_GlobalTankOutlineScaleMultiplier";

		public static bool IS_OUTLINE_EFFECT_RUNNING;

		[SerializeField]
		private float maxEffectRadius = 3000f;

		[SerializeField]
		private float globalRadiusTime = 15f;

		[SerializeField]
		private float globalAlphaFadeInTime = 0.5f;

		[SerializeField]
		private float globalAlphaFadeOutTime = 1.5f;

		[SerializeField]
		private float minAlphaWhileBlinking = 0.25f;

		[SerializeField]
		private float enterSorkingStateSoundDelay = 1f;

		[SerializeField]
		private float workingFadeTimeOffset;

		[SerializeField]
		private float generalBlinkTime = 20f;

		[SerializeField]
		private float maxBlinkIterationTime = 2f;

		[SerializeField]
		private float pauseWhenBlinkOnMaxAlpha = -1f;

		[SerializeField]
		private float pauseWhenBlinkOnMinAlpha = 0.1f;

		[SerializeField]
		private float radarSoundInterval = 1f;

		[SerializeField]
		private float radarFadeSoundDelay = 0.5f;

		[SerializeField]
		private float workingStateFadeTime;

		[SerializeField]
		private float blinkRadius = 1.1f;

		[SerializeField]
		private SoundController radarSplashSound;

		[SerializeField]
		private SoundController radarFadeSound;

		[SerializeField]
		private SoundController deactivationRadarSound;

		[SerializeField]
		private SoundController activationRadarSound;

		private bool workingFadePause;

		private bool enterWorkingState;

		private float workingStateTimer;

		private int globalOutlineEffectAlphaID;

		private int globalWorkingCoeffID;

		private int worldSpaceEffectCenterID;

		private int tankOutlineEffectRadiusID;

		private Entity mapEffectEntity;

		private Transform effectCenterTransform;

		private float blinkTimer;

		private float pauseTimer;

		private bool blinkForward;

		private float blinkSpeed;

		private float alphaSpeedFadeOut;

		private float alphaSpeedFadeIn;

		private float radiusSpeed;

		private float globalOutlineEffectRadius;

		private float globalWorkingCoeff;

		private float globalOutlineEffectAlpha;

		private States previousState;

		private States state;

		private float GlobalOutlineEffectRadius
		{
			get
			{
				return globalOutlineEffectRadius;
			}
			set
			{
				globalOutlineEffectRadius = Mathf.Clamp(value, 0f, maxEffectRadius);
				Shader.SetGlobalFloat(tankOutlineEffectRadiusID, globalOutlineEffectRadius);
			}
		}

		private float GlobalWorkingCoeff
		{
			get
			{
				return globalWorkingCoeff;
			}
			set
			{
				globalWorkingCoeff = Mathf.Clamp01(value);
				Shader.SetGlobalFloat(globalWorkingCoeffID, globalWorkingCoeff);
			}
		}

		private float GlobalOutlineEffectAlpha
		{
			get
			{
				return globalOutlineEffectAlpha;
			}
			set
			{
				globalOutlineEffectAlpha = Mathf.Clamp01(value);
				Shader.SetGlobalFloat(globalOutlineEffectAlphaID, globalOutlineEffectAlpha);
			}
		}

		private States State
		{
			get
			{
				return state;
			}
			set
			{
				previousState = state;
				state = value;
				GlobalWorkingCoeff = 0f;
				switch (state)
				{
				case States.IDLE:
					GlobalOutlineEffectAlpha = 0f;
					GlobalOutlineEffectRadius = 0f;
					IS_OUTLINE_EFFECT_RUNNING = false;
					base.enabled = false;
					activationRadarSound.FadeOut();
					StopRadarSounds();
					SwitchEntityState<TankOutlineMapEffectStates.IdleState>();
					break;
				case States.ACTIVATION:
					UpdateEffectTransformCenter();
					IS_OUTLINE_EFFECT_RUNNING = true;
					base.enabled = true;
					deactivationRadarSound.FadeOut();
					activationRadarSound.SetSoundActive();
					StopRadarSounds();
					SwitchEntityState<TankOutlineMapEffectStates.ActivationState>();
					break;
				case States.WORKING:
					workingFadePause = false;
					enterWorkingState = true;
					workingStateTimer = enterSorkingStateSoundDelay;
					GlobalOutlineEffectAlpha = 1f;
					GlobalOutlineEffectRadius = maxEffectRadius;
					IS_OUTLINE_EFFECT_RUNNING = true;
					base.enabled = true;
					deactivationRadarSound.FadeOut();
					StopRadarSounds();
					SwitchEntityState<TankOutlineMapEffectStates.WorkingState>();
					break;
				case States.BLINKER:
					if (previousState == States.ACTIVATION && GlobalOutlineEffectAlpha < 1f)
					{
						DeactivateEffect();
						break;
					}
					IS_OUTLINE_EFFECT_RUNNING = true;
					blinkTimer = 0f;
					pauseTimer = -1f;
					blinkForward = false;
					base.enabled = true;
					activationRadarSound.FadeOut();
					deactivationRadarSound.SetSoundActive();
					StopRadarSounds();
					SwitchEntityState<TankOutlineMapEffectStates.BlinkerState>();
					break;
				case States.DEACTIVATION:
					IS_OUTLINE_EFFECT_RUNNING = true;
					base.enabled = true;
					activationRadarSound.FadeOut();
					deactivationRadarSound.SetSoundActive();
					StopRadarSounds();
					SwitchEntityState<TankOutlineMapEffectStates.DeactivationState>();
					break;
				}
			}
		}

		private void StopRadarSounds()
		{
			radarFadeSound.StopImmediately();
			radarSplashSound.StopImmediately();
		}

		private void UpdateEffectTransformCenter()
		{
			Vector3 position = effectCenterTransform.position;
			Shader.SetGlobalVector(worldSpaceEffectCenterID, new Vector4(position.x, position.y, position.z, 1f));
		}

		public void InitializeOutlineEffect(Entity mapEffectEntity, Transform effectCenterTransform)
		{
			this.mapEffectEntity = mapEffectEntity;
			this.effectCenterTransform = effectCenterTransform;
			radiusSpeed = maxEffectRadius / globalRadiusTime;
			alphaSpeedFadeOut = 1f / globalAlphaFadeOutTime;
			alphaSpeedFadeIn = 1f / globalAlphaFadeInTime;
			globalWorkingCoeffID = Shader.PropertyToID("_WorkingOutlineCoeff");
			globalOutlineEffectAlphaID = Shader.PropertyToID("_GlobalTankOutlineEffectAlpha");
			worldSpaceEffectCenterID = Shader.PropertyToID("_WorldSpaceEffectCenter");
			tankOutlineEffectRadiusID = Shader.PropertyToID("_TankOutlineEffectRadius");
			Shader.SetGlobalFloat("_GlobalTankOutlineScaleMultiplier", blinkRadius);
			State = States.IDLE;
			base.enabled = false;
		}

		public void ActivateEffect()
		{
			IS_OUTLINE_EFFECT_RUNNING = true;
			State = States.ACTIVATION;
		}

		public void RunBlinkerForEffect()
		{
			State = States.BLINKER;
		}

		public void DeactivateEffect()
		{
			State = States.DEACTIVATION;
		}

		private void SwitchEntityState<T>() where T : Node
		{
			ECSBehaviour.EngineService.Engine.ScheduleEvent(new TankOutlineMapEffectSwitchStateEvent<T>(), mapEffectEntity);
		}

		private void OnDestroy()
		{
			IS_OUTLINE_EFFECT_RUNNING = false;
			GlobalOutlineEffectAlpha = 0f;
		}

		private void Update()
		{
			float deltaTime = Time.deltaTime;
			switch (State)
			{
			case States.ACTIVATION:
				GlobalOutlineEffectAlpha += alphaSpeedFadeIn * deltaTime;
				GlobalOutlineEffectRadius += radiusSpeed * deltaTime;
				if (GlobalOutlineEffectAlpha >= 1f && GlobalOutlineEffectRadius >= maxEffectRadius)
				{
					State = States.WORKING;
				}
				break;
			case States.DEACTIVATION:
				GlobalOutlineEffectAlpha -= alphaSpeedFadeOut * deltaTime;
				if (GlobalOutlineEffectAlpha <= 0f)
				{
					State = States.IDLE;
				}
				break;
			case States.BLINKER:
			{
				GlobalOutlineEffectRadius += radiusSpeed * deltaTime;
				pauseTimer -= deltaTime;
				if (pauseTimer > 0f)
				{
					break;
				}
				blinkTimer += deltaTime;
				if (blinkTimer >= generalBlinkTime)
				{
					GlobalOutlineEffectAlpha = 1f;
					State = States.DEACTIVATION;
					break;
				}
				float num3 = 2f * (1f - minAlphaWhileBlinking) / maxBlinkIterationTime;
				if (blinkForward)
				{
					GlobalOutlineEffectAlpha += num3 * deltaTime;
					if (GlobalOutlineEffectAlpha >= 1f)
					{
						GlobalOutlineEffectAlpha = 1f;
						pauseTimer = pauseWhenBlinkOnMaxAlpha;
						blinkForward = false;
					}
				}
				else
				{
					GlobalOutlineEffectAlpha -= num3 * deltaTime;
					if (GlobalOutlineEffectAlpha <= minAlphaWhileBlinking)
					{
						GlobalOutlineEffectAlpha = minAlphaWhileBlinking;
						pauseTimer = pauseWhenBlinkOnMinAlpha;
						blinkForward = true;
					}
				}
				break;
			}
			case States.IDLE:
				base.enabled = false;
				break;
			case States.WORKING:
				workingStateTimer -= deltaTime;
				if (enterWorkingState)
				{
					if (workingStateTimer <= 0f)
					{
						enterWorkingState = false;
						PlayRadarSplashSound();
					}
				}
				else if (workingFadePause)
				{
					if (workingStateTimer <= 0f)
					{
						workingFadePause = false;
						workingStateTimer = workingStateFadeTime;
						radarFadeSound.SetSoundActive();
						GlobalWorkingCoeff = 1f;
					}
					else
					{
						GlobalWorkingCoeff -= 1f / workingStateFadeTime * deltaTime;
					}
				}
				else if (workingStateTimer <= 0f)
				{
					PlayRadarSplashSound();
				}
				else
				{
					float num2 = (GlobalWorkingCoeff = (workingStateTimer - workingFadeTimeOffset) / (workingStateFadeTime - workingFadeTimeOffset));
				}
				break;
			}
		}

		private void PlayRadarSplashSound()
		{
			StopRadarSounds();
			GlobalWorkingCoeff = 0.375f;
			radarSplashSound.SetSoundActive();
			workingFadePause = true;
			workingStateTimer = radarFadeSoundDelay;
		}
	}
}
