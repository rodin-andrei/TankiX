using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class WeaponStreamHitGraphicsEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private ParticleSystem hitStaticPrefab;
		[SerializeField]
		private ParticleSystem hitTargetPrefab;
		[SerializeField]
		private float hitOffset;
	}
}
