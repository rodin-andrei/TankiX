using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientGarage.API
{
	public class ListItemOrderComponent : Component
	{
		public ListItemPriorities Priorities
		{
			get;
			set;
		}

		public ListItemOrderComponent()
		{
			Priorities = new ListItemPriorities();
		}
	}
}
