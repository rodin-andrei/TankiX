using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[RequireComponent(typeof(Animator))]
	public class HammerShotAnimationComponent : AnimationTriggerComponent
	{
		[SerializeField]
		private string shotTriggerName = "shot";

		[SerializeField]
		private string isReloadingName = "isReloading";

		[SerializeField]
		private string resetTriggerName = "reset";

		[SerializeField]
		private string reloadingSpeedName = "reloadSpeedCoeff";

		[SerializeField]
		private string cooldownSpeedName = "cooldownSpeedCoeff";

		[SerializeField]
		private float idleTimeAfterCooldown = 0.5f;

		[SerializeField]
		private AnimationClip reloadClip;

		[SerializeField]
		private AnimationClip shotClip;

		private int shotTriggerID;

		private int isReloadingID;

		private int resetTriggerID;

		private int reloadingSpeedID;

		private int cooldownSpeedID;

		private Animator hammerAnimator;

		public AnimationClip ReloadClip
		{
			get
			{
				return reloadClip;
			}
			set
			{
				reloadClip = value;
			}
		}

		public float RequiredReloadingTime
		{
			get;
			set;
		}

		private void OnChargeLastCartridge()
		{
			ProvideEvent<HammerChargeLastCartridgeEvent>();
		}

		private void OnBlowOff()
		{
			ProvideEvent<HammerBlowOffEvent>();
		}

		private void OnOffset()
		{
			ProvideEvent<HammerOffsetEvent>();
		}

		private void OnRoll()
		{
			ProvideEvent<HammerRollEvent>();
		}

		private void OnCartridgeClick()
		{
			ProvideEvent<HammerCartridgeClickEvent>();
		}

		private void OnMagazineShot()
		{
			ProvideEvent<HammerMagazineShotEvent>();
		}

		private void OnBounce()
		{
			ProvideEvent<HammerBounceEvent>();
		}

		private void OnCooldown()
		{
			ProvideEvent<HammerCooldownEvent>();
		}

		public void InitHammerShotAnimation(Entity entity, Animator animator, float reloadingTimeSec, float shotCooldownLogicTime)
		{
			shotTriggerID = Animator.StringToHash(shotTriggerName);
			isReloadingID = Animator.StringToHash(isReloadingName);
			resetTriggerID = Animator.StringToHash(resetTriggerName);
			reloadingSpeedID = Animator.StringToHash(reloadingSpeedName);
			cooldownSpeedID = Animator.StringToHash(cooldownSpeedName);
			float length = reloadClip.length;
			float length2 = shotClip.length;
			float num = shotCooldownLogicTime - idleTimeAfterCooldown;
			float num3 = (RequiredReloadingTime = reloadingTimeSec - num);
			float value = length / num3;
			float value2 = length2 / num;
			animator.SetFloat(reloadingSpeedID, value);
			animator.SetFloat(cooldownSpeedID, value2);
			hammerAnimator = animator;
			base.Entity = entity;
			base.enabled = true;
		}

		public void PlayShot()
		{
			Play(false);
		}

		public void PlayShotAndReload()
		{
			Play(true);
		}

		public void Reset()
		{
			hammerAnimator.ResetTrigger(shotTriggerID);
			hammerAnimator.SetTrigger(resetTriggerID);
		}

		private void Play(bool needReload)
		{
			hammerAnimator.ResetTrigger(resetTriggerID);
			hammerAnimator.SetTrigger(shotTriggerID);
			hammerAnimator.SetBool(isReloadingID, needReload);
		}
	}
}
