using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientBattleSelect.API;
using Tanks.Lobby.ClientEntrance.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class LeaveSquadSystem : ECSSystem
	{
		public class SelfUserInSquadNode : Node
		{
			public UserComponent user;

			public UserGroupComponent userGroup;

			public SelfUserComponent selfUser;

			public SquadGroupComponent squadGroup;
		}

		[OnEventFire]
		public void LeaveSquad(LeaveBattleBeforeItEndEvent e, SelfUserInSquadNode user)
		{
			ScheduleEvent<LeaveSquadEvent>(user);
		}
	}
}
