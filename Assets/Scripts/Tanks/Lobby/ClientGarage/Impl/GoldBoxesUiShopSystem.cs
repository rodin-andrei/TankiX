using System;
using System.Collections;
using System.Collections.Generic;
using Lobby.ClientPayment.Impl;
using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientPayment.API;
using Tanks.Lobby.ClientPayment.Impl;
using Tanks.Lobby.ClientUserProfile.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GoldBoxesUiShopSystem : ECSSystem
	{
		public class GoldBoxOfferNode : Node
		{
			public GoldBonusOfferComponent goldBonusOffer;

			public SpecialOfferContentLocalizationComponent specialOfferContentLocalization;

			public SpecialOfferScreenLocalizationComponent specialOfferScreenLocalization;

			public SpecialOfferContentComponent specialOfferContent;

			public GoodsPriceComponent goodsPrice;
		}

		private class GoldBoxNodeComparer : IComparer<GoldBoxOfferNode>
		{
			public int Compare(GoldBoxOfferNode a, GoldBoxOfferNode b)
			{
				return a.goldBonusOffer.Count.CompareTo(b.goldBonusOffer.Count);
			}
		}

		public class GoldBoxItemNode : Node
		{
			public GoldBonusItemComponent goldBonusItem;

			public UserItemComponent userItem;

			public UserGroupComponent userGroup;

			public UserItemCounterComponent userItemCounter;
		}

		[OnEventFire]
		public void CreatePacks(NodeAddedEvent e, SingleNode<GoldBoxesShopTabComponent> shopNode, [JoinAll] ICollection<GoldBoxOfferNode> goods)
		{
			List<GoldBoxOfferNode> list = BuildList(goods);
			list.Sort(new GoldBoxNodeComparer());
			foreach (GoldBoxOfferNode item in list)
			{
				GoldBoxesPackComponent component = UnityEngine.Object.Instantiate(shopNode.component.PackPrefab, shopNode.component.PackContainer).GetComponent<GoldBoxesPackComponent>();
				FillPack(component, item);
			}
		}

		[OnEventFire]
		public void DestroyPacks(NodeRemoveEvent e, SingleNode<GoldBoxesShopTabComponent> shopNode)
		{
			IEnumerator enumerator = shopNode.component.PackContainer.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Transform transform = (Transform)enumerator.Current;
					UnityEngine.Object.Destroy(transform.gameObject);
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = enumerator as IDisposable) != null)
				{
					disposable.Dispose();
				}
			}
		}

		private List<GoldBoxOfferNode> BuildList(ICollection<GoldBoxOfferNode> goods)
		{
			return new List<GoldBoxOfferNode>(goods);
		}

		private void FillPack(GoldBoxesPackComponent pack, GoldBoxOfferNode packNode)
		{
			pack.CardName = packNode.specialOfferContentLocalization.Title;
			pack.SpriteUid = packNode.specialOfferScreenLocalization.SpriteUid;
			pack.Discount = packNode.specialOfferContent.SalePercent;
			pack.HitMarkEnabled = packNode.specialOfferContent.HighlightTitle;
			pack.BoxCount = packNode.goldBonusOffer.Count;
			pack.Price = string.Format("{0:0.00} {1}", packNode.goodsPrice.Price, packNode.goodsPrice.Currency);
			pack.GoodsEntity = packNode.Entity;
		}

		[OnEventFire]
		public void GetCounter(NodeAddedEvent e, SingleNode<GoldBoxesShopTabComponent> shopNode, [JoinAll] GoldBoxItemNode gold)
		{
			shopNode.component.UserBoxCount.text = gold.userItemCounter.Count.ToString();
		}

		[OnEventFire]
		public void RefreshCounter(TryToShowNotificationEvent e, Node any, [JoinAll] GoldBoxItemNode gold, [JoinAll] SingleNode<GoldBoxesShopTabComponent> shopNode)
		{
			shopNode.component.UserBoxCount.text = gold.userItemCounter.Count.ToString();
		}
	}
}
