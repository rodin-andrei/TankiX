using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class FadeSoundFilter : MonoBehaviour
	{
		[SerializeField]
		protected AudioSource source;
		[SerializeField]
		private float fadeInTimeSec;
		[SerializeField]
		private float fadeOutTimeSec;
	}
}
