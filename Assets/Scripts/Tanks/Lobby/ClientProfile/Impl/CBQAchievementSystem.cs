using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientNavigation.API;

namespace Tanks.Lobby.ClientProfile.Impl
{
	public class CBQAchievementSystem : ECSSystem
	{
		public class CBQUserNode : Node
		{
			public SelfUserComponent selfUser;

			public UserUidComponent userUid;

			public UserGroupComponent userGroup;

			public ClosedBetaQuestAchievementComponent closedBetaQuestAchievement;
		}

		[OnEventFire]
		public void ShowCBQBadge(NodeAddedEvent e, SingleNode<HomeScreenComponent> homeScreen, CBQUserNode selfUser)
		{
			homeScreen.component.CbqBadge.SetActive(true);
		}
	}
}
