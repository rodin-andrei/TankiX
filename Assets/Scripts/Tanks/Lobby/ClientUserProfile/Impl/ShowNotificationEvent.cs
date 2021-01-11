using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class ShowNotificationEvent : Event
	{
		public bool CanShowNotification
		{
			get;
			set;
		}

		public List<Entity> SortedNotifications
		{
			get;
			private set;
		}

		public ShowNotificationEvent(List<Entity> sortedNotifications)
		{
			CanShowNotification = true;
			SortedNotifications = sortedNotifications;
		}
	}
}
