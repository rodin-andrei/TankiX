using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[RequireComponent(typeof(Animator))]
	public class IsisWorkingAnimationComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private string workingName = "isWorking";

		private int workingID;

		private Animator isisAnimator;

		public void InitIsisWorkingAnimation(Animator animator)
		{
			isisAnimator = animator;
			workingID = Animator.StringToHash(workingName);
		}

		public void StartWorkingAnimation()
		{
			isisAnimator.SetBool(workingID, true);
		}

		public void StopWorkingAnimation()
		{
			isisAnimator.SetBool(workingID, false);
		}
	}
}
