using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShotAnimationComponent : AbstractShotAnimationComponent
	{
		[SerializeField]
		private AnimationClip shotAnimationClip;

		[SerializeField]
		private bool canPlaySlower = true;

		private Animator weaponAnimator;

		private int shotTriggerID;

		private int shotSpeedCoeffID;

		public void Init(Animator animator, float cooldownTimeSec, float eShot, float energyReloadingSpeed)
		{
			weaponAnimator = animator;
			shotTriggerID = Animator.StringToHash(AnimationParameters.SHOT_TRIGGER);
			shotSpeedCoeffID = Animator.StringToHash(AnimationParameters.SHOT_SPEED_COEFF);
			float optimalAnimationTime = CalculateOptimalAnimationTime(energyReloadingSpeed, cooldownTimeSec, eShot);
			float value = CalculateShotSpeedCoeff(shotAnimationClip, optimalAnimationTime, canPlaySlower);
			weaponAnimator.SetFloat(shotSpeedCoeffID, value);
		}

		public void Play()
		{
			weaponAnimator.SetTrigger(shotTriggerID);
		}
	}
}
