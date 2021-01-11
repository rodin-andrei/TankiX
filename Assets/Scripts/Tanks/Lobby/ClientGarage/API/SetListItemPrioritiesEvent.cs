using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientGarage.API
{
	public class SetListItemPrioritiesEvent : Event
	{
		public ListItemPriorities Priorities
		{
			get;
			set;
		}

		public SetListItemPrioritiesEvent()
		{
			Priorities = new ListItemPriorities();
		}
	}
}
