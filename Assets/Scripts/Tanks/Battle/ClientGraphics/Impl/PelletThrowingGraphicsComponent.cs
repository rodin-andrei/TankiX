using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class PelletThrowingGraphicsComponent : BehaviourComponent
	{
		[SerializeField]
		private ParticleSystem trails;

		[SerializeField]
		private ParticleSystem hits;

		[SerializeField]
		private float sparklesMinLifetime = 0.25f;

		[SerializeField]
		private float sparklesMaxLifetime = 0.5f;

		[SerializeField]
		private float hitReflectVeolcity = 0.05f;

		public ParticleSystem Trails
		{
			get
			{
				return trails;
			}
			set
			{
				trails = value;
			}
		}

		public ParticleSystem Hits
		{
			get
			{
				return hits;
			}
			set
			{
				hits = value;
			}
		}

		public float SparklesMinLifetime
		{
			get
			{
				return sparklesMinLifetime;
			}
			set
			{
				sparklesMinLifetime = value;
			}
		}

		public float SparklesMaxLifetime
		{
			get
			{
				return sparklesMaxLifetime;
			}
			set
			{
				sparklesMaxLifetime = value;
			}
		}

		public float HitReflectVeolcity
		{
			get
			{
				return hitReflectVeolcity;
			}
			set
			{
				hitReflectVeolcity = value;
			}
		}
	}
}
