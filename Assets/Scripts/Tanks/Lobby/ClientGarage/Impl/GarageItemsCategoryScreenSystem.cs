using System.Collections.Generic;
using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GarageItemsCategoryScreenSystem : ECSSystem
	{
		public class PaintButtonNode : Node
		{
			public TankPaintButtonComponent tankPaintButton;

			public TextMappingComponent textMapping;
		}

		public class ContainerItemNode : Node
		{
			public ContainerMarkerComponent containerMarker;

			public DescriptionBundleItemComponent descriptionBundleItem;
		}

		public class ContainerMarketItemNode : ContainerItemNode
		{
			public MarketItemComponent marketItem;
		}

		public class ShowSkinItemsListScreenBySelectedItemEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
		{
		}

		public class ShowParentItemBySelectedItemEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
		{
		}

		[OnEventFire]
		public void ShowContainers(ButtonClickEvent e, SingleNode<ContainersButtonComponent> button)
		{
			ScheduleEvent(new ShowGarageCategoryEvent
			{
				Category = GarageCategory.CONTAINERS
			}, button);
		}

		[OnEventFire]
		public void GoToContainerScreenFromContainerItem(ButtonClickEvent e, SingleNode<GoToContainersScreenButtonComponent> button, [JoinByScreen] SingleNode<SelectedItemComponent> selectedItem)
		{
			NewEvent<ShowParentItemBySelectedItemEvent>().AttachAll(selectedItem.component.SelectedItem, button.Entity).Schedule();
		}

		[OnEventFire]
		public void GoToContainerScreenFromContainerItem(ShowParentItemBySelectedItemEvent e, SingleNode<MarketItemComponent> selectedItem, [JoinByContainerContentItem] SingleNode<ContainerContentItemComponent> containerContent, [JoinByContainer] ContainerMarketItemNode container, SingleNode<GoToContainersScreenButtonComponent> button)
		{
			ScheduleEvent(new ShowGarageCategoryEvent
			{
				Category = GarageCategory.CONTAINERS,
				SelectedItem = container.Entity
			}, button);
		}

		[OnEventFire]
		public void ShowContainerContentScreen(ButtonClickEvent e, SingleNode<ContainerContentButtonComponent> containerContentButton, [JoinByScreen] SingleNode<SelectedItemComponent> selectedItem)
		{
			ScheduleEvent<ShowContainerContentScreenEvent>(selectedItem.component.SelectedItem);
		}

		[OnEventFire]
		public void ShowContainerContentScreen(ShowContainerContentScreenEvent e, ContainerItemNode container, [JoinByContainer] ICollection<SingleNode<ContainerContentItemComponent>> items)
		{
			ShowItemsListScreen<ContainerContentScreenComponent>(items.Select((SingleNode<ContainerContentItemComponent> x) => x.Entity));
		}

		private void ShowItemsListScreen<T>(IEnumerable<Entity> items) where T : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
		{
			Entity entity = CreateEntity("GarageItems");
			entity.AddComponent(new ItemsListForViewComponent(new List<Entity>(items)));
			entity.AddComponent<SelectedItemComponent>();
			ShowScreenLeftEvent<T> showScreenLeftEvent = new ShowScreenLeftEvent<T>();
			showScreenLeftEvent.SetContext(entity, true);
			ScheduleEvent(showScreenLeftEvent, entity);
		}
	}
}
