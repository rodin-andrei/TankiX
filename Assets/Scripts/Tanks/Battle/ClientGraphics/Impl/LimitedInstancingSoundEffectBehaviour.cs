using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public abstract class LimitedInstancingSoundEffectBehaviour : MonoBehaviour
	{
		private static double[] LAST_PLAY_TIMES = new double[2]
		{
			-1.0,
			-1.0
		};

		[SerializeField]
		private AudioSource source;

		[SerializeField]
		private float playDelay = -1f;

		private static bool CanInstantiateSoundEffect(int index, float minTimeForPlayingSec)
		{
			if (LAST_PLAY_TIMES[index] < 0.0)
			{
				return true;
			}
			if (AudioSettings.dspTime - LAST_PLAY_TIMES[index] < (double)minTimeForPlayingSec)
			{
				return false;
			}
			return true;
		}

		protected static bool CreateSoundEffectInstance(LimitedInstancingSoundEffectBehaviour effectPrefab, int index, float minTimeForPlayingSec)
		{
			if (!CanInstantiateSoundEffect(index, minTimeForPlayingSec))
			{
				return false;
			}
			InstantiateAndPlaySoundEffectInstance(effectPrefab, index);
			return true;
		}

		private static void InstantiateAndPlaySoundEffectInstance(LimitedInstancingSoundEffectBehaviour effectPrefab, int index)
		{
			LimitedInstancingSoundEffectBehaviour limitedInstancingSoundEffectBehaviour = Object.Instantiate(effectPrefab);
			Object.DontDestroyOnLoad(limitedInstancingSoundEffectBehaviour.gameObject);
			limitedInstancingSoundEffectBehaviour.Play(index);
		}

		private void Play(int index)
		{
			if (playDelay <= 0f)
			{
				source.Play();
				LAST_PLAY_TIMES[index] = AudioSettings.dspTime;
				Object.DestroyObject(base.gameObject, source.clip.length);
			}
			else
			{
				double num = AudioSettings.dspTime + (double)playDelay;
				source.PlayScheduled(num);
				LAST_PLAY_TIMES[index] = num;
				base.enabled = true;
			}
		}

		private void Update()
		{
			if (!source.isPlaying)
			{
				Object.DestroyObject(base.gameObject);
			}
		}
	}
}
