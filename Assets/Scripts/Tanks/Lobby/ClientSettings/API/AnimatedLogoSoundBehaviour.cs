using UnityEngine;

namespace Tanks.Lobby.ClientSettings.API
{
	public class AnimatedLogoSoundBehaviour : MonoBehaviour
	{
		[SerializeField]
		private AudioSource source;

		private void Start()
		{
			source.Play();
		}
	}
}
