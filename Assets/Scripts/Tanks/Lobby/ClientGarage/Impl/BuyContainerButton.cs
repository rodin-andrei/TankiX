using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class BuyContainerButton : MonoBehaviour
	{
		[SerializeField]
		private LocalizedField buyText;

		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private GaragePrice price;

		public int Amount
		{
			get;
			private set;
		}

		public int Price
		{
			get;
			private set;
		}

		public void Init(int amount, int oldPrice, int price)
		{
			Amount = amount;
			Price = price;
			this.price.SetPrice(oldPrice, price);
			text.text = buyText.Value + " " + amount;
		}
	}
}
