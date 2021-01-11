using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientGarage.API;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class CardPriceLabelComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Text[] resourceCountTexts;

		[SerializeField]
		private GameObject[] spacingObjects;

		private int[] prices = new int[1];

		private long[] counts = new long[1];

		[SerializeField]
		private Color textColorWhenResourceEnough = Color.green;

		[SerializeField]
		private Color textColorWhenResourceNotEnough = Color.red;

		private bool enoughCards;

		public bool EnoughCards
		{
			get
			{
				return enoughCards;
			}
		}

		private void SetPrice(long type, long price)
		{
			int num = 0;
			prices[num] = (int)price;
			enoughCards = enoughCards && prices[num] <= counts[num];
			resourceCountTexts[num].text = GetText(prices[num], counts[num]);
			resourceCountTexts[num].color = GetColor(prices[num], counts[num]);
			resourceCountTexts[num].gameObject.SetActive(true);
			spacingObjects[num].SetActive(true);
		}

		public void SetPrices(ModuleCardsCompositionComponent moduleResourcesComponent)
		{
			enoughCards = true;
			for (int i = 0; i < prices.Length; i++)
			{
				resourceCountTexts[i].gameObject.SetActive(false);
				spacingObjects[i].SetActive(false);
				prices[i] = 0;
			}
			SetPrice(123123L, moduleResourcesComponent.CraftPrice.Cards);
		}

		public void SetUserCardsCount(long count)
		{
			int num = 0;
			counts[num] = count;
			resourceCountTexts[num].text = GetText(prices[num], counts[num]);
			resourceCountTexts[num].color = GetColor(prices[num], counts[num]);
		}

		public void SetRefund(long type, long count)
		{
			int num = (byte)type;
			counts[num] = count;
			resourceCountTexts[num].text = count.ToString();
			resourceCountTexts[num].color = textColorWhenResourceEnough;
			resourceCountTexts[num].gameObject.SetActive(true);
			spacingObjects[num].SetActive(true);
		}

		private string GetText(int price, long count)
		{
			return count + " / " + price;
		}

		private Color GetColor(int price, long count)
		{
			return (count < price) ? textColorWhenResourceNotEnough : textColorWhenResourceEnough;
		}
	}
}
