using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[RequireComponent(typeof(ParticleSystem))]
	public class EMPWaveGraphicsBehaviour : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystem waveParticleSystem;

		[SerializeField]
		private AudioSource waveSound;

		public ParticleSystem WaveParticleSystem
		{
			get
			{
				return waveParticleSystem;
			}
		}

		public AudioSource WaveSound
		{
			get
			{
				return waveSound;
			}
		}
	}
}
