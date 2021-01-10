using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class LimitedInstancingSoundEffectBehaviour : MonoBehaviour
	{
		[SerializeField]
		private AudioSource source;
		[SerializeField]
		private float playDelay;
	}
}
