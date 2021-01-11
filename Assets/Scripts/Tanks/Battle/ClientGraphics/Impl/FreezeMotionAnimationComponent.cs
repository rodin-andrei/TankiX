using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[RequireComponent(typeof(Animator))]
	public class FreezeMotionAnimationComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private float idleAnimationSpeedMultiplier = 0.125f;

		[SerializeField]
		private float workingAnimationSpeedMultiplier = 1f;

		[SerializeField]
		private string freezeAnimationSpeedCoeffName = "motionCoeff";

		[SerializeField]
		private float coefAcceleration = 0.6f;

		private int speedCoeffID;

		private Animator freezeAnimator;

		private float coeffChangeSpeed;

		private float currentSpeedMultiplier;

		private float freezeEnergyReloadingSpeed;

		private bool isWorking;

		private void Awake()
		{
			base.enabled = false;
		}

		private void StartMode(float currentEnergyLevel, bool isWorking)
		{
			float num = 1f - currentEnergyLevel;
			coeffChangeSpeed = (isWorking ? coefAcceleration : ((!(num > 0f)) ? (0f - coefAcceleration) : (0f - Mathf.Max(0f, (currentSpeedMultiplier - idleAnimationSpeedMultiplier) / num * freezeEnergyReloadingSpeed))));
			base.enabled = true;
			this.isWorking = isWorking;
		}

		private void Update()
		{
			currentSpeedMultiplier += coeffChangeSpeed * Time.deltaTime;
			if (currentSpeedMultiplier >= workingAnimationSpeedMultiplier)
			{
				currentSpeedMultiplier = workingAnimationSpeedMultiplier;
				if (isWorking)
				{
					base.enabled = false;
				}
			}
			if (currentSpeedMultiplier <= idleAnimationSpeedMultiplier)
			{
				currentSpeedMultiplier = idleAnimationSpeedMultiplier;
				if (!isWorking)
				{
					base.enabled = false;
				}
			}
			freezeAnimator.SetFloat(speedCoeffID, currentSpeedMultiplier);
		}

		public void Init(Animator animator, float energyReloadingSpeed)
		{
			freezeAnimator = animator;
			freezeEnergyReloadingSpeed = energyReloadingSpeed;
			speedCoeffID = Animator.StringToHash(freezeAnimationSpeedCoeffName);
			ResetMotion();
		}

		public void ResetMotion()
		{
			currentSpeedMultiplier = 0f;
			freezeAnimator.SetFloat(speedCoeffID, currentSpeedMultiplier);
			isWorking = false;
		}

		public void StartWorking(float currentEnergyLevel)
		{
			StartMode(currentEnergyLevel, true);
		}

		public void StartIdle(float currentEnergyLevel)
		{
			StartMode(currentEnergyLevel, false);
		}

		public void StopMotion()
		{
			freezeAnimator.SetFloat(speedCoeffID, 0f);
		}
	}
}
