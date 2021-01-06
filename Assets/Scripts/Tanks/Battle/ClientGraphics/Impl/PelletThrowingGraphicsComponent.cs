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
		private float sparklesMinLifetime;
		[SerializeField]
		private float sparklesMaxLifetime;
		[SerializeField]
		private float hitReflectVeolcity;
	}
}
