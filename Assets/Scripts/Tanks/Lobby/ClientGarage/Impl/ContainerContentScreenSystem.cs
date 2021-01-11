using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ContainerContentScreenSystem : ECSSystem
	{
		public class ContainerContentScreenNode : Node
		{
			public ContainerContentScreenComponent containerContentScreen;

			public ActiveScreenComponent activeScreen;
		}

		public class ContainerContentItemNode : Node
		{
			public SimpleContainerContentItemComponent simpleContainerContentItem;

			public ContainerContentItemComponent containerContentItem;

			public GarageListItemComponent garageListItem;
		}

		public class ItemsListNode : Node
		{
			public ItemsListForViewComponent itemsListForView;

			public ScreenGroupComponent screenGroup;
		}

		[OnEventComplete]
		public void MarkUserItems(ShowGarageItemsEvent e, [Combine] ContainerContentItemNode containerContentItem, [JoinAll] ContainerContentScreenNode screenNode)
		{
			Entity entity = Flow.Current.EntityRegistry.GetEntity(containerContentItem.simpleContainerContentItem.MarketItemId);
			IList<SingleNode<UserItemComponent>> list = Select<SingleNode<UserItemComponent>>(entity, typeof(MarketItemGroupComponent));
			if (list.Count > 0)
			{
				MarkItem(containerContentItem.garageListItem.gameObject, true);
			}
		}

		private void MarkItem(GameObject itemGameObject, bool active)
		{
			TickMarkerComponent componentInChildrenIncludeInactive = itemGameObject.GetComponentInChildrenIncludeInactive<TickMarkerComponent>();
			componentInChildrenIncludeInactive.gameObject.SetActive(active);
		}
	}
}
