using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateUserRankEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject effectPrefab;

		[SerializeField]
		private float finishEventTime = 7f;

		public GameObject EffectPrefab
		{
			get
			{
				return effectPrefab;
			}
		}

		public float FinishEventTime
		{
			get
			{
				return finishEventTime;
			}
		}
	}
}
