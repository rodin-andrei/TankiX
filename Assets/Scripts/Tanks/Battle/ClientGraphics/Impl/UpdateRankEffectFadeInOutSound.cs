using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectFadeInOutSound : MonoBehaviour
	{
		public float MaxVolume = 1f;

		public float StartDelay;

		public float FadeInSpeed;

		public float FadeOutDelay;

		public float FadeOutSpeed;

		public bool FadeOutAfterCollision;

		public bool UseHideStatus;

		private AudioSource audioSource;

		private float oldVolume;

		private float currentVolume;

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
			InitSource();
		}

		private void InitSource()
		{
			if (!isInitialized)
			{
				audioSource = GetComponent<AudioSource>();
				if (!(audioSource == null))
				{
					isStartDelay = StartDelay > 0.001f;
					isIn = FadeInSpeed > 0.001f;
					isOut = FadeOutSpeed > 0.001f;
					InitDefaultVariables();
					isInitialized = true;
				}
			}
		}

		private void InitDefaultVariables()
		{
			fadeInComplited = false;
			fadeOutComplited = false;
			allComplited = false;
			canStartFadeOut = false;
			isCollisionEnter = false;
			oldVolume = 0f;
			currentVolume = MaxVolume;
			if (isIn)
			{
				currentVolume = 0f;
			}
			audioSource.volume = currentVolume;
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
				oldVolume = MaxVolume;
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
			if (!canStart || audioSource == null)
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
				else if ((UseHideStatus && !effectSettings.IsVisible) || isCollisionEnter)
				{
					FadeOut();
				}
			}
		}

		private void FadeIn()
		{
			currentVolume = oldVolume + Time.deltaTime / FadeInSpeed * MaxVolume;
			if (currentVolume >= MaxVolume)
			{
				fadeInComplited = true;
				if (!isOut)
				{
					allComplited = true;
				}
				currentVolume = MaxVolume;
				Invoke("SetupFadeOutDelay", FadeOutDelay);
			}
			audioSource.volume = currentVolume;
			oldVolume = currentVolume;
		}

		private void FadeOut()
		{
			currentVolume = oldVolume - Time.deltaTime / FadeOutSpeed * MaxVolume;
			if (currentVolume <= 0f)
			{
				currentVolume = 0f;
				fadeOutComplited = true;
				allComplited = true;
			}
			audioSource.volume = currentVolume;
			oldVolume = currentVolume;
		}
	}
}
