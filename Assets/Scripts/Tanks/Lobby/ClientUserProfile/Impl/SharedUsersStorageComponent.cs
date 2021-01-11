using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientDataStructures.API;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class SharedUsersStorageComponent : Component
	{
		public HashMultiMap<long, long> UserId2EntityIdMap
		{
			get;
			private set;
		}

		public SharedUsersStorageComponent()
		{
			UserId2EntityIdMap = new HashMultiMap<long, long>();
		}
	}
}
