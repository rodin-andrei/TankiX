using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ListItemPrices : MonoBehaviour
	{
		[SerializeField]
		private GaragePrice price;

		[SerializeField]
		private GaragePrice xPrice;

		public void Set(GarageItem item)
		{
			if (item.UserItem == null)
			{
				int num = item.Price;
				int num2 = item.XPrice;
				price.transform.parent.gameObject.SetActive(num > 0);
				if (num > 0)
				{
					price.SetPrice(item.OldPrice, num);
				}
				xPrice.transform.parent.gameObject.SetActive(num2 > 0);
				if (num2 > 0)
				{
					xPrice.SetPrice(item.OldXPrice, num2);
				}
				base.gameObject.SetActive(num2 != 0 || num != 0);
			}
			else
			{
				base.gameObject.SetActive(false);
			}
		}
	}
}
