using System;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[RequireComponent(typeof(AudioSource))]
	public class SoundController : MonoBehaviour
	{
		private enum SoundControllerStates
		{
			INITIAL,
			ACTIVE,
			INACTIVE,
			FADE_IN,
			FADE_OUT
		}

		[SerializeField]
		private float playingDelaySec;

		[SerializeField]
		private float playingOffsetSec;

		[SerializeField]
		private float fadeOutTimeSec = 0.5f;

		[SerializeField]
		private float fadeInTimeSec;

		[SerializeField]
		[Range(0f, 1f)]
		private float minVolume;

		[SerializeField]
		[Range(0f, 1f)]
		private float maxVolume = 1f;

		[SerializeField]
		private AudioSource source;

		private float currentVolume;

		private float fadeOutSpeed;

		private float fadeInSpeed;

		private float currentFadeSpeed;

		private float playingDelayTimer;

		private SoundControllerStates state;

		private SoundControllerStates State
		{
			get
			{
				return state;
			}
			set
			{
				playingDelayTimer = 0f;
				SoundControllerStates soundControllerStates = state;
				bool flag = soundControllerStates != value;
				state = value;
				switch (value)
				{
				case SoundControllerStates.FADE_IN:
					if (flag)
					{
						if (soundControllerStates != SoundControllerStates.ACTIVE)
						{
							StartFadingPhase();
						}
						else
						{
							State = SoundControllerStates.ACTIVE;
						}
					}
					break;
				case SoundControllerStates.FADE_OUT:
					if (flag)
					{
						if (soundControllerStates != SoundControllerStates.INACTIVE)
						{
							StartFadingPhase();
						}
						else
						{
							State = SoundControllerStates.INACTIVE;
						}
					}
					break;
				case SoundControllerStates.INACTIVE:
					SetInactiveParams();
					break;
				case SoundControllerStates.ACTIVE:
					SetActiveParams();
					break;
				default:
					throw new ArgumentException("Invalid sound Controller state");
				}
			}
		}

		public AudioSource Source
		{
			get
			{
				return source;
			}
		}

		private float CurrentVolume
		{
			get
			{
				return currentVolume;
			}
			set
			{
				currentVolume = value;
				currentVolume = Mathf.Clamp(value, minVolume, maxVolume);
				source.volume = currentVolume;
			}
		}

		public float FadeInTimeSec
		{
			get
			{
				return fadeInTimeSec;
			}
			set
			{
				fadeInTimeSec = value;
				fadeInSpeed = CalculateFadingSpeed(fadeInTimeSec);
			}
		}

		public float FadeOutTimeSec
		{
			get
			{
				return fadeOutTimeSec;
			}
			set
			{
				fadeOutTimeSec = value;
				fadeOutSpeed = 0f - CalculateFadingSpeed(fadeOutTimeSec);
			}
		}

		public float PlayingDelaySec
		{
			get
			{
				return playingDelaySec;
			}
			set
			{
				playingDelaySec = value;
			}
		}

		public float PlayingOffsetSec
		{
			get
			{
				return playingOffsetSec;
			}
			set
			{
				playingOffsetSec = value;
			}
		}

		public float MinVolume
		{
			get
			{
				return minVolume;
			}
			set
			{
				minVolume = value;
				source.volume = Mathf.Clamp(currentVolume, minVolume, maxVolume);
			}
		}

		public float MaxVolume
		{
			get
			{
				return maxVolume;
			}
			set
			{
				maxVolume = value;
				source.volume = Mathf.Clamp(currentVolume, minVolume, maxVolume);
			}
		}

		private float CalculateFadingSpeed(float fadingTime)
		{
			return (!(fadingTime > 0f)) ? 0f : (1f / fadingTime);
		}

		private void SetInactiveParams()
		{
			CurrentVolume = minVolume;
			base.enabled = false;
			StopSound();
		}

		private void SetActiveParams()
		{
			CurrentVolume = maxVolume;
			base.enabled = false;
			StartSound();
		}

		private void StartFadingPhase()
		{
			float num;
			float num2;
			SoundControllerStates soundControllerStates;
			bool flag;
			switch (state)
			{
			case SoundControllerStates.FADE_IN:
				num = fadeInTimeSec;
				num2 = fadeInSpeed;
				soundControllerStates = SoundControllerStates.ACTIVE;
				flag = currentVolume >= maxVolume;
				StartSound();
				break;
			case SoundControllerStates.FADE_OUT:
				num = fadeOutTimeSec;
				num2 = fadeOutSpeed;
				soundControllerStates = SoundControllerStates.INACTIVE;
				flag = currentVolume <= minVolume;
				break;
			default:
				throw new ArgumentException("Fading phase doesn't exist");
			}
			if (flag || num == 0f)
			{
				State = soundControllerStates;
				return;
			}
			currentFadeSpeed = num2;
			base.enabled = true;
		}

		private void Awake()
		{
			source.time = playingOffsetSec;
			fadeInSpeed = CalculateFadingSpeed(fadeInTimeSec);
			fadeOutSpeed = 0f - CalculateFadingSpeed(fadeOutTimeSec);
			State = SoundControllerStates.INACTIVE;
		}

		private void Update()
		{
			float deltaTime = Time.deltaTime;
			if (playingDelayTimer > 0f)
			{
				playingDelayTimer -= deltaTime;
				if (playingDelayTimer > 0f)
				{
					return;
				}
			}
			if (State == SoundControllerStates.INACTIVE)
			{
				base.enabled = false;
				return;
			}
			if (State == SoundControllerStates.ACTIVE)
			{
				base.enabled = false;
				return;
			}
			CurrentVolume += currentFadeSpeed * deltaTime;
			if (CurrentVolume <= minVolume)
			{
				State = SoundControllerStates.INACTIVE;
			}
			else if (CurrentVolume >= maxVolume)
			{
				State = SoundControllerStates.ACTIVE;
			}
		}

		private void StartSound()
		{
			if (!source.isPlaying)
			{
				source.time = playingOffsetSec;
				source.PlayScheduled(AudioSettings.dspTime + (double)PlayingDelaySec);
				playingDelayTimer = PlayingDelaySec;
				base.enabled = true;
			}
		}

		private void StopSound()
		{
			source.Stop();
		}

		public void FadeIn()
		{
			State = SoundControllerStates.FADE_IN;
		}

		public void SetSoundActive()
		{
			State = SoundControllerStates.ACTIVE;
		}

		public void FadeOut()
		{
			State = SoundControllerStates.FADE_OUT;
		}

		public void StopImmediately()
		{
			State = SoundControllerStates.INACTIVE;
		}
	}
}
