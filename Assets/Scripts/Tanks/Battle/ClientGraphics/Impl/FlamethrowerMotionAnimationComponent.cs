using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[RequireComponent(typeof(Animator))]
	public class FlamethrowerMotionAnimationComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private string motionCoeffName = "motionCoeff";

		[SerializeField]
		private string stopMotionName = "stopMotion";

		[SerializeField]
		private float idleMotionCoeff = -0.25f;

		[SerializeField]
		private float workingMotionCoeff = 1f;

		[SerializeField]
		private string motionStateName = "Motion";

		[SerializeField]
		private int motionStateLayerIndex;

		private int motionCoeffID;

		private int stopMotionID;

		private int motionStateID;

		private float currentNrmTime;

		private Animator flamethrowerAnimator;

		private bool isWorkingMotion;

		private void Awake()
		{
			base.enabled = false;
		}

		private void Update()
		{
			float num = currentNrmTime;
			float normalizedTime = flamethrowerAnimator.GetCurrentAnimatorStateInfo(motionStateLayerIndex).normalizedTime;
			float num2 = normalizedTime - num;
			currentNrmTime += num2;
			currentNrmTime = Mathf.Repeat(currentNrmTime, 1f);
		}

		private void StartMotion(bool isWorking)
		{
			isWorkingMotion = isWorking;
			flamethrowerAnimator.ResetTrigger(stopMotionID);
			flamethrowerAnimator.SetFloat(motionCoeffID, (!isWorkingMotion) ? idleMotionCoeff : workingMotionCoeff);
			flamethrowerAnimator.Play(motionStateID, motionStateLayerIndex, currentNrmTime);
			base.enabled = true;
		}

		public void Init(Animator animator)
		{
			flamethrowerAnimator = animator;
			currentNrmTime = 0f;
			motionCoeffID = Animator.StringToHash(motionCoeffName);
			stopMotionID = Animator.StringToHash(stopMotionName);
			motionStateID = Animator.StringToHash(motionStateName);
		}

		public void StartWorkingMotion()
		{
			StartMotion(true);
		}

		public void StartIdleMotion()
		{
			StartMotion(false);
		}

		public void StopMotion()
		{
			flamethrowerAnimator.SetTrigger(stopMotionID);
			base.enabled = false;
		}
	}
}
