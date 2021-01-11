using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Lobby.ClientBattleSelect.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientGarage.Impl;
using Tanks.Lobby.ClientMatchMaking.API;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class MatchMakingLobbyGUISystem : ECSSystem
	{
		public class UserNode : Node
		{
			public UserComponent user;

			public BattleLobbyGroupComponent battleLobbyGroup;

			public UserUidComponent userUid;

			public UserGroupComponent userGroup;

			public BattleLeaveCounterComponent battleLeaveCounter;
		}

		public class SelfUserNode : Node
		{
			public UserComponent user;

			public SelfUserComponent selfUser;

			public BattleLeaveCounterComponent battleLeaveCounter;
		}

		public class MatchMakingLobbyNode : Node
		{
			public BattleLobbyComponent battleLobby;

			public BattleLobbyGroupComponent battleLobbyGroup;
		}

		public class ReadyUserNode : UserNode
		{
			public MatchMakingUserReadyComponent matchMakingUserReady;

			public LobbyUserListItemComponent lobbyUserListItem;
		}

		public class UserInBattleNode : UserNode
		{
			public BattleGroupComponent battleGroup;

			public LobbyUserListItemComponent lobbyUserListItem;
		}

		[OnEventFire]
		public void UserReady(ButtonClickEvent e, SingleNode<ReadyButtonComponent> readyButton, [JoinAll] MatchMakingLobbyNode matchMakingLobby)
		{
			ScheduleEvent<MatchMakingUserReadyEvent>(matchMakingLobby);
		}

		[OnEventFire]
		public void UserReady(NodeAddedEvent e, ReadyUserNode user)
		{
			user.lobbyUserListItem.SetReady();
		}

		[OnEventFire]
		public void UserInBattle(NodeAddedEvent e, UserInBattleNode user)
		{
			user.lobbyUserListItem.SetInBattle();
		}

		[OnEventFire]
		public void UserNotInBattle(NodeRemoveEvent e, UserInBattleNode user)
		{
			if (user.Entity.HasComponent<MatchMakingUserReadyComponent>())
			{
				user.lobbyUserListItem.SetReady();
			}
			else
			{
				user.lobbyUserListItem.SetNotReady();
			}
		}

		[OnEventFire]
		public void OnGameModeSelectScreen(NodeAddedEvent e, SingleNode<GameModeSelectScreenComponent> gameModeSelectScreen, [JoinAll] SelfUserNode selfUser)
		{
			CheckForDeserterDesc(selfUser);
		}

		[OnEventFire]
		public void GameModeSelectClose(NodeRemoveEvent e, SingleNode<GameModeSelectScreenComponent> gameModeSelectScreen)
		{
			MainScreenComponent.Instance.HideDeserterDesc();
		}

		private void CheckForDeserterDesc(SelfUserNode selfUser)
		{
			int needGoodBattles = selfUser.battleLeaveCounter.NeedGoodBattles;
			if (needGoodBattles > 0)
			{
				MainScreenComponent.Instance.ShowDeserterDesc(needGoodBattles, false);
			}
			else
			{
				MainScreenComponent.Instance.HideDeserterDesc();
			}
		}
	}
}
