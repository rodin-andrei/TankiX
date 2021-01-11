using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectParticleMovement : MonoBehaviour
	{
		public Transform parent;

		private ParticleSystem particleSystem;

		private ParticleSystem.Particle[] particles = new ParticleSystem.Particle[1000];

		private Vector3 previousPosition;

		private Vector3 delta;

		private void Start()
		{
			particleSystem = GetComponent<ParticleSystem>();
			previousPosition = parent.position;
		}

		private void LateUpdate()
		{
			int num = particleSystem.GetParticles(particles);
			for (int i = 0; i < num; i++)
			{
				particles[i].position = particles[i].position + delta;
			}
			particleSystem.SetParticles(particles, num);
			delta = parent.position - previousPosition;
			previousPosition = parent.position;
		}
	}
}
