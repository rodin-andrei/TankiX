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
		}

		[Serializable]
		public struct RandomColor
		{
			public Color min;
			public Color max;
		}

		public enum SurfaceType
		{
			None = 0,
			Soil = 1,
			Sand = 2,
			Grass = 3,
			Metal = 4,
			Concrete = 5,
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
	}
}
