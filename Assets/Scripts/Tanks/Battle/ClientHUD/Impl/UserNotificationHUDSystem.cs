using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Battle.ClientGraphics.API;
using Tanks.Battle.ClientHUD.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class UserNotificationHUDSystem : ECSSystem
	{
		public class ScreenNode : Node
		{
			public ScreenGroupComponent screenGroup;

			public BattleScreenComponent battleScreen;
		}

		public class SelfBattleUserNode : Node
		{
			public SelfBattleUserComponent selfBattleUser;

			public UserInBattleAsTankComponent userInBattleAsTank;

			public UserGroupComponent userGroup;
		}

		public class SelfUserNode : Node
		{
			public SelfUserComponent selfUser;

			public UserRankComponent userRank;

			public UserGroupComponent userGroup;
		}

		public class UserNotificatorHUDNode : Node
		{
			public UserNotificatorHUDComponent userNotificatorHUD;

			public UserNotificatorHUDTextComponent userNotificatorHUDText;

			public ScreenGroupComponent screenGroup;
		}

		public class UserNotificatorRanksNamesNode : Node
		{
			public UserNotificatorRankNamesComponent userNotificatorRankNames;

			public RanksNamesComponent ranksNames;

			public ScreenGroupComponent screenGroup;
		}

		[OnEventFire]
		public void CreateUpdateUserRankMessage(UpdateRankEffectFinishedEvent evt, SelfBattleUserNode battleUser, [JoinByUser] SelfUserNode user, [JoinAll] ScreenNode screen, [JoinByScreen] UserNotificatorHUDNode notificator, [JoinByScreen] UserNotificatorRanksNamesNode notificatorNames)
		{
			UserRankNotificationMessageBehaviour userRankNotificationMessageBehaviour = InstantiateUserNotification(notificator.userNotificatorHUD, notificator.userNotificatorHUD.UserRankNotificationMessagePrefab);
			userRankNotificationMessageBehaviour.Icon.SelectSprite(user.userRank.Rank.ToString());
			userRankNotificationMessageBehaviour.IconImage.SetNativeSize();
			userRankNotificationMessageBehaviour.Message.text = string.Format(notificator.userNotificatorHUDText.UserRankMessageFormat, notificatorNames.ranksNames.Names[user.userRank.Rank]);
			notificator.userNotificatorHUD.Push(userRankNotificationMessageBehaviour);
		}

		private T InstantiateUserNotification<T>(UserNotificatorHUDComponent notificator, T notificationPrefab) where T : BaseUserNotificationMessageBehaviour
		{
			T result = Object.Instantiate(notificationPrefab);
			Transform transform = result.transform;
			Transform transform2 = notificator.transform;
			transform.SetParent(transform2);
			transform.localScale = Vector3.one;
			transform.localRotation = Quaternion.identity;
			transform.localPosition = Vector3.zero;
			return result;
		}
	}
}
