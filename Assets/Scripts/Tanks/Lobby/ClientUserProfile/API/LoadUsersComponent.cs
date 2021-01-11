using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class LoadUsersComponent : Component
	{
		public HashSet<long> UserIds
		{
			get;
			private set;
		}

		public LoadUsersComponent(HashSet<long> userIds)
		{
			UserIds = userIds;
		}
	}
}
