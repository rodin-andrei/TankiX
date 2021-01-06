using Platform.Library.ClientUnityIntegration.API;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ParticleSystemEffectsComponent : BehaviourComponent
	{
		[SerializeField]
		private List<ParticleSystem> particleSystems;
	}
}
