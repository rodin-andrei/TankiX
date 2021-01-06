using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class EMPWaveGraphicsBehaviour : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystem waveParticleSystem;
		[SerializeField]
		private AudioSource waveSound;
	}
}
