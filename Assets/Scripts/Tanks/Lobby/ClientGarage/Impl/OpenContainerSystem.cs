using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientGarage.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class OpenContainerSystem : ECSSystem
	{
		public class ItemsContainerItemNode : Node
		{
			public ItemsContainerItemComponent itemsContainerItem;

			public ContainerMarkerComponent containerMarker;

			public UserItemComponent userItem;
		}

		public class GamePlayChestItemNode : Node
		{
			public GameplayChestItemComponent gameplayChestItem;

			public ContainerMarkerComponent containerMarker;

			public UserItemComponent userItem;

			public UserItemCounterComponent userItemCounter;
		}

		[OnEventFire]
		public void OpenContainer(OpenSelectedContainerEvent e, ItemsContainerItemNode containerNode)
		{
			ScheduleEvent(new OpenContainerEvent(), containerNode);
		}

		[OnEventFire]
		public void OpenContainer(OpenSelectedContainerEvent e, GamePlayChestItemNode containerNode)
		{
			ScheduleEvent(new OpenContainerEvent
			{
				Amount = containerNode.userItemCounter.Count
			}, containerNode);
		}
	}
}
