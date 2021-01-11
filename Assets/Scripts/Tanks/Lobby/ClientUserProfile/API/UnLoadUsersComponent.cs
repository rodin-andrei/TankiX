using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class UnLoadUsersComponent : Component
	{
		public HashSet<long> UserIds
		{
			get;
			private set;
		}

		public UnLoadUsersComponent(HashSet<long> userIds)
		{
			UserIds = userIds;
		}
	}
}
