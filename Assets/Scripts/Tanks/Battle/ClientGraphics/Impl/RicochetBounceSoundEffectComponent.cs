using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class RicochetBounceSoundEffectComponent : BaseRicochetSoundEffectComponent
	{
		private const float PLAY_INTERVAL_TIME = 0.5f;

		[SerializeField]
		private AudioClip[] avaibleClips;

		private int clipIndex;

		private int clipsCount;

		private float playInterval;

		private void Awake()
		{
			playInterval = -1f;
			base.enabled = false;
			clipIndex = 0;
			clipsCount = avaibleClips.Length;
		}

		private void Update()
		{
			playInterval -= Time.deltaTime;
			if (playInterval <= 0f)
			{
				playInterval = -1f;
				base.enabled = false;
			}
		}

		public override void PlayEffect(Vector3 position)
		{
			if (!(playInterval > 0f))
			{
				base.PlayEffect(position);
				playInterval = 0.5f;
				base.enabled = true;
			}
		}

		public override void Play(AudioSource sourceInstance)
		{
			AudioClip audioClip2 = (sourceInstance.clip = avaibleClips[clipIndex]);
			clipIndex++;
			if (clipIndex == clipsCount)
			{
				clipIndex = 0;
			}
			sourceInstance.Play();
		}
	}
}
