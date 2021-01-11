using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(NormalizedAnimatedValue))]
	public abstract class AnimatedIndicatorWithFinishComponent<T> : MonoBehaviour where T : Platform.Kernel.ECS.ClientEntitySystem.API.Component, new()
	{
		private Entity screenEntity;

		private bool animationFinished;

		private void OnEnable()
		{
			animationFinished = false;
		}

		protected void SetEntity(Entity screenEntity)
		{
			this.screenEntity = screenEntity;
		}

		private void CheckIfAnimationFinished(float currentVal = 1f, float targetVal = 1f)
		{
			if (!animationFinished && MathUtil.NearlyEqual(currentVal, targetVal, 0.005f))
			{
				SetAnimationFinished();
			}
		}

		private void SetAnimationFinished()
		{
			animationFinished = true;
			screenEntity.AddComponent<T>();
		}

		protected void TryToSetAnimationFinished(float currentVal, float targetVal)
		{
			CheckIfAnimationFinished(currentVal, targetVal);
		}

		protected void TryToSetAnimationFinished()
		{
			if (!animationFinished)
			{
				SetAnimationFinished();
			}
		}
	}
}
