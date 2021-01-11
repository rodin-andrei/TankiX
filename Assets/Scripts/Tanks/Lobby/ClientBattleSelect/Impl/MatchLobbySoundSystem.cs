using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientBattleSelect.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientGarage.Impl;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class MatchLobbySoundSystem : ECSSystem
	{
		public class SelfUserInMatchMakingLobby : Node
		{
			public MatchMakingUserComponent matchMakingUser;

			public UserComponent user;

			public SelfUserComponent selfUser;

			public BattleLobbyGroupComponent battleLobbyGroup;
		}

		public class BattleLobbyNode : Node
		{
			public BattleLobbyGroupComponent battleLobbyGroup;

			public BattleLobbyComponent battleLobby;
		}

		[OnEventFire]
		public void PlayLobbySound(NodeAddedEvent e, SelfUserInMatchMakingLobby user, [Context][JoinByBattleLobby] BattleLobbyNode battleLobby, [JoinAll] SingleNode<MainScreenComponent> mainScreen, [JoinAll] SingleNode<HangarMatchLobbySoundComponent> hangar)
		{
			hangar.component.Play();
		}
	}
}
