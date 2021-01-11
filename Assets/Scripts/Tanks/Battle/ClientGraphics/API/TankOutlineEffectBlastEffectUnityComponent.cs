using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class TankOutlineEffectBlastEffectUnityComponent : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystem blastParticleSystem;

		public void StartEffect()
		{
			blastParticleSystem.Play();
		}

		public void StopEffect()
		{
			blastParticleSystem.Stop();
		}
	}
}
