using System.Collections.Generic;
using System.Linq;
using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientGarage.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class MarketItemRestrictionCheckSystem : ECSSystem
	{
		public class MarketItemNode : Node
		{
			public MarketItemComponent marketItem;
		}

		public class SelfUserNode : Node
		{
			public SelfUserComponent selfUser;

			public UserRankComponent userRank;
		}

		public class MarketItemWithUpgradeLevelRestrictionNode : MarketItemNode
		{
			public PurchaseUpgradeLevelRestrictionComponent purchaseUpgradeLevelRestriction;

			public MountUpgradeLevelRestrictionComponent mountUpgradeLevelRestriction;

			public ParentGroupComponent parentGroup;
		}

		public class MarketItemWithUserRankRestrictionNode : MarketItemNode
		{
			public PurchaseUserRankRestrictionComponent purchaseUserRankRestriction;
		}

		public class UpgradableItemNode : Node
		{
			public UpgradeLevelItemComponent upgradeLevelItem;

			public UserItemComponent userItem;

			public ParentGroupComponent parentGroup;

			public MarketItemGroupComponent marketItemGroup;
		}

		[OnEventFire]
		public void RestrictMarketItemByUpgradeLevel(CheckMarketItemRestrictionsEvent e, MarketItemWithUpgradeLevelRestrictionNode marketItem, [JoinByParentGroup] ICollection<UpgradableItemNode> upgradableItems)
		{
			Entity marketParentItem = GetEntityById(marketItem.parentGroup.Key);
			if (upgradableItems.Count((UpgradableItemNode upgradableItem) => upgradableItem.marketItemGroup.Key == marketParentItem.Id) == 0)
			{
				bool value = marketItem.mountUpgradeLevelRestriction.RestrictionValue > 0;
				e.RestrictByUpgradeLevel(value);
				e.MountRestrictByUpgradeLevel(value);
				return;
			}
			foreach (UpgradableItemNode upgradableItem in upgradableItems)
			{
				if (upgradableItem.marketItemGroup.Key == marketParentItem.Id)
				{
					int level = upgradableItem.upgradeLevelItem.Level;
					e.RestrictByUpgradeLevel(level < marketItem.purchaseUpgradeLevelRestriction.RestrictionValue);
				}
			}
		}

		[OnEventFire]
		public void RestrictMarketItemByUserRank(CheckMarketItemRestrictionsEvent e, [Combine] MarketItemWithUserRankRestrictionNode item, [JoinAll] SelfUserNode selfUser)
		{
			e.RestrictByRank(item.purchaseUserRankRestriction.RestrictionValue > selfUser.userRank.Rank);
		}
	}
}
