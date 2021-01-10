using Platform.Kernel.ECS.ClientEntitySystem.API;
using System.Collections.Generic;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class ShowNotificationEvent : Event
	{
		public ShowNotificationEvent(List<Entity> sortedNotifications)
		{
		}

	}
}
