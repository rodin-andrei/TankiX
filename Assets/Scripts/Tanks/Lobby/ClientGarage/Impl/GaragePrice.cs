using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GaragePrice : MonoBehaviour
	{
		public enum PriceType
		{
			XCrystals = 0,
			Crystals = 1,
		}

		[SerializeField]
		private bool needUpdateColor;
		[SerializeField]
		private PaletteColorField redColor;
		[SerializeField]
		private PaletteColorField normalColor;
		[SerializeField]
		private PriceType priceType;
	}
}
