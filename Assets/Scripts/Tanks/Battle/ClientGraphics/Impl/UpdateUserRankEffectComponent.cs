using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateUserRankEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject effectPrefab;
		[SerializeField]
		private float finishEventTime;
	}
}
