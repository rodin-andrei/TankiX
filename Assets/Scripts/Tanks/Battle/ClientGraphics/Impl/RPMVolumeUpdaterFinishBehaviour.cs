using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class RPMVolumeUpdaterFinishBehaviour : MonoBehaviour
	{
		private const float SOUND_PAUSE_LATENCY_SEC = 2f;

		[SerializeField]
		private AudioSource source;

		[SerializeField]
		private float soundPauseTimer;

		private void Awake()
		{
			base.enabled = false;
		}

		private void OnEnable()
		{
			soundPauseTimer = 2f;
		}

		private void Update()
		{
			soundPauseTimer -= Time.deltaTime;
			if (soundPauseTimer <= 0f)
			{
				source.Pause();
				base.enabled = false;
			}
		}

		public void Build(AudioSource source)
		{
			this.source = source;
		}
	}
}
