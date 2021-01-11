using UnityEngine;

namespace Tanks.Lobby.ClientSettings.API
{
	[RequireComponent(typeof(AudioSource))]
	public class SoundEffectSettings : MonoBehaviour
	{
		[SerializeField]
		private AudioSource source;

		public AudioSource Source
		{
			get
			{
				return source;
			}
		}
	}
}
