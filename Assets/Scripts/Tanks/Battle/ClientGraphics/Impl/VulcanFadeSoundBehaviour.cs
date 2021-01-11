using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[RequireComponent(typeof(AudioSource))]
	public class VulcanFadeSoundBehaviour : MonoBehaviour
	{
		private AudioSource source;

		private float fadeSpeed;

		public float fadeDuration;

		public float maxVolume;

		private void OnEnable()
		{
			source = base.gameObject.GetComponent<AudioSource>();
			source.volume = maxVolume;
			fadeSpeed = (0f - maxVolume) / fadeDuration;
		}

		private void FixedUpdate()
		{
			source.volume += fadeSpeed * Time.fixedDeltaTime;
			if (!source.isPlaying)
			{
				base.enabled = false;
			}
		}
	}
}
