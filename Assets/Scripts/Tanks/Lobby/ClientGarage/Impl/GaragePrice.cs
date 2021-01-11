using System.Collections.Generic;
using Platform.Library.ClientDataStructures.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientProfile.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class GaragePrice : MonoBehaviour
	{
		public enum PriceType
		{
			XCrystals,
			Crystals
		}

		[SerializeField]
		private bool needUpdateColor = true;

		[SerializeField]
		private PaletteColorField redColor;

		[SerializeField]
		private PaletteColorField normalColor;

		[SerializeField]
		private PriceType priceType;

		private static HashSet<GaragePrice> visiblePrices = new HashSet<GaragePrice>();

		private int value;

		private int oldValue;

		public bool NeedUpdateColor
		{
			get
			{
				return needUpdateColor;
			}
			set
			{
				needUpdateColor = value;
			}
		}

		public static void UpdatePrices()
		{
			visiblePrices.ForEach(delegate(GaragePrice p)
			{
				p.UpdatePrice();
			});
		}

		private void OnEnable()
		{
			visiblePrices.Add(this);
		}

		private void OnDisable()
		{
			visiblePrices.Remove(this);
		}

		public void SetPrice(int oldPrice, int price)
		{
			oldValue = oldPrice;
			value = price;
			UpdatePrice();
		}

		private void UpdatePrice()
		{
			TextMeshProUGUI component = GetComponent<TextMeshProUGUI>();
			if (value < oldValue && oldValue > 0)
			{
				component.text = string.Format("{0} <#787878><s>{1}</s></color>", value.ToStringSeparatedByThousands(), oldValue.ToStringSeparatedByThousands());
			}
			else
			{
				component.text = value.ToStringSeparatedByThousands();
			}
			if (!needUpdateColor)
			{
				return;
			}
			switch (priceType)
			{
			case PriceType.Crystals:
				if (SelfUserComponent.SelfUser.GetComponent<UserMoneyComponent>().Money < value)
				{
					component.color = redColor.Apply(component.color);
				}
				else
				{
					component.color = normalColor.Apply(component.color);
				}
				break;
			case PriceType.XCrystals:
				if (SelfUserComponent.SelfUser.GetComponent<UserXCrystalsComponent>().Money < value)
				{
					component.color = redColor.Apply(component.color);
				}
				else
				{
					component.color = normalColor.Apply(component.color);
				}
				break;
			}
		}
	}
}
