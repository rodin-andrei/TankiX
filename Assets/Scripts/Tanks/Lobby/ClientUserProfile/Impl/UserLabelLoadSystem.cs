using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientUserProfile.API;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class UserLabelLoadSystem : ECSSystem
	{
		public class UserLabelLoadedNode : Node
		{
			public UserLabelComponent userLabel;

			public LoadUserComponent loadUser;

			public UserLoadedComponent userLoaded;
		}

		[OnEventFire]
		public void AttachUser(NodeAddedEvent e, UserLabelLoadedNode userLabel)
		{
			userLabel.Entity.AddComponent(new UserGroupComponent(userLabel.userLabel.UserId));
		}
	}
}
