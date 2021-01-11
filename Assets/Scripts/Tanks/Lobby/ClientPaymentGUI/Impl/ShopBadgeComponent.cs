using System;
using System.Collections.Generic;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class ShopBadgeComponent : BehaviourComponent
	{
		[Serializable]
		private class PromoBadge
		{
			public string Key;

			public Sprite Sprite;
		}

		[SerializeField]
		private Image saleIcon;

		[SerializeField]
		private Image specialIcon;

		[SerializeField]
		private Image promoIcon;

		[SerializeField]
		private List<PromoBadge> promoBadges;

		private static bool promoAvailable;

		private static bool saleAvailable;

		private static bool specialOfferAvailable;

		private static bool personalDiscountAvailable;

		private static bool notificationAvailable = true;

		public bool PromoAvailable
		{
			get
			{
				return promoAvailable;
			}
		}

		public bool SaleAvailable
		{
			get
			{
				return saleAvailable;
			}
			set
			{
				saleAvailable = value;
				UpdateIcons();
			}
		}

		public bool SpecialOfferAvailable
		{
			get
			{
				return specialOfferAvailable;
			}
			set
			{
				specialOfferAvailable = value;
				UpdateIcons();
			}
		}

		public bool PersonalDiscountAvailable
		{
			get
			{
				return personalDiscountAvailable;
			}
			set
			{
				personalDiscountAvailable = value;
				UpdateIcons();
			}
		}

		public bool NotificationAvailable
		{
			get
			{
				return notificationAvailable;
			}
			set
			{
				notificationAvailable = value;
				UpdateIcons();
			}
		}

		public void SetPromoAvailable(string Key, bool available)
		{
			if (available && promoBadges.Exists((PromoBadge x) => x.Key == Key))
			{
				promoAvailable = true;
				promoIcon.sprite = promoBadges.Find((PromoBadge x) => x.Key == Key).Sprite;
			}
			else
			{
				promoAvailable = false;
			}
			UpdateIcons();
		}

		private void UpdateIcons()
		{
			if (specialIcon == null || saleIcon == null || promoIcon == null)
			{
				return;
			}
			if (promoAvailable)
			{
				specialIcon.gameObject.SetActive(false);
				saleIcon.gameObject.SetActive(false);
				promoIcon.gameObject.SetActive(true);
				return;
			}
			promoIcon.gameObject.SetActive(false);
			if (personalDiscountAvailable && notificationAvailable)
			{
				specialIcon.gameObject.SetActive(true);
				saleIcon.gameObject.SetActive(false);
			}
			else if (saleAvailable && notificationAvailable)
			{
				specialIcon.gameObject.SetActive(false);
				saleIcon.gameObject.SetActive(true);
			}
			else
			{
				specialIcon.gameObject.SetActive(false);
				saleIcon.gameObject.SetActive(false);
			}
		}

		private void OnEnable()
		{
			NotificationAvailable = notificationAvailable;
		}
	}
}
