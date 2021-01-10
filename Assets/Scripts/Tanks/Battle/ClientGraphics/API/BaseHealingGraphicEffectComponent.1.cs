using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class BaseHealingGraphicEffectComponent<T> : BehaviourComponent
	{
		[SerializeField]
		private float durationInLoopMode;
		[SerializeField]
		private float arbitraryDuration;
		[SerializeField]
		private float pauseInLoopMode;
		[SerializeField]
		private float waveAnimationTime;
		[SerializeField]
		private Texture2D repairTexture;
		[SerializeField]
		private AudioSource sound;
		[SerializeField]
		private AnimationCurve straightStepCurve;
		[SerializeField]
		private AnimationCurve reverseStepCurve;
	}
}
