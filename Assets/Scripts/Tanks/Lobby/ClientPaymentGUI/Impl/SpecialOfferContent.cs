using TMPro;
using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class SpecialOfferContent : DealItemContent
	{
		public TextMeshProUGUI oldPrice;
		public TextMeshProUGUI items;
		public LocalizedField specialOfferEmptyRewardMessage;
		[SerializeField]
		private Image saleImage;
		[SerializeField]
		private TextMeshProUGUI saleText;
		[SerializeField]
		private Image titleStripes;
		[SerializeField]
		private TextMeshProUGUI timer;
	}
}
