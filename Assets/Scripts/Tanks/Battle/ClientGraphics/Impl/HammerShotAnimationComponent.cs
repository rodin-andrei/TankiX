using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class HammerShotAnimationComponent : AnimationTriggerComponent
	{
		[SerializeField]
		private string shotTriggerName;
		[SerializeField]
		private string isReloadingName;
		[SerializeField]
		private string resetTriggerName;
		[SerializeField]
		private string reloadingSpeedName;
		[SerializeField]
		private string cooldownSpeedName;
		[SerializeField]
		private float idleTimeAfterCooldown;
		[SerializeField]
		private AnimationClip reloadClip;
		[SerializeField]
		private AnimationClip shotClip;
	}
}
