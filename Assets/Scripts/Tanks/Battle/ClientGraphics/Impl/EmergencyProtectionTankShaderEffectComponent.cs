using System;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientGraphics.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class EmergencyProtectionTankShaderEffectComponent : BehaviourComponent
	{
		private enum AnimationStates
		{
			WAVE,
			TIMEOUT
		}

		private const string ROTATION_ANGLE_KEY = "_RepairRotationAngle";

		private const string EMERGENCY_PROTECTION_COLOR = "_EmergencyProtectionColor";

		private const string EMERGENCY_PROTECTION_FRONT_COEFF = "_EmergencyProtectionFrontCoeff";

		private const string EMERGENCY_PROTECTION_NOISE_TEX = "_EmergencyProtectionNoise";

		[SerializeField]
		private Color emergencyProtectionColor;

		[SerializeField]
		private float duration = 1f;

		[SerializeField]
		private float waveAnimationTime = 1f;

		[SerializeField]
		private AnimationCurve straightStepCurve;

		[SerializeField]
		private AnimationCurve reverseStepCurve;

		[SerializeField]
		private Vector2 noiseTextureTiling = new Vector2(5f, 5f);

		[SerializeField]
		private Texture2D noiseTexture;

		[SerializeField]
		private ParticleSystem waveEffect;

		[SerializeField]
		private bool useWaveEffect;

		[SerializeField]
		private float delayWithWaveEffect = 0.25f;

		private float phaseTimer;

		private int waveCount;

		private int waveIterator;

		private int waveTimeoutIterator;

		private float waveTimeoutLength;

		private AnimationStates state;

		private bool frontDirection;

		private HealingGraphicEffectInputs tankEffectInput;

		private WeaponHealingGraphicEffectInputs weaponEffectInputs;

		public float DelayWithWaveEffect
		{
			get
			{
				return delayWithWaveEffect;
			}
		}

		public float Duration
		{
			get
			{
				return duration;
			}
		}

		public ParticleSystem WaveEffect
		{
			get
			{
				return waveEffect;
			}
		}

		public bool UseWaveEffect
		{
			get
			{
				return useWaveEffect;
			}
		}

		public void InitEffect(HealingGraphicEffectInputs tankEffectInput, WeaponHealingGraphicEffectInputs weaponEffectInputs)
		{
			base.enabled = false;
			this.tankEffectInput = tankEffectInput;
			this.weaponEffectInputs = weaponEffectInputs;
			InitTankPartInputs(tankEffectInput);
			InitTankPartInputs(weaponEffectInputs);
			phaseTimer = 0f;
		}

		private void InitTankPartInputs(HealingGraphicEffectInputs inputs)
		{
			SkinnedMeshRenderer renderer = inputs.Renderer;
			Material[] materials = renderer.materials;
			int num = materials.Length;
			for (int i = 0; i < num; i++)
			{
				Material material = materials[i];
				material.SetColor("_EmergencyProtectionColor", emergencyProtectionColor);
				material.SetFloat("_EmergencyProtectionFrontCoeff", 0f);
				material.SetTexture("_EmergencyProtectionNoise", noiseTexture);
				material.SetTextureScale("_EmergencyProtectionNoise", noiseTextureTiling);
			}
		}

		public void StartEffect(Shader shader)
		{
			StartEffect(shader, tankEffectInput);
			StartEffect(shader, weaponEffectInputs);
			waveCount = Mathf.FloorToInt(duration / waveAnimationTime);
			ResetAnimationParameters();
			ResetAnimationWaveIterators();
			waveTimeoutLength = (duration - waveAnimationTime * (float)waveCount) / (float)waveTimeoutIterator;
			frontDirection = true;
			base.enabled = true;
		}

		private void ResetAnimationParameters()
		{
			phaseTimer = 0f;
			state = AnimationStates.TIMEOUT;
		}

		private void ResetAnimationWaveIterators()
		{
			waveIterator = waveCount;
			waveTimeoutIterator = waveCount + 1;
		}

		private void StartEffect(Shader shader, HealingGraphicEffectInputs inputs)
		{
			SkinnedMeshRenderer renderer = inputs.Renderer;
			Material[] materials = renderer.materials;
			int num = materials.Length;
			for (int i = 0; i < num; i++)
			{
				Material material = materials[i];
				material.shader = shader;
				material.SetFloat("_EmergencyProtectionFrontCoeff", 0f);
			}
		}

		private void Update()
		{
			float deltaTime = Time.deltaTime;
			if (waveIterator + waveTimeoutIterator <= 0)
			{
				StopEffect();
				return;
			}
			phaseTimer += Time.deltaTime;
			float num = 0f;
			if (state == AnimationStates.TIMEOUT)
			{
				num = phaseTimer / waveTimeoutLength;
				if (num >= 1f)
				{
					phaseTimer = 0f;
					state = AnimationStates.WAVE;
					waveTimeoutIterator--;
				}
				return;
			}
			num = phaseTimer / waveAnimationTime;
			if (num >= 1f)
			{
				phaseTimer = 0f;
				state = AnimationStates.TIMEOUT;
				frontDirection = !frontDirection;
				waveIterator--;
			}
			else
			{
				AnimationCurve animationCurve = ((!frontDirection) ? reverseStepCurve : straightStepCurve);
				UpdateFrontCoeff(animationCurve.Evaluate(num));
			}
		}

		private void UpdateFrontCoeff(float coeff)
		{
			UpdateFrontCoeff(coeff, tankEffectInput);
			UpdateFrontCoeff(coeff, weaponEffectInputs);
		}

		private void UpdateFrontCoeff(float coeff, HealingGraphicEffectInputs inputs)
		{
			SkinnedMeshRenderer renderer = inputs.Renderer;
			Material[] materials = renderer.materials;
			int num = materials.Length;
			for (int i = 0; i < num; i++)
			{
				Material material = materials[i];
				material.SetFloat("_EmergencyProtectionFrontCoeff", coeff);
			}
		}

		private void UpdateFrontCoeff(float coeff, WeaponHealingGraphicEffectInputs inputs)
		{
			SkinnedMeshRenderer renderer = inputs.Renderer;
			Material[] materials = renderer.materials;
			int num = materials.Length;
			float value = -(float)Math.PI / 180f * inputs.RotationTransform.localEulerAngles.y;
			for (int i = 0; i < num; i++)
			{
				Material material = materials[i];
				material.SetFloat("_RepairRotationAngle", value);
				material.SetFloat("_EmergencyProtectionFrontCoeff", coeff);
			}
		}

		public void StopEffect()
		{
			ECSBehaviour.EngineService.Engine.NewEvent<StopEmergencyProtectionTankShaderEffectEvent>().AttachAll(tankEffectInput.Entity, weaponEffectInputs.Entity).Schedule();
			base.enabled = false;
		}
	}
}
