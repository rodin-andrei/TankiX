using System.Collections.Generic;
using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientDataStructures.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientNavigation.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ItemsListScreenSystem : ECSSystem
	{
		public class ScreenNode : Node
		{
			public ItemsListScreenComponent itemsListScreen;

			public ScreenComponent screen;

			public ActiveScreenComponent activeScreen;

			public DisplayDescriptionItemComponent displayDescriptionItem;
		}

		public class MarketItem : Node
		{
			public MarketItemComponent marketItem;

			public OrderItemComponent orderItem;

			public MarketItemGroupComponent marketItemGroup;
		}

		public class UserItem : Node
		{
			public UserItemComponent userItem;

			public OrderItemComponent orderItem;

			public MarketItemGroupComponent marketItemGroup;
		}

		public class GarageItemNode : Node
		{
			public GarageItemComponent garageItem;

			public DescriptionItemComponent descriptionItem;
		}

		[Not(typeof(ShellItemComponent))]
		public class NotShellGarageItemNode : Node
		{
			public GarageItemComponent garageItem;

			public DescriptionItemComponent descriptionItem;
		}

		public class ItemsListNode : Node
		{
			public ItemsListForViewComponent itemsListForView;

			public ScreenGroupComponent screenGroup;
		}

		[Not(typeof(UpgradeLevelItemComponent))]
		public class GarageListUserItemNotUpgradeNode : Node
		{
			public UserItemComponent userItem;

			public GarageListItemComponent garageListItem;
		}

		public class ContainerContentItemNode : Node
		{
			public ContainerContentItemComponent containerContentItem;

			public OrderItemComponent orderItem;
		}

		[OnEventFire]
		public void AddItems(NodeAddedEvent e, ItemsListNode itemListNode, [Context][JoinByScreen] SingleNode<SimpleHorizontalListComponent> horizontalListNode)
		{
			NewEvent<ShowGarageItemsEvent>().AttachAll(itemListNode.itemsListForView.Items).Schedule();
		}

		[OnEventFire]
		[Mandatory]
		public void AddItems(ShowGarageItemsEvent e, ICollection<MarketItem> marketItems, ICollection<UserItem> userItems, ICollection<SingleNode<MountedItemComponent>> mountedItems, ICollection<ContainerContentItemNode> containerContentItems, ICollection<SingleNode<SlotUserItemInfoComponent>> slotItems, [JoinAll] ScreenNode screen, [JoinByScreen] SingleNode<SimpleHorizontalListComponent> horizontalListNode, [JoinByScreen] Optional<SingleNode<SelectedItemComponent>> selectedItemNode)
		{
			SimpleHorizontalListComponent itemsList = horizontalListNode.component;
			slotItems.ToList().ForEach(delegate(SingleNode<SlotUserItemInfoComponent> item)
			{
				itemsList.AddItem(item.Entity);
			});
			List<UserItem> list = userItems.ToList();
			list.Sort((UserItem a, UserItem b) => a.orderItem.Index.CompareTo(b.orderItem.Index));
			list.ForEach(delegate(UserItem item)
			{
				itemsList.AddItem(item.Entity);
			});
			List<MarketItem> buyableMarketItems = GetBuyableMarketItems(marketItems, userItems);
			buyableMarketItems.Sort((MarketItem a, MarketItem b) => a.orderItem.Index.CompareTo(b.orderItem.Index));
			buyableMarketItems.ForEach(delegate(MarketItem item)
			{
				itemsList.AddItem(item.Entity);
			});
			List<ContainerContentItemNode> list2 = containerContentItems.Where((ContainerContentItemNode item) => item.Entity.Alive).ToList();
			list2.Sort((ContainerContentItemNode a, ContainerContentItemNode b) => a.orderItem.Index.CompareTo(b.orderItem.Index));
			list2.ForEach(delegate(ContainerContentItemNode item)
			{
				itemsList.AddItem(item.Entity);
			});
			if (itemsList.Count == 0)
			{
				ScheduleEvent<ItemsListEmptyEvent>(screen);
			}
			else if (selectedItemNode.IsPresent())
			{
				Entity entity = selectedItemNode.Get().component.SelectedItem;
				if (entity == null || !entity.Alive)
				{
					entity = ((mountedItems.Count > 0) ? mountedItems.First().Entity : ((list.Count > 0) ? list.First().Entity : ((list2.Count <= 0) ? buyableMarketItems.First().Entity : list2.First().Entity)));
				}
				if (!itemsList.Contains(entity))
				{
					entity = ReplaceMarketItemToUserItem(entity, list);
				}
				ScheduleEvent<SelectGarageItemEvent>(entity);
			}
			else
			{
				ScheduleEvent<SelectGarageItemEvent>(itemsList.GetItems().First());
			}
		}

		[OnEventFire]
		public void SelectItem(SelectGarageItemEvent e, SingleNode<GarageListItemComponent> itemNode, [JoinAll] ScreenNode screen, [JoinByScreen] SingleNode<SimpleHorizontalListComponent> listNode)
		{
			Entity entity = itemNode.Entity;
			SimpleHorizontalListComponent component = listNode.component;
			component.Select(entity);
			component.MoveToItem(entity);
		}

		[OnEventFire]
		public void ClearItemsList(NodeRemoveEvent e, ScreenNode screenNode)
		{
			SimpleHorizontalListComponent componentInChildrenIncludeInactive = screenNode.screen.GetComponentInChildrenIncludeInactive<SimpleHorizontalListComponent>();
			componentInChildrenIncludeInactive.ClearItems(true);
		}

		[OnEventFire]
		public void SelectItem(ListItemSelectedEvent e, GarageItemNode item, [JoinAll] ScreenNode screenNode, [JoinByScreen] SingleNode<SelectedItemComponent> selectedItemNode)
		{
			selectedItemNode.component.SelectedItem = item.Entity;
		}

		private static Entity ReplaceMarketItemToUserItem(Entity itemToSelect, List<UserItem> userItems)
		{
			UserItem userItem = userItems.FirstOrDefault((UserItem n) => n.marketItemGroup.Key == itemToSelect.Id);
			if (userItem != null)
			{
				return userItem.Entity;
			}
			return itemToSelect;
		}

		private static List<MarketItem> GetBuyableMarketItems(ICollection<MarketItem> marketItems, ICollection<UserItem> userItems)
		{
			Dictionary<long, MarketItem> buyableMarketItems = new Dictionary<long, MarketItem>();
			marketItems.ForEach(delegate(MarketItem marketItem)
			{
				buyableMarketItems[marketItem.marketItemGroup.Key] = marketItem;
			});
			userItems.ForEach(delegate(UserItem userItem)
			{
				buyableMarketItems.Remove(userItem.marketItemGroup.Key);
			});
			return buyableMarketItems.Values.ToList();
		}
	}
}
