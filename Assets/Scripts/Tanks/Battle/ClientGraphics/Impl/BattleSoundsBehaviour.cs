using Tanks.Battle.ClientGraphics.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class BattleSoundsBehaviour : MonoBehaviour
	{
		private const float DESTROY_DELAY = 1f;

		[SerializeField]
		private float minRemainigRoundTimeSec = 5f;

		[SerializeField]
		private int minDMScoreDiff = 5;

		[SerializeField]
		private int minTDMScoreDiff = 7;

		[SerializeField]
		private int minCTFScoreDiff = 2;

		[SerializeField]
		private AudioSource[] startSounds;

		[SerializeField]
		private AudioSource shortNeutralSound;

		[SerializeField]
		private AudioSource shortWinSound;

		[SerializeField]
		private AudioSource shortLostSound;

		[SerializeField]
		private AmbientSoundFilter victoryMelody;

		[SerializeField]
		private AmbientSoundFilter defeatMelody;

		[SerializeField]
		private AmbientSoundFilter neutralMelody;

		public float MinRemainigRoundTimeSec
		{
			get
			{
				return minRemainigRoundTimeSec;
			}
		}

		public int MinDmScoreDiff
		{
			get
			{
				return minDMScoreDiff;
			}
		}

		public int MinTdmScoreDiff
		{
			get
			{
				return minTDMScoreDiff;
			}
		}

		public int MinCtfScoreDiff
		{
			get
			{
				return minCTFScoreDiff;
			}
		}

		public void PlayStartSound(Transform root, float delay = -1f)
		{
			InstantiateAndPlay(startSounds[Random.Range(0, startSounds.Length)], root, delay);
		}

		public void PlayShortNeutralSound(Transform root, float delay = -1f)
		{
			InstantiateAndPlay(shortNeutralSound, root, delay);
		}

		public void PlayShortNonNeutralSound(Transform root, bool win, float delay = -1f)
		{
			AudioSource source = ((!win) ? shortLostSound : shortWinSound);
			InstantiateAndPlay(source, root, delay);
		}

		public AmbientSoundFilter PlayNeutralMelody(Transform root, float delay = -1f)
		{
			return InstantiateAndPlay(neutralMelody, root, delay);
		}

		public AmbientSoundFilter PlayNonNeutralMelody(Transform root, bool win, float delay = -1f)
		{
			return InstantiateAndPlay((!win) ? defeatMelody : victoryMelody, root, delay);
		}

		private AmbientSoundFilter InstantiateAndPlay(AmbientSoundFilter source, Transform root, float delay)
		{
			AmbientSoundFilter ambientSoundFilter = Object.Instantiate(source);
			Transform transform = ambientSoundFilter.transform;
			ApplyParentTransformData(transform, root);
			if (delay > 0f)
			{
				ambientSoundFilter.Play(delay);
				return ambientSoundFilter;
			}
			ambientSoundFilter.Play();
			return ambientSoundFilter;
		}

		private void ApplyParentTransformData(Transform instanceTransform, Transform root)
		{
			instanceTransform.parent = root;
			instanceTransform.localPosition = Vector3.zero;
			instanceTransform.localRotation = Quaternion.identity;
			instanceTransform.localScale = Vector3.one;
		}

		private void InstantiateAndPlay(AudioSource source, Transform root, float delay)
		{
			AudioSource audioSource = Object.Instantiate(source);
			Transform transform = audioSource.transform;
			ApplyParentTransformData(transform, root);
			if (delay > 0f)
			{
				audioSource.PlayScheduled(AudioSettings.dspTime + (double)delay);
				Object.DestroyObject(audioSource.gameObject, delay + audioSource.clip.length + 1f);
			}
			else
			{
				audioSource.Play();
				Object.DestroyObject(audioSource.gameObject, audioSource.clip.length + 1f);
			}
		}
	}
}
