using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public abstract class BaseHealingGraphicEffectComponent<T> : BehaviourComponent where T : Platform.Kernel.ECS.ClientEntitySystem.API.Event, new()
	{
		private enum AnimationStates
		{
			WAVE,
			TIMEOUT
		}

		protected const string FRONT_BORDER_COEFF_KEY = "_RepairFrontCoeff";

		protected const string MOVEMENT_DIRECTION_KEY = "_RepairMovementDirection";

		private const string REPAIR_TEXTURE_KEY = "_RepairTex";

		private const string ROTATION_ANGLE_KEY = "_RepairRotationAngle";

		[SerializeField]
		private float durationInLoopMode = 2f;

		[SerializeField]
		private float arbitraryDuration = 2f;

		[SerializeField]
		private float pauseInLoopMode = 2f;

		[SerializeField]
		private float waveAnimationTime = 1f;

		[SerializeField]
		private Texture2D repairTexture;

		[SerializeField]
		private AudioSource sound;

		[SerializeField]
		private AnimationCurve straightStepCurve;

		[SerializeField]
		private AnimationCurve reverseStepCurve;

		private float phaseTimer;

		private float pauseBetweenFullAnimationCycleTimer;

		private int waveCount;

		private int waveIterator;

		private int waveTimeoutIterator;

		private float waveTimeoutLength;

		private AnimationStates state;

		private int currentDirection;

		private HealingGraphicEffectInputs tankInputs;

		private WeaponHealingGraphicEffectInputs weaponInputs;

		private bool isLoop;

		public virtual void InitRepairGraphicsEffect(HealingGraphicEffectInputs tankInputs, WeaponHealingGraphicEffectInputs weaponInputs, Transform soundRoot, Transform mountPoint)
		{
			isLoop = false;
			this.weaponInputs = weaponInputs;
			this.tankInputs = tankInputs;
			InitSound(soundRoot);
		}

		public void StartLoop(Shader shaderWithEffect)
		{
			isLoop = true;
			StartEffect(shaderWithEffect, durationInLoopMode);
		}

		public void StartEffect(Shader shaderWithEffect, float duration = 0f)
		{
			float num = ((!(arbitraryDuration > 0f)) ? duration : arbitraryDuration);
			waveCount = Mathf.FloorToInt(num / waveAnimationTime);
			ResetAnimationParameters();
			ResetAnimationWaveIterators();
			waveTimeoutLength = (num - waveAnimationTime * (float)waveCount) / (float)waveTimeoutIterator;
			UpdateDirection(shaderWithEffect);
			PlaySoundEffect();
			base.enabled = true;
		}

		private void ResetAnimationParameters()
		{
			phaseTimer = 0f;
			pauseBetweenFullAnimationCycleTimer = -1f;
			state = AnimationStates.TIMEOUT;
			currentDirection = 1;
		}

		private void ResetAnimationWaveIterators()
		{
			waveIterator = waveCount;
			waveTimeoutIterator = waveCount + 1;
		}

		public void StopEffect()
		{
			UpdateDirection();
			StopSoundEffect();
			base.enabled = false;
			isLoop = false;
			if (tankInputs.Entity != null && weaponInputs.Entity != null)
			{
				ECSBehaviour.EngineService.Engine.NewEvent<T>().AttachAll(tankInputs.Entity, weaponInputs.Entity).Schedule();
			}
		}

		private void PlaySoundEffect()
		{
			if (!(sound == null))
			{
				sound.Stop();
				sound.Play();
			}
		}

		private void StopSoundEffect()
		{
			if (!(sound == null))
			{
				sound.Stop();
			}
		}

		private void Update()
		{
			float deltaTime = Time.deltaTime;
			if (waveIterator + waveTimeoutIterator <= 0)
			{
				if (isLoop)
				{
					ResetAnimationParameters();
					ResetAnimationWaveIterators();
					currentDirection = 1;
					UpdateDirection();
					pauseBetweenFullAnimationCycleTimer = pauseInLoopMode;
				}
				else
				{
					StopEffect();
				}
				return;
			}
			if (pauseBetweenFullAnimationCycleTimer > 0f)
			{
				pauseBetweenFullAnimationCycleTimer -= deltaTime;
				if (pauseBetweenFullAnimationCycleTimer <= 0f)
				{
					PlaySoundEffect();
				}
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
				UpdateDirection();
				waveIterator--;
			}
			else
			{
				AnimationCurve animationCurve = ((currentDirection <= 0) ? reverseStepCurve : straightStepCurve);
				UpdateFront(animationCurve.Evaluate(num));
			}
		}

		private void UpdateFront(float front)
		{
			UpdateFront(tankInputs, front);
			UpdateFront(weaponInputs, front, CalculateWeaponRotationAngle());
		}

		private float CalculateWeaponRotationAngle()
		{
			return -(float)Math.PI / 180f * weaponInputs.RotationTransform.localEulerAngles.y;
		}

		private void UpdateFront(HealingGraphicEffectInputs inputs, float front)
		{
			SkinnedMeshRenderer renderer = inputs.Renderer;
			Material[] materials = renderer.materials;
			int num = materials.Length;
			for (int i = 0; i < num; i++)
			{
				Material material = materials[i];
				material.SetFloat("_RepairFrontCoeff", front);
			}
		}

		private void UpdateFront(WeaponHealingGraphicEffectInputs inputs, float front, float angle)
		{
			SkinnedMeshRenderer renderer = inputs.Renderer;
			Material[] materials = renderer.materials;
			int num = materials.Length;
			for (int i = 0; i < num; i++)
			{
				Material material = materials[i];
				material.SetFloat("_RepairFrontCoeff", front);
				material.SetFloat("_RepairRotationAngle", angle);
			}
		}

		private void UpdateDirection(Shader shaderWithEffect = null)
		{
			UpdateDirection(tankInputs, currentDirection, shaderWithEffect);
			UpdateDirection(weaponInputs, currentDirection, CalculateWeaponRotationAngle(), shaderWithEffect);
			currentDirection ^= 1;
		}

		private void UpdateDirection(HealingGraphicEffectInputs inputs, float dir, Shader shaderWithEffect = null)
		{
			SkinnedMeshRenderer renderer = inputs.Renderer;
			Material[] materials = renderer.materials;
			int num = materials.Length;
			for (int i = 0; i < num; i++)
			{
				Material material = materials[i];
				if (shaderWithEffect != null)
				{
					material.shader = shaderWithEffect;
					SetRepairTextureParameters(material, inputs);
				}
				material.SetFloat("_RepairFrontCoeff", 0f);
				material.SetFloat("_RepairMovementDirection", dir);
			}
		}

		private void UpdateDirection(WeaponHealingGraphicEffectInputs inputs, float dir, float angle, Shader shaderWithEffect = null)
		{
			SkinnedMeshRenderer renderer = inputs.Renderer;
			Material[] materials = renderer.materials;
			int num = materials.Length;
			for (int i = 0; i < num; i++)
			{
				Material material = materials[i];
				if (shaderWithEffect != null)
				{
					material.shader = shaderWithEffect;
					SetRepairTextureParameters(material, inputs);
				}
				material.SetFloat("_RepairFrontCoeff", 0f);
				material.SetFloat("_RepairMovementDirection", dir);
				material.SetFloat("_RepairRotationAngle", angle);
			}
		}

		protected void SetInitialTankPartsParameters(Material mat)
		{
			mat.SetFloat("_RepairRotationAngle", 0f);
		}

		private void SetRepairTextureParameters(Material mat, HealingGraphicEffectInputs inputs)
		{
			mat.SetTexture("_RepairTex", repairTexture);
			mat.SetTextureScale("_RepairTex", new Vector2(inputs.TilingX, 1f));
		}

		private void InitSound(Transform soundRoot)
		{
			Transform transform = sound.transform;
			transform.parent = soundRoot;
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			transform.localScale = Vector3.one;
		}
	}
}
