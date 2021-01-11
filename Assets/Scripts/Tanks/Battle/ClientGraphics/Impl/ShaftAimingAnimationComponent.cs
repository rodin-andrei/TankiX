using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[RequireComponent(typeof(Animator))]
	public class ShaftAimingAnimationComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private string aimingPropertyName = "isAiming";

		private int aimingPropertyID;

		private Animator shaftAimingAnimator;

		public void InitShaftAimingAnimation(Animator animator)
		{
			shaftAimingAnimator = animator;
			aimingPropertyID = Animator.StringToHash(aimingPropertyName);
		}

		public void StartAiming()
		{
			shaftAimingAnimator.SetBool(aimingPropertyID, true);
		}

		public void StopAiming()
		{
			shaftAimingAnimator.SetBool(aimingPropertyID, false);
		}
	}
}
