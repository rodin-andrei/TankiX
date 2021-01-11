using System.Collections;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	public class UserMoneyIndicatorComponent : BehaviourComponent
	{
		[SerializeField]
		private Text moneyText;

		private const float setMoneyAnimationSpeedPerSec = 100f;

		private const float setMoneyAnimationMaxTime = 5f;

		private Animator animator;

		private long money;

		private long moneySuspended;

		private long moneyExpected;

		private Animator Animator
		{
			get
			{
				if (animator == null)
				{
					animator = GetComponent<Animator>();
				}
				return animator;
			}
		}

		public void SetMoneyImmediately(long value)
		{
			money = value;
			ApplyMoney();
		}

		public void Suspend(long value)
		{
			moneySuspended = value;
			ApplyMoney();
		}

		public void SetMoneyAnimated(long value)
		{
			if (moneyExpected > 0 && !money.Equals(moneyExpected))
			{
				StopAllCoroutines();
				money = moneyExpected;
				ApplyMoney();
			}
			moneyExpected = value;
			StartCoroutine(ShowAnimation(value));
		}

		private IEnumerator ShowAnimation(long newMoneyValue)
		{
			float moneyDiff = newMoneyValue - money;
			float setMoneyAnimationTime = Mathf.Min(Mathf.Abs(moneyDiff) / 100f, 5f);
			long moneyDiffSign = (long)Mathf.Sign(moneyDiff);
			float delay = setMoneyAnimationTime / Mathf.Abs(moneyDiff);
			int step = Mathf.CeilToInt(0.02f / delay);
			while (Mathf.Abs(money - newMoneyValue) > (float)step)
			{
				yield return new WaitForSeconds(delay);
				money += moneyDiffSign * step;
				ApplyMoney();
			}
			yield return new WaitForSeconds(delay);
			money = newMoneyValue;
			ApplyMoney();
			Animator.SetTrigger("flash");
		}

		private void ApplyMoney()
		{
			moneyText.text = (money - moneySuspended).ToStringSeparatedByThousands();
		}
	}
}
