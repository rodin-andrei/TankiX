using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class SoundFadeBehaviour : MonoBehaviour
	{
		[SerializeField]
		private AudioSource source;

		[SerializeField]
		private float fadeOutTime = 1.5f;

		private float fadeSpeed;

		private void Awake()
		{
			fadeSpeed = 1f / fadeOutTime;
		}

		private void Update()
		{
			source.volume -= fadeSpeed * Time.deltaTime;
		}
	}
}
