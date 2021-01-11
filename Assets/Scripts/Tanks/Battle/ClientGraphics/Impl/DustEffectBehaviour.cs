using System;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[Serializable]
	public class DustEffectBehaviour : MonoBehaviour
	{
		[Serializable]
		public struct RandomRange
		{
			public float min;

			public float max;

			public float RandomValue
			{
				get
				{
					return UnityEngine.Random.Range(min, max);
				}
			}
		}

		[Serializable]
		public struct RandomColor
		{
			public Color min;

			public Color max;

			public Color RandomValue
			{
				get
				{
					return Color.Lerp(min, max, UnityEngine.Random.value);
				}
			}
		}

		public enum SurfaceType
		{
			None,
			Soil,
			Sand,
			Grass,
			Metal,
			Concrete
		}

		public SurfaceType surface;

		public ParticleSystem particleSystem;

		public RandomRange movementSpeedThreshold;

		public RandomRange movementEmissionRate;

		public RandomRange collisionEmissionRate;

		public RandomRange particleLifetime;

		public RandomRange particleSpeed;

		public RandomRange particleSize;

		public RandomRange particleRotation;

		public RandomColor particleColor;

		public float inheritSpeed;

		public float landingCompressionThreshold;

		public void TryEmitParticle(Vector3 point, Vector3 inheritedVelocity)
		{
			float magnitude = inheritedVelocity.magnitude;
			float min = movementSpeedThreshold.min;
			if (magnitude > movementSpeedThreshold.min)
			{
				float num = Mathf.Clamp01((magnitude - min) / (movementSpeedThreshold.max - min));
				num = (1f + num) / 2f;
				Vector3 normalized = new Vector3(UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(0.9f, 1f), UnityEngine.Random.Range(-0.1f, 0.1f)).normalized;
				ParticleSystem.Particle particle = GetParticle(point, normalized, inheritedVelocity, num);
				particleSystem.Emit(particle);
			}
		}

		private ParticleSystem.Particle GetParticle(Vector3 point, Vector3 velocityVector, Vector3 inheritedVelocity, float scale)
		{
			ParticleSystem.Particle particle = default(ParticleSystem.Particle);
			particle.randomSeed = (uint)(UnityEngine.Random.value * 4.2949673E+09f);
			particle.position = point;
			particle.rotation = particleRotation.RandomValue;
			particle.velocity = velocityVector * particleSpeed.RandomValue * scale + inheritedVelocity * inheritSpeed;
			particle.size = particleSize.RandomValue * scale;
			particle.startLifetime = particleLifetime.RandomValue;
			particle.color = particleColor.RandomValue * new Color(1f, 1f, 1f, scale * scale);
			ParticleSystem.Particle result = particle;
			result.remainingLifetime = result.startLifetime;
			return result;
		}
	}
}
