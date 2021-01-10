using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class BrokenEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject brokenEffect;
		[SerializeField]
		private string trackObjectNamePrefix;
		[SerializeField]
		private string trackMaterialNamePrefix;
		public GameObject effectInstance;
		public float partDetachProbability;
		public float LifeTime;
	}
}
