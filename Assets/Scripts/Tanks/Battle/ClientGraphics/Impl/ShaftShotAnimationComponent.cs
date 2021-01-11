using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftShotAnimationComponent : AbstractShotAnimationComponent
	{
		[SerializeField]
		private string shotTriggerName = "shot";

		[SerializeField]
		private string stopTriggerName = "stop";

		[SerializeField]
		private string reloadSpeedName = "reloadCoeff";

		[SerializeField]
		private AnimationClip reloadShaftClip;

		[SerializeField]
		private AnimationClip shaftShotClip;

		[SerializeField]
		private float minReloadingSpeedCoeff = 0.5f;

		private int shotTriggerID;

		private int stopTriggerID;

		private int reloadSpeedID;

		private float decelerationCoeff;

		private Animator shaftAnimator;

		private float maxReloadingSpeedCoeff;

		private float reloadSpeedCoeff;

		private float ReloadSpeedCoeff
		{
			get
			{
				return reloadSpeedCoeff;
			}
			set
			{
				reloadSpeedCoeff = value;
				shaftAnimator.SetFloat(reloadSpeedID, reloadSpeedCoeff);
			}
		}

		public float CooldownAnimationTime
		{
			get;
			set;
		}

		public void Init(Animator animator, float cooldownTimeSec, float eShot, float energyReloadingSpeed, float unloadEnergyPerAimingShot)
		{
			stopTriggerID = Animator.StringToHash(stopTriggerName);
			shotTriggerID = Animator.StringToHash(shotTriggerName);
			reloadSpeedID = Animator.StringToHash(reloadSpeedName);
			float b = CalculateOptimalAnimationTime(energyReloadingSpeed, cooldownTimeSec, eShot);
			float num = Mathf.Clamp01(1f - unloadEnergyPerAimingShot);
			float num2 = Mathf.Clamp01(num + energyReloadingSpeed * cooldownTimeSec);
			float num3 = Mathf.Clamp01(eShot - num2);
			float num4 = num3 / energyReloadingSpeed;
			float a = cooldownTimeSec + num4;
			float num5 = Mathf.Min(a, b);
			float length = shaftShotClip.length;
			CooldownAnimationTime = num5 - length;
			float length2 = reloadShaftClip.length;
			maxReloadingSpeedCoeff = 2f * length2 / CooldownAnimationTime - minReloadingSpeedCoeff;
			decelerationCoeff = (maxReloadingSpeedCoeff - minReloadingSpeedCoeff) / CooldownAnimationTime;
			shaftAnimator = animator;
		}

		public void PlayShot()
		{
			ReloadSpeedCoeff = maxReloadingSpeedCoeff;
			shaftAnimator.SetTrigger(shotTriggerID);
		}

		public void UpdateShotCooldownAnimation(float dt)
		{
			ReloadSpeedCoeff -= decelerationCoeff * dt;
		}

		public void Stop()
		{
			shaftAnimator.SetTrigger(stopTriggerID);
		}
	}
}
