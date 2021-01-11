using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientDataStructures.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientFriends.API;
using Tanks.Lobby.ClientUserProfile.API;
using UnityEngine;

namespace Tanks.Lobby.ClientFriends.Impl
{
	public class FriendInteractionSystem : ECSSystem
	{
		public class FriendLabelNode : Node
		{
			public UserLabelComponent userLabel;

			public UserGroupComponent userGroup;

			public IncomingFriendButtonsComponent incomingFriendButtons;

			public OutgoingFriendButtonsComponent outgoingFriendButtons;

			public FriendInteractionButtonComponent friendInteractionButton;
		}

		[Not(typeof(SelfUserComponent))]
		public class FriendNode : Node
		{
			public UserComponent user;

			public UserGroupComponent userGroup;
		}

		public class AcceptedFriendNode : FriendNode
		{
			public AcceptedFriendComponent acceptedFriend;
		}

		public class UserInBattleNode : FriendNode
		{
			public BattleGroupComponent battleGroup;
		}

		[OnEventFire]
		public void ShowTooltipInLobby(RightMouseButtonClickEvent e, FriendLabelNode userButton, [JoinByUser] FriendNode friend, [JoinByUser] Optional<UserInBattleNode> userInBattle, [JoinAll] SingleNode<SelfUserComponent> selfUser)
		{
			bool flag = friend.Entity.HasComponent<AcceptedFriendComponent>();
			bool flag2 = selfUser.Entity.HasComponent<UserAdminComponent>();
			CheckForSpectatorButtonShowEvent checkForSpectatorButtonShowEvent = new CheckForSpectatorButtonShowEvent();
			ScheduleEvent(checkForSpectatorButtonShowEvent, friend);
			CheckForShowInviteToSquadEvent checkForShowInviteToSquadEvent = new CheckForShowInviteToSquadEvent();
			ScheduleEvent(checkForShowInviteToSquadEvent, friend);
			FriendInteractionTooltipData friendInteractionTooltipData = new FriendInteractionTooltipData();
			friendInteractionTooltipData.FriendEntity = friend.Entity;
			friendInteractionTooltipData.ShowRemoveButton = flag;
			friendInteractionTooltipData.ShowEnterAsSpectatorButton = userInBattle.IsPresent() && (flag || flag2) && checkForSpectatorButtonShowEvent.CanGoToSpectatorMode;
			friendInteractionTooltipData.ShowInviteToSquadButton = checkForShowInviteToSquadEvent.ShowInviteToSquadButton;
			friendInteractionTooltipData.ActiveShowInviteToSquadButton = checkForShowInviteToSquadEvent.ActiveInviteToSquadButton;
			friendInteractionTooltipData.ShowRequestToSquadButton = checkForShowInviteToSquadEvent.ShowRequestToInviteToSquadButton;
			friendInteractionTooltipData.ShowChatButton = friend.Entity.HasComponent<UserOnlineComponent>();
			FriendInteractionTooltipData data = friendInteractionTooltipData;
			TooltipController.Instance.ShowTooltip(Input.mousePosition, data, userButton.friendInteractionButton.tooltipPrefab, false);
		}

		[OnEventFire]
		public void RemoveFriend(RemoveFriendButtonEvent e, AcceptedFriendNode friend, [JoinAll] SingleNode<FriendsScreenComponent> friendsScreen, [JoinAll] SingleNode<SelfUserComponent> selfUser)
		{
			ScheduleEvent(new BreakOffFriendEvent(friend.Entity), selfUser);
			friendsScreen.component.RemoveUser(friend.Entity.Id, true);
		}
	}
}
