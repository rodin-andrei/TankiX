using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class ShopXCrystalsComponent : PurchaseItemComponent
	{
		[SerializeField]
		private XCrystalPackage packPrefab;
		[SerializeField]
		private RectTransform packsRoot;
	}
}
