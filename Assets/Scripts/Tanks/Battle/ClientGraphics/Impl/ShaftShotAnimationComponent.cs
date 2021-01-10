using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftShotAnimationComponent : AbstractShotAnimationComponent
	{
		[SerializeField]
		private string shotTriggerName;
		[SerializeField]
		private string stopTriggerName;
		[SerializeField]
		private string reloadSpeedName;
		[SerializeField]
		private AnimationClip reloadShaftClip;
		[SerializeField]
		private AnimationClip shaftShotClip;
		[SerializeField]
		private float minReloadingSpeedCoeff;
	}
}
