using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class EMPHitVisualEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private ParticleSystem HitPrefab;

		public ParticleSystem EmpHitPrefab
		{
			get
			{
				return HitPrefab;
			}
		}
	}
}
