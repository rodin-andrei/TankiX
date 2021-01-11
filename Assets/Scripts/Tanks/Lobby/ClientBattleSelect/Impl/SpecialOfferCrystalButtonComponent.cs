using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class SpecialOfferCrystalButtonComponent : BehaviourComponent
	{
		[SerializeField]
		private string priceRegularFormatting;

		[SerializeField]
		private string priceDiscountedFormatting;

		[SerializeField]
		private TextMeshProUGUI priceText;

		[SerializeField]
		private string blueCrystalIconString;

		[SerializeField]
		private string xCrystalIconString;

		public void SetPrice(int price, bool xCry)
		{
			SetPrice(price, 0, xCry);
		}

		public void SetPrice(int price, int discount, bool xCry)
		{
			if (discount != 0)
			{
				priceText.text = string.Format(priceDiscountedFormatting, discount, price);
			}
			else
			{
				priceText.text = string.Format(priceRegularFormatting, price);
			}
			AddCrystals(xCry);
		}

		private void AddCrystals(bool xCry)
		{
			if (xCry)
			{
				priceText.text += xCrystalIconString;
			}
			else
			{
				priceText.text += blueCrystalIconString;
			}
		}
	}
}
