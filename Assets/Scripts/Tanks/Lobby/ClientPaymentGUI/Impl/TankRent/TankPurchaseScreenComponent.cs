using Tanks.Lobby.ClientPaymentGUI.Impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl.TankRent
{
	public class TankPurchaseScreenComponent : PurchaseItemComponent
	{
		public TextMeshProUGUI actualPrice;
		public TextMeshProUGUI priceWithoutDiscount;
		public TextMeshProUGUI discount;
		public GameObject discountExplanationBlock;
		public Image tankImage;
		public Image backgroundImage;
		public Image[] modules;
		public Sprite supportTank;
		public Sprite supportTankBackgroundImage;
		public Sprite[] supportModules;
		public Sprite offensiveTank;
		public Sprite[] offensiveModules;
		public Sprite offensiveTankBackgroundImage;
		public Sprite annihilationTank;
		public Sprite[] annihilationModules;
		public Sprite annihilationTankBackgroundImage;
	}
}
