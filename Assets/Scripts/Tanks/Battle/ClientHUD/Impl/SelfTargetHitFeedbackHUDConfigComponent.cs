using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class SelfTargetHitFeedbackHUDConfigComponent : BehaviourComponent
	{
		[SerializeField]
		private SelfTargetHitFeedbackHUDInstanceComponent effectPrefab;
		[SerializeField]
		private BoxCollider coliderHelper;
	}
}
