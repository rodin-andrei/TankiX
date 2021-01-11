using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientNavigation.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class DisplayMarketItemRestrictionDescriptionSystem : ECSSystem
	{
		public class ScreenNode : Node
		{
			public GarageItemsScreenComponent garageItemsScreen;

			public ScreenComponent screen;

			public ActiveScreenComponent activeScreen;

			public GarageItemsScreenTextComponent garageItemsScreenText;
		}

		public class MarketItemNode : Node
		{
			public MarketItemComponent marketItem;
		}

		public class UserRankRestrictionNode : MarketItemNode
		{
			public PurchaseUserRankRestrictionComponent purchaseUserRankRestriction;
		}

		public class UpgradeLevelRestrictionNode : MarketItemNode
		{
			public PurchaseUpgradeLevelRestrictionComponent purchaseUpgradeLevelRestriction;

			public MountUpgradeLevelRestrictionComponent mountUpgradeLevelRestriction;

			public ParentGroupComponent parentGroup;
		}

		public class SelfUserNode : Node
		{
			public SelfUserComponent selfUser;

			public UserRankComponent userRank;
		}

		public static readonly string RANK = "%RANK%";

		public static readonly string ITEM_upgLEVEL = "%ITEM_upgLEVEL%";

		[OnEventFire]
		public void HideDescriptions(ListItemSelectedEvent e, Node any, [JoinAll] ScreenNode screen)
		{
			screen.garageItemsScreen.UserRankRestrictionDescription.gameObject.SetActive(false);
			screen.garageItemsScreen.UpgradeLevelRestrictionDescription.gameObject.SetActive(false);
		}

		[OnEventComplete]
		public void ShowUserRankRestrictionDescription(ListItemSelectedEvent e, UserRankRestrictionNode userRankRestriction, [JoinAll] SelfUserNode user, [JoinAll] ScreenNode screen, [JoinAll] SingleNode<RanksNamesComponent> ranksNames)
		{
			CheckMarketItemRestrictionsEvent checkMarketItemRestrictionsEvent = new CheckMarketItemRestrictionsEvent();
			ScheduleEvent(checkMarketItemRestrictionsEvent, userRankRestriction);
			if (checkMarketItemRestrictionsEvent.RestrictedByRank)
			{
				ShowUserRankRestrictionDescription(screen, userRankRestriction.purchaseUserRankRestriction, ranksNames.component);
			}
		}

		private void ShowUserRankRestrictionDescription(ScreenNode screen, PurchaseUserRankRestrictionComponent restriction, RanksNamesComponent ranksNames)
		{
			screen.garageItemsScreen.UserRankRestrictionDescription.Description = screen.garageItemsScreenText.UserRankRestrictionDescription.Replace(RANK, ranksNames.Names[restriction.RestrictionValue]);
			screen.garageItemsScreen.UserRankRestrictionDescription.gameObject.SetActive(true);
		}

		[OnEventComplete]
		public void ShowUpgradeLevelRestrictionDescription(ListItemSelectedEvent e, UpgradeLevelRestrictionNode upgradeLevelRestriction, [JoinAll] ScreenNode screen)
		{
			CheckMarketItemRestrictionsEvent checkMarketItemRestrictionsEvent = new CheckMarketItemRestrictionsEvent();
			ScheduleEvent(checkMarketItemRestrictionsEvent, upgradeLevelRestriction);
			if (checkMarketItemRestrictionsEvent.RestrictedByUpgradeLevel)
			{
				if (upgradeLevelRestriction.purchaseUpgradeLevelRestriction.RestrictionValue == 0 && checkMarketItemRestrictionsEvent.MountWillBeRestrictedByUpgradeLevel)
				{
					ShowUpgradeLevelRestrictionDescription(screen, upgradeLevelRestriction.mountUpgradeLevelRestriction.RestrictionValue);
				}
				else
				{
					ShowUpgradeLevelRestrictionDescription(screen, upgradeLevelRestriction.purchaseUpgradeLevelRestriction.RestrictionValue);
				}
			}
		}

		private void ShowUpgradeLevelRestrictionDescription(ScreenNode screen, int restrictionValue)
		{
			screen.garageItemsScreen.UpgradeLevelRestrictionDescription.Description = screen.garageItemsScreenText.UpgradeLevelRestrictionDescription.Replace(ITEM_upgLEVEL, restrictionValue.ToString());
			screen.garageItemsScreen.UpgradeLevelRestrictionDescription.gameObject.SetActive(true);
		}
	}
}
