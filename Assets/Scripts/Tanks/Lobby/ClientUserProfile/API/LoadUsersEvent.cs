using Platform.Kernel.ECS.ClientEntitySystem.API;
using System.Collections.Generic;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class LoadUsersEvent : Event
	{
		public LoadUsersEvent(long requestEntityId, HashSet<long> usersId)
		{
		}

	}
}
