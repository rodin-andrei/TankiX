using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShotAnimationComponent : AbstractShotAnimationComponent
	{
		[SerializeField]
		private AnimationClip shotAnimationClip;
		[SerializeField]
		private bool canPlaySlower;
	}
}
