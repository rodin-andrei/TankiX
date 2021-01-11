using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class CameraShakeInstance
	{
		public float magnitude;

		public float roughness;

		public Vector3 positionInfluence;

		public Vector3 rotationInfluence;

		public bool deleteOnInactive = true;

		private float roughMod = 1f;

		private float magnMod = 1f;

		private float fadeOutDuration;

		private float fadeInDuration;

		private bool sustain;

		private float currentFadeTime;

		private float tick;

		private Vector3 amt;

		public float ScaleRoughness
		{
			get
			{
				return roughMod;
			}
			set
			{
				roughMod = value;
			}
		}

		public float ScaleMagnitude
		{
			get
			{
				return magnMod;
			}
			set
			{
				magnMod = value;
			}
		}

		public float NormalizedFadeTime
		{
			get
			{
				return currentFadeTime;
			}
		}

		private bool IsShaking
		{
			get
			{
				return currentFadeTime > 0f || sustain;
			}
		}

		private bool IsFadingOut
		{
			get
			{
				return !sustain && currentFadeTime > 0f;
			}
		}

		private bool IsFadingIn
		{
			get
			{
				return currentFadeTime < 1f && sustain && fadeInDuration > 0f;
			}
		}

		public CameraShakeState CurrentState
		{
			get
			{
				if (IsFadingIn)
				{
					return CameraShakeState.FadingIn;
				}
				if (IsFadingOut)
				{
					return CameraShakeState.FadingOut;
				}
				if (IsShaking)
				{
					return CameraShakeState.Sustained;
				}
				return CameraShakeState.Inactive;
			}
		}

		public CameraShakeInstance()
		{
			ResetFields();
		}

		private void ResetFields()
		{
			magnitude = 0f;
			roughness = 0f;
			positionInfluence = Vector3.zero;
			rotationInfluence = Vector3.zero;
			deleteOnInactive = true;
			roughMod = 1f;
			magnMod = 1f;
			fadeInDuration = 0f;
			fadeOutDuration = 0f;
			sustain = false;
			currentFadeTime = 0f;
			tick = 0f;
			amt = Vector3.zero;
		}

		public CameraShakeInstance Init(float magnitude, float roughness, float fadeInTime, float fadeOutTime)
		{
			ResetFields();
			this.magnitude = magnitude;
			fadeOutDuration = fadeOutTime;
			fadeInDuration = fadeInTime;
			this.roughness = roughness;
			if (fadeInTime > 0f)
			{
				sustain = true;
				currentFadeTime = 0f;
			}
			else
			{
				sustain = false;
				currentFadeTime = 1f;
			}
			tick = Random.Range(-100, 100);
			return this;
		}

		public CameraShakeInstance Init(float magnitude, float roughness)
		{
			ResetFields();
			this.magnitude = magnitude;
			this.roughness = roughness;
			sustain = true;
			tick = Random.Range(-100, 100);
			return this;
		}

		public Vector3 UpdateShake()
		{
			amt.x = Mathf.PerlinNoise(tick, 0f) - 0.5f;
			amt.y = Mathf.PerlinNoise(0f, tick) - 0.5f;
			amt.z = Mathf.PerlinNoise(tick, tick) - 0.5f;
			if (fadeInDuration > 0f && sustain)
			{
				if (currentFadeTime < 1f)
				{
					currentFadeTime += Time.deltaTime / fadeInDuration;
				}
				else if (fadeOutDuration > 0f)
				{
					sustain = false;
				}
			}
			if (!sustain)
			{
				currentFadeTime -= Time.deltaTime / fadeOutDuration;
			}
			if (sustain)
			{
				tick += Time.deltaTime * roughness * roughMod;
			}
			else
			{
				tick += Time.deltaTime * roughness * roughMod * currentFadeTime;
			}
			return amt * magnitude * magnMod * currentFadeTime;
		}

		public void StartFadeOut(float fadeOutTime)
		{
			if (fadeOutTime == 0f)
			{
				currentFadeTime = 0f;
			}
			fadeOutDuration = fadeOutTime;
			fadeInDuration = 0f;
			sustain = false;
		}

		public void StartFadeIn(float fadeInTime)
		{
			if (fadeInTime == 0f)
			{
				currentFadeTime = 1f;
			}
			fadeInDuration = fadeInTime;
			fadeOutDuration = 0f;
			sustain = true;
		}
	}
}
