using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public abstract class FadeSoundFilter : MonoBehaviour
	{
		private const float MIN_FADE_TIME_SEC = 0.01f;

		[SerializeField]
		protected AudioSource source;

		[SerializeField]
		private float fadeInTimeSec = 1f;

		[SerializeField]
		private float fadeOutTimeSec = 1f;

		private volatile float fadeInSpeed;

		private volatile float fadeOutSpeed;

		private volatile float fadeSpeed;

		private double prevAudioTime;

		private float maxVolume;

		private volatile bool needToKill;

		private volatile bool needToDisable;

		private volatile bool isFading;

		private volatile bool firstAudioFilterIteration;

		public AudioSource Source
		{
			get
			{
				return source;
			}
		}

		protected abstract float FilterVolume
		{
			get;
			set;
		}

		protected virtual void Awake()
		{
			fadeInSpeed = 1f / fadeInTimeSec;
			fadeOutSpeed = -1f / fadeOutTimeSec;
			maxVolume = source.volume;
			ResetFilter();
		}

		private void Update()
		{
			UpdateSoundWithinMainThread();
			ApplySourceVolume();
			if (needToKill)
			{
				StopAndDestroy();
			}
			else if (needToDisable)
			{
				ResetFilter();
			}
		}

		protected void ResetFilter()
		{
			base.enabled = false;
			needToKill = false;
			needToDisable = false;
			isFading = false;
			firstAudioFilterIteration = false;
		}

		private void UpdateSoundWithinMainThread()
		{
			float deltaTime = Time.deltaTime;
			float num = fadeSpeed;
			float filterVolume = FilterVolume;
			float num2 = filterVolume;
			num2 += num * deltaTime;
			float filterVolume2 = Mathf.Clamp(num2, 0f, 1f);
			if (!isFading)
			{
				FilterVolume = filterVolume2;
				return;
			}
			if (num2 <= 0f && num < 0f)
			{
				needToKill = true;
			}
			if (num2 >= 1f && num > 0f)
			{
				needToDisable = true;
			}
			FilterVolume = filterVolume2;
		}

		private void StartFilter(float speed)
		{
			fadeSpeed = speed;
			firstAudioFilterIteration = true;
			fadeSpeed = speed;
			needToKill = false;
			needToDisable = false;
			isFading = true;
			base.enabled = true;
		}

		public void Play(float delay = -1f)
		{
			float filterVolume = 0f;
			if (fadeInTimeSec > 0.01f)
			{
				StartFilter(fadeInSpeed);
			}
			else
			{
				filterVolume = 1f;
				ResetFilter();
			}
			if (!source.isPlaying)
			{
				FilterVolume = filterVolume;
				ApplySourceVolume();
			}
			PlaySound(delay);
		}

		private void ApplySourceVolume()
		{
			source.volume = FilterVolume * maxVolume;
		}

		public void Stop()
		{
			if (!CheckSoundIsPlaying())
			{
				StopAndDestroy();
			}
			else if (fadeOutTimeSec > 0.01f)
			{
				StartFilter(fadeOutSpeed);
			}
			else
			{
				StopAndDestroy();
			}
		}

		private void PlaySound(float delay)
		{
			if (!source.isPlaying)
			{
				if (delay <= 0f)
				{
					source.Play();
				}
				else
				{
					source.PlayScheduled(AudioSettings.dspTime + (double)delay);
				}
			}
		}

		protected abstract void StopAndDestroy();

		protected abstract bool CheckSoundIsPlaying();
	}
}
