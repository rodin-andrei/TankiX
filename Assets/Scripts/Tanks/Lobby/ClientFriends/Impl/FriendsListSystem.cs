using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientFriends.Impl
{
	public class FriendsListSystem : ECSSystem
	{
		public class SelectedListItemNode : Node
		{
			public SelectedListItemComponent selectedListItem;

			public FriendsListItemComponent friendsListItem;
		}

		[Not(typeof(SelectedListItemComponent))]
		public class NotSelectedListItemNode : Node
		{
			public FriendsListItemComponent friendsListItem;
		}

		[OnEventFire]
		public void MarkListItemSelected(ListItemSelectedEvent e, NotSelectedListItemNode item)
		{
			item.Entity.AddComponent<SelectedListItemComponent>();
		}

		[OnEventFire]
		public void MarkListItemDeselected(ListItemDeselectedEvent e, SelectedListItemNode item)
		{
			item.Entity.RemoveComponent<SelectedListItemComponent>();
		}
	}
}
