using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[RequireComponent(typeof(Animator))]
	public class RailgunAnimationComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private string railgunChargingTriggerName = "railgunCharging";

		[SerializeField]
		private string railgunStartReloadingName = "startReloading";

		[SerializeField]
		private string railgunStopReloadingName = "stopReloading";

		[SerializeField]
		private string railgunStopAnimationName = "stopAnyActions";

		[SerializeField]
		private string railgunReloadingSpeedCoeffName = "reloadingSpeedCoeff";

		[SerializeField]
		private string railgunChargeSpeedCoeffName = "chargeSpeedCoeff";

		[SerializeField]
		private int railgunReloadingCyclesCount = 2;

		[SerializeField]
		private AnimationClip reloadClip;

		[SerializeField]
		private AnimationClip chargeClip;

		private int railgunChargingTriggerID;

		private int railgunReloadingSpeedCoeffID;

		private int railgunChargeSpeedCoeffID;

		private int railgunStartReloadingID;

		private int railgunStopReloadingID;

		private int railgunStopAnimationID;

		private Animator railgunAnimator;

		public void InitRailgunAnimation(Animator animator, float reloadingSpeed, float chargingTime)
		{
			railgunChargingTriggerID = Animator.StringToHash(railgunChargingTriggerName);
			railgunStartReloadingID = Animator.StringToHash(railgunStartReloadingName);
			railgunStopReloadingID = Animator.StringToHash(railgunStopReloadingName);
			railgunStopAnimationID = Animator.StringToHash(railgunStopAnimationName);
			railgunReloadingSpeedCoeffID = Animator.StringToHash(railgunReloadingSpeedCoeffName);
			railgunChargeSpeedCoeffID = Animator.StringToHash(railgunChargeSpeedCoeffName);
			railgunAnimator = animator;
			float length = reloadClip.length;
			float value = reloadingSpeed * (float)railgunReloadingCyclesCount * length;
			float length2 = chargeClip.length;
			float value2 = length2 / chargingTime;
			animator.SetFloat(railgunReloadingSpeedCoeffID, value);
			animator.SetFloat(railgunChargeSpeedCoeffID, value2);
		}

		public void StartChargingAnimation()
		{
			railgunAnimator.ResetTrigger(railgunStopReloadingID);
			railgunAnimator.SetTrigger(railgunChargingTriggerID);
			railgunAnimator.Update(0f);
		}

		public void StopAnyRailgunAnimation()
		{
			railgunAnimator.SetTrigger(railgunStopAnimationID);
		}

		public void StartReloading()
		{
			railgunAnimator.ResetTrigger(railgunStopReloadingID);
			railgunAnimator.SetTrigger(railgunStartReloadingID);
		}

		public void StopReloading()
		{
			railgunAnimator.SetTrigger(railgunStopReloadingID);
		}
	}
}
