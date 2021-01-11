using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class LoadUserComponent : Component
	{
		public long UserId
		{
			get;
			private set;
		}

		public LoadUserComponent(long userId)
		{
			UserId = userId;
		}
	}
}
