using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[RequireComponent(typeof(Animator))]
	public class VulcanTurbineAnimationComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private string turbineStateName = "TurbineRotation";

		[SerializeField]
		private int turbineLayerIndex;

		[SerializeField]
		private string turbineCoeffName = "turbineCoeff";

		[SerializeField]
		private string turbineStopName = "stopTurbine";

		[SerializeField]
		private int turbineMaxSpeedCoeff = 1;

		private int turbineStateID;

		private int turbineStopID;

		private int turbineCoeffID;

		private Animator vulcanAnimator;

		private float currentNrmTime;

		private float speedUpAcceleration;

		private float slowDownAcceleration;

		private float currentAcceleration;

		private float currentSpeed;

		private bool isRunningTurbine;

		private void Awake()
		{
			base.enabled = false;
		}

		private void Update()
		{
			currentSpeed += currentAcceleration * Time.deltaTime;
			currentSpeed = Mathf.Clamp(currentSpeed, 0f, turbineMaxSpeedCoeff);
			vulcanAnimator.SetFloat(turbineCoeffID, currentSpeed);
			if (currentSpeed <= 0f)
			{
				StopTurbine();
			}
		}

		public void Init(Animator animator, float speedUpTime, float slowDownTime)
		{
			vulcanAnimator = animator;
			turbineStateID = Animator.StringToHash(turbineStateName);
			turbineCoeffID = Animator.StringToHash(turbineCoeffName);
			turbineStopID = Animator.StringToHash(turbineStopName);
			speedUpAcceleration = (float)turbineMaxSpeedCoeff / speedUpTime;
			slowDownAcceleration = (float)(-turbineMaxSpeedCoeff) / slowDownTime;
			currentNrmTime = 0f;
			currentSpeed = 0f;
			vulcanAnimator.SetFloat(turbineCoeffID, currentSpeed);
			isRunningTurbine = false;
		}

		public void StopTurbine()
		{
			currentSpeed = 0f;
			currentNrmTime = Mathf.Repeat(vulcanAnimator.GetCurrentAnimatorStateInfo(turbineLayerIndex).normalizedTime, 1f);
			vulcanAnimator.SetTrigger(turbineStopID);
			isRunningTurbine = false;
			base.enabled = false;
		}

		public void StartSpeedUp()
		{
			StartChangeSpeedPhase(true);
		}

		public void StartSlowDown()
		{
			StartChangeSpeedPhase(false);
		}

		public void StartShooting()
		{
			PlayAnimatorIfNeed();
			currentSpeed = turbineMaxSpeedCoeff;
			vulcanAnimator.SetFloat(turbineCoeffID, currentSpeed);
			base.enabled = false;
			isRunningTurbine = true;
		}

		private void StartChangeSpeedPhase(bool isSpeedUp)
		{
			vulcanAnimator.ResetTrigger(turbineStopID);
			currentAcceleration = ((!isSpeedUp) ? slowDownAcceleration : speedUpAcceleration);
			PlayAnimatorIfNeed();
			base.enabled = true;
			isRunningTurbine = true;
		}

		private void PlayAnimatorIfNeed()
		{
			if (!isRunningTurbine)
			{
				vulcanAnimator.Play(turbineStateID, turbineLayerIndex, currentNrmTime);
			}
		}
	}
}
