using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class BuyItemButton : MonoBehaviour
	{
		[SerializeField]
		private GaragePrice enabledPrice;

		[SerializeField]
		private GaragePrice disabledPrice;

		[SerializeField]
		private Button button;

		public Button Button
		{
			get
			{
				return button;
			}
		}

		public void SetPrice(int oldPrice, int price)
		{
			enabledPrice.NeedUpdateColor = true;
			disabledPrice.NeedUpdateColor = false;
			enabledPrice.SetPrice(oldPrice, price);
			disabledPrice.SetPrice(oldPrice, price);
		}
	}
}
