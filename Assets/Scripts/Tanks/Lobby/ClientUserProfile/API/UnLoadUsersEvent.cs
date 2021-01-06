using Platform.Kernel.ECS.ClientEntitySystem.API;
using System.Collections.Generic;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class UnLoadUsersEvent : Event
	{
		public UnLoadUsersEvent(HashSet<long> userIds)
		{
		}

	}
}
