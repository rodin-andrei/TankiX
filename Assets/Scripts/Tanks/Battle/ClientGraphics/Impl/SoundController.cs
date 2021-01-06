using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class SoundController : MonoBehaviour
	{
		[SerializeField]
		private float playingDelaySec;
		[SerializeField]
		private float playingOffsetSec;
		[SerializeField]
		private float fadeOutTimeSec;
		[SerializeField]
		private float fadeInTimeSec;
		[SerializeField]
		private float minVolume;
		[SerializeField]
		private float maxVolume;
		[SerializeField]
		private AudioSource source;
	}
}
