using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectFadeInOutLight : MonoBehaviour
	{
		public float StartDelay;

		public float FadeInSpeed;

		public float FadeOutDelay;

		public float FadeOutSpeed;

		public bool FadeOutAfterCollision;

		public bool UseHideStatus;

		private Light goLight;

		private float oldIntensity;

		private float currentIntensity;

		private float startIntensity;

		private bool canStart;

		private bool canStartFadeOut;

		private bool fadeInComplited;

		private bool fadeOutComplited;

		private bool isCollisionEnter;

		private bool allComplited;

		private bool isStartDelay;

		private bool isIn;

		private bool isOut;

		private UpdateRankEffectSettings effectSettings;

		private bool isInitialized;

		private void GetEffectSettingsComponent(Transform tr)
		{
			Transform parent = tr.parent;
			if (parent != null)
			{
				effectSettings = parent.GetComponentInChildren<UpdateRankEffectSettings>();
				if (effectSettings == null)
				{
					GetEffectSettingsComponent(parent.transform);
				}
			}
		}

		private void Start()
		{
			GetEffectSettingsComponent(base.transform);
			if (effectSettings != null)
			{
				effectSettings.CollisionEnter += prefabSettings_CollisionEnter;
			}
			goLight = GetComponent<Light>();
			startIntensity = goLight.intensity;
			isStartDelay = StartDelay > 0.001f;
			isIn = FadeInSpeed > 0.001f;
			isOut = FadeOutSpeed > 0.001f;
			InitDefaultVariables();
			isInitialized = true;
		}

		private void InitDefaultVariables()
		{
			fadeInComplited = false;
			fadeOutComplited = false;
			allComplited = false;
			canStartFadeOut = false;
			isCollisionEnter = false;
			oldIntensity = 0f;
			currentIntensity = 0f;
			canStart = false;
			goLight.intensity = ((!isIn) ? startIntensity : 0f);
			if (isStartDelay)
			{
				Invoke("SetupStartDelay", StartDelay);
			}
			else
			{
				canStart = true;
			}
			if (!isIn)
			{
				if (!FadeOutAfterCollision)
				{
					Invoke("SetupFadeOutDelay", FadeOutDelay);
				}
				oldIntensity = startIntensity;
			}
		}

		private void prefabSettings_CollisionEnter(object sender, UpdateRankCollisionInfo e)
		{
			isCollisionEnter = true;
			if (!isIn && FadeOutAfterCollision)
			{
				Invoke("SetupFadeOutDelay", FadeOutDelay);
			}
		}

		private void OnEnable()
		{
			if (isInitialized)
			{
				InitDefaultVariables();
			}
		}

		private void SetupStartDelay()
		{
			canStart = true;
		}

		private void SetupFadeOutDelay()
		{
			canStartFadeOut = true;
		}

		private void Update()
		{
			if (!canStart)
			{
				return;
			}
			if (effectSettings != null && UseHideStatus && allComplited && effectSettings.IsVisible)
			{
				allComplited = false;
				fadeInComplited = false;
				fadeOutComplited = false;
				InitDefaultVariables();
			}
			if (isIn && !fadeInComplited)
			{
				if (effectSettings == null)
				{
					FadeIn();
				}
				else if ((UseHideStatus && effectSettings.IsVisible) || !UseHideStatus)
				{
					FadeIn();
				}
			}
			if (isOut && !fadeOutComplited && canStartFadeOut)
			{
				if (effectSettings == null || (!UseHideStatus && !FadeOutAfterCollision))
				{
					FadeOut();
				}
				else if ((UseHideStatus && !effectSettings.IsVisible) || (FadeOutAfterCollision && isCollisionEnter))
				{
					FadeOut();
				}
			}
		}

		private void FadeIn()
		{
			currentIntensity = oldIntensity + Time.deltaTime / FadeInSpeed * startIntensity;
			if (currentIntensity >= startIntensity)
			{
				fadeInComplited = true;
				if (!isOut)
				{
					allComplited = true;
				}
				currentIntensity = startIntensity;
				Invoke("SetupFadeOutDelay", FadeOutDelay);
			}
			goLight.intensity = currentIntensity;
			oldIntensity = currentIntensity;
		}

		private void FadeOut()
		{
			currentIntensity = oldIntensity - Time.deltaTime / FadeOutSpeed * startIntensity;
			if (currentIntensity <= 0f)
			{
				currentIntensity = 0f;
				fadeOutComplited = true;
				allComplited = true;
			}
			goLight.intensity = currentIntensity;
			oldIntensity = currentIntensity;
		}
	}
}
