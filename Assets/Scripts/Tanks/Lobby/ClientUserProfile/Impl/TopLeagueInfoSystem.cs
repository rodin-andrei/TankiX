using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientUserProfile.API;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class TopLeagueInfoSystem : ECSSystem
	{
		public class UserNode : Node
		{
			public UserReputationComponent userReputation;

			public LeagueGroupComponent leagueGroup;

			public UserGroupComponent userGroup;
		}

		public class SelfUserNode : UserNode
		{
			public SelfUserComponent selfUser;
		}

		public class TopLeagueInfoUINode : Node
		{
			public TopLeagueInfoUIComponent topLeagueInfoUI;

			public UserGroupComponent userGroup;
		}

		[OnEventFire]
		public void GetLeagueInfo(NodeAddedEvent e, TopLeagueInfoUINode infoUI, [JoinByUser] UserNode user, [JoinAll] SelfUserNode selfUser)
		{
			NewEvent(new GetLeagueInfoEvent
			{
				UserId = user.Entity.Id
			}).Attach(selfUser).Schedule();
		}
	}
}
