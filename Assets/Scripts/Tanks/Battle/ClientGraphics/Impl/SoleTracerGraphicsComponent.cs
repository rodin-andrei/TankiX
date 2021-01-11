using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class SoleTracerGraphicsComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private ParticleSystem tracer;

		[SerializeField]
		private float maxTime = 0.2f;

		public ParticleSystem Tracer
		{
			get
			{
				return tracer;
			}
			set
			{
				tracer = value;
			}
		}

		public float MaxTime
		{
			get
			{
				return maxTime;
			}
			set
			{
				maxTime = value;
			}
		}
	}
}
