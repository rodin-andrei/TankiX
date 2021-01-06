using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class FirstPurchaseDiscountContent : DealItemContent
	{
		public Image bannerImage;
		public Sprite bigBanner;
		public Sprite smallBanner;
		public GameObject bigDesc;
		public GameObject smallDesc;
		public TextMeshProUGUI BigFirstLine;
		public TextMeshProUGUI BigSecondLine;
		public TextMeshProUGUI BigThirdLine;
		public TextMeshProUGUI BigValue;
		public TextMeshProUGUI SmallFirstLine;
		public TextMeshProUGUI SmallSecondLine;
	}
}
