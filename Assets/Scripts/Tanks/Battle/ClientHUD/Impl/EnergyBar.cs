using System.Collections;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class EnergyBar : HUDBar
	{
		[SerializeField]
		private Ruler stroke;

		[SerializeField]
		private Ruler fill;

		[SerializeField]
		private Ruler glow;

		[SerializeField]
		private Ruler energyInjectionGlow;

		[SerializeField]
		private TankPartItemIcon turretIcon;

		private bool isBlinking;

		private float amountPerSegment = 1f;

		public long TurretId
		{
			set
			{
				turretIcon.SetIconWithName(value.ToString());
			}
		}

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
			Animator component = GetComponent<Animator>();
			if (component.isActiveAndEnabled)
			{
				component.SetBool("CanShoot", canShoot);
				component.SetTrigger("Blink");
			}
		}

		public void EnergyInjectionBlink(bool canShoot)
		{
			Animator component = GetComponent<Animator>();
			if (component.isActiveAndEnabled)
			{
				component.SetBool("CanShoot", canShoot);
				component.SetTrigger("EnergyInjectionBlink");
			}
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
			stroke.RectTransform.anchoredPosition = new Vector2(fill.RectTransform.rect.width * fill.FillAmount, stroke.RectTransform.anchoredPosition.y);
			stroke.FillAmount = 1f - fill.FillAmount;
			glow.FillAmount = fill.FillAmount;
			energyInjectionGlow.FillAmount = fill.FillAmount;
		}
	}
}
