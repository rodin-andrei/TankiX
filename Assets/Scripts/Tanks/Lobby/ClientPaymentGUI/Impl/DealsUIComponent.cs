using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class DealsUIComponent : PurchaseItemComponent
	{
		[Serializable]
		public class GiftPromo
		{
			public string Key;
			public GameObject Prefab;
		}

		[SerializeField]
		private RectTransform bigRowsContainer;
		[SerializeField]
		private RectTransform[] availableRows;
		[SerializeField]
		private SpecialOfferContent specialOfferPrefab;
		[SerializeField]
		private MarketItemSaleContent marketItemSalePrefab;
		[SerializeField]
		private FirstPurchaseDiscountContent firstPurchaseDiscountPrefab;
		[SerializeField]
		private GameObject bonusPrefab;
		[SerializeField]
		private GameObject quantumPrefab;
		[SerializeField]
		public LeagueSpecialOfferComponent leagueSpecialOfferPrefab;
		[SerializeField]
		private List<DealsUIComponent.GiftPromo> promo;
		[SerializeField]
		private ScrollRect scrollRect;
		[SerializeField]
		private RectTransform scrollContent;
		[SerializeField]
		private float autoScrollSpeed;
		[SerializeField]
		private float pageWidth;
		[SerializeField]
		private int pageCount;
		[SerializeField]
		private int currentPage;
		[SerializeField]
		private bool interactWithScrollView;
		[SerializeField]
		private bool scrollMode;
		[SerializeField]
		private Button leftScrollButton;
		[SerializeField]
		private Button rightScrollButton;
		[SerializeField]
		private GameObject noDealsText;
	}
}
