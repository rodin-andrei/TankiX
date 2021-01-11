using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Lobby.ClientBattleSelect.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class ScoreTablePingIndicatorSystem : ECSSystem
	{
		public class PingIndicatorNode : Node
		{
			public ScoreTablePingIndicatorComponent scoreTablePingIndicator;

			public UserGroupComponent userGroup;
		}

		public class UserNode : Node
		{
			public UserGroupComponent userGroup;

			public RoundUserStatisticsComponent roundUserStatistics;
		}

		[OnEventFire]
		public void SetPing(NodeAddedEvent e, [Combine] PingIndicatorNode pingIndicator, [Context][JoinByUser] UserNode user)
		{
			SetPing(pingIndicator, user);
		}

		[OnEventFire]
		public void SetPing(RoundUserStatisticsUpdatedEvent e, UserNode user, [Combine][JoinByUser] PingIndicatorNode pingIndicator)
		{
			SetPing(pingIndicator, user);
		}

		private void SetPing(PingIndicatorNode pingIndicator, UserNode user)
		{
		}
	}
}
