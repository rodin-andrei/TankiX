using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class SoundFadeBehaviour : MonoBehaviour
	{
		[SerializeField]
		private AudioSource source;
		[SerializeField]
		private float fadeOutTime;
	}
}
