using System.Collections;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class EnergyBarGlow : HUDBar
	{
		[SerializeField]
		private Ruler fill;

		[SerializeField]
		private Ruler glow;

		[SerializeField]
		private Ruler energyInjectionGlow;

		[SerializeField]
		private BarFillEnd barFillEnd;

		private bool isBlinking;

		private float amountPerSegment = 1f;

		public override float CurrentValue
		{
			get
			{
				return currentValue;
			}
			set
			{
				currentValue = Clamp(value);
				ApplyFill();
			}
		}

		public override float AmountPerSegment
		{
			get
			{
				return amountPerSegment;
			}
			set
			{
				if (amountPerSegment != value)
				{
					amountPerSegment = value;
					UpdateSegments();
				}
			}
		}

		public void Blink(bool canShoot)
		{
			GetComponent<Animator>().SetBool("CanShoot", canShoot);
			GetComponent<Animator>().SetTrigger("Blink");
		}

		public void EnergyInjectionBlink(bool canShoot)
		{
			GetComponent<Animator>().SetBool("CanShoot", canShoot);
			GetComponent<Animator>().SetTrigger("EnergyInjectionBlink");
		}

		public void StartBlinking(bool canShoot)
		{
			if (!isBlinking)
			{
				StartCoroutine(BlinkCoroutine(canShoot));
			}
		}

		public void StopBlinking()
		{
			isBlinking = false;
		}

		private IEnumerator BlinkCoroutine(bool canShoot)
		{
			isBlinking = true;
			while (isBlinking)
			{
				Blink(canShoot);
				yield return new WaitForSeconds(0.5f);
			}
		}

		private void OnDisable()
		{
			StopBlinking();
		}

		private void ApplyFill()
		{
			fill.FillAmount = currentValue / maxValue;
			glow.FillAmount = fill.FillAmount;
			energyInjectionGlow.FillAmount = fill.FillAmount;
			barFillEnd.FillAmount = fill.FillAmount;
		}
	}
}
