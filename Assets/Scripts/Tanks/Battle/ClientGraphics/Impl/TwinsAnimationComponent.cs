using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TwinsAnimationComponent : AbstractShotAnimationComponent
	{
		[SerializeField]
		private string[] twinsAnimationsNames;
		[SerializeField]
		private string[] twinsShotSpeedCoeffNames;
		[SerializeField]
		private AnimationClip[] twinsShotClips;
	}
}
