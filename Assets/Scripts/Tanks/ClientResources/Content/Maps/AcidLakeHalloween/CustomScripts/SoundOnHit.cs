using UnityEngine;

namespace tanks.ClientResources.Content.Maps.AcidLakeHalloween.CustomScripts
{
	public class SoundOnHit : MonoBehaviour
	{
		public AudioSource Sound;

		public bool OnTrigger;

		private void OnCollisionEnter(Collision other)
		{
			if (!OnTrigger && !Sound.isPlaying)
			{
				Sound.Play();
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (OnTrigger && !Sound.isPlaying)
			{
				Sound.Play();
			}
		}
	}
}
