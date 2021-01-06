using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class HammerHitSoundEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject staticHitSoundAsset;
		[SerializeField]
		private GameObject targetHitSoundAsset;
		[SerializeField]
		private float staticHitSoundDuration;
		[SerializeField]
		private float targetHitSoundDuration;
	}
}
