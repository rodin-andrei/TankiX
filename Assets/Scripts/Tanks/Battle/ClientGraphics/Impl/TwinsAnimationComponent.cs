using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TwinsAnimationComponent : AbstractShotAnimationComponent
	{
		[SerializeField]
		private string[] twinsAnimationsNames = new string[2]
		{
			"shotLeft",
			"shotRight"
		};

		[SerializeField]
		private string[] twinsShotSpeedCoeffNames = new string[2]
		{
			"shotLeftSpeedCoeff",
			"shotRightSpeedCoeff"
		};

		[SerializeField]
		private AnimationClip[] twinsShotClips;

		private Animator twinsAnimator;

		private int[] twinsAnimationIDArray;

		private int[] twinsSpeedCoeffIDArray;

		private void ConvertParamsFromString2ID(string[] strArray, ref int[] IDArray)
		{
			int num = strArray.Length;
			IDArray = new int[num];
			for (int i = 0; i < num; i++)
			{
				IDArray[i] = Animator.StringToHash(strArray[i]);
			}
		}

		private void CalculateSpeedCoeffs(float optimalAnimationTime, int clipCount)
		{
			for (int i = 0; i < clipCount; i++)
			{
				AnimationClip shotAnimationClip = twinsShotClips[i];
				float value = CalculateShotSpeedCoeff(shotAnimationClip, optimalAnimationTime, false);
				twinsAnimator.SetFloat(twinsSpeedCoeffIDArray[i], value);
			}
		}

		public void Init(Animator animator, float cooldownTimeSec, float eShot, float energyReloadingSpeed)
		{
			twinsAnimator = animator;
			ConvertParamsFromString2ID(twinsAnimationsNames, ref twinsAnimationIDArray);
			ConvertParamsFromString2ID(twinsShotSpeedCoeffNames, ref twinsSpeedCoeffIDArray);
			float num = CalculateOptimalAnimationTime(energyReloadingSpeed, cooldownTimeSec, eShot);
			int num2 = twinsShotClips.Length;
			num *= (float)num2;
			CalculateSpeedCoeffs(num, num2);
		}

		public void Play(int index)
		{
			twinsAnimator.SetTrigger(twinsAnimationIDArray[index]);
		}
	}
}
