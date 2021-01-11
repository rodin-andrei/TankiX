using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientFriends.API;
using Tanks.Lobby.ClientProfile.API;
using Tanks.Lobby.ClientUserProfile.API;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class ProfileScreenSystem : ECSSystem
	{
		public class ProfileScreenWithUserGroupNode : Node
		{
			public ProfileScreenComponent profileScreen;

			public UserGroupComponent userGroup;
		}

		public class SelfUserNode : Node
		{
			public SelfUserComponent selfUser;

			public UserGroupComponent userGroup;

			public LeagueGroupComponent leagueGroup;

			public UserAvatarComponent userAvatar;
		}

		[Not(typeof(SelfUserComponent))]
		public class RemoteUserNode : Node
		{
			public UserUidComponent userUid;

			public LeagueGroupComponent leagueGroup;

			public UserComponent user;

			public UserGroupComponent userGroup;

			public UserAvatarComponent userAvatar;
		}

		public class LeagueNode : Node
		{
			public LeagueComponent league;

			public LeagueGroupComponent leagueGroup;

			public LeagueConfigComponent leagueConfig;
		}

		public class AcceptedFriendNode : RemoteUserNode
		{
			public AcceptedFriendComponent acceptedFriend;
		}

		[OnEventFire]
		public void ShowScreenElementsForSelfUser(NodeAddedEvent e, ProfileScreenWithUserGroupNode profileScreen, [JoinByUser] SelfUserNode selfUser, [JoinByLeague] LeagueNode leagueNode)
		{
			profileScreen.profileScreen.selfUserAccountButtonsTab.SetActive(true);
			profileScreen.profileScreen.otherUserAccountButtonsTab.SetActive(false);
			profileScreen.profileScreen.OtherPlayerNickname.gameObject.SetActive(false);
			profileScreen.profileScreen.Avatar.SpriteUid = selfUser.userAvatar.Id;
			profileScreen.profileScreen.IsPremium = selfUser.Entity.HasComponent<PremiumAccountBoostComponent>();
			profileScreen.profileScreen.LeagueBorder.SelectedSpriteIndex = leagueNode.leagueConfig.LeagueIndex;
		}

		[OnEventFire]
		public void ShowScreenElementsForRemoteUser(NodeAddedEvent e, ProfileScreenWithUserGroupNode profileScreen, [JoinByUser] RemoteUserNode remoteUser, [JoinByLeague] LeagueNode leagueNode)
		{
			profileScreen.profileScreen.selfUserAccountButtonsTab.SetActive(false);
			profileScreen.profileScreen.otherUserAccountButtonsTab.SetActive(true);
			profileScreen.profileScreen.OtherPlayerNickname.gameObject.SetActive(true);
			profileScreen.profileScreen.OtherPlayerNickname.text = remoteUser.userUid.Uid;
			profileScreen.profileScreen.Avatar.SpriteUid = remoteUser.userAvatar.Id;
			profileScreen.profileScreen.IsPremium = remoteUser.Entity.HasComponent<PremiumAccountBoostComponent>();
			profileScreen.profileScreen.LeagueBorder.SelectedSpriteIndex = leagueNode.leagueConfig.LeagueIndex;
			profileScreen.profileScreen.SetPlayerColor(remoteUser.Entity.HasComponent<AcceptedFriendComponent>());
		}

		[OnEventFire]
		public void SetPlayerColor(NodeAddedEvent e, AcceptedFriendNode friend, [JoinByUser] ProfileScreenWithUserGroupNode profileScreen)
		{
			profileScreen.profileScreen.SetPlayerColor(true);
		}

		[OnEventFire]
		public void SetPlayerColor(NodeRemoveEvent e, AcceptedFriendNode friend, [JoinByUser] ProfileScreenWithUserGroupNode profileScreen)
		{
			profileScreen.profileScreen.SetPlayerColor(false);
		}
	}
}
