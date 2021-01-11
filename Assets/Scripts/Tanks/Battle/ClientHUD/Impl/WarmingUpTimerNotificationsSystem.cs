using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientResources.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class WarmingUpTimerNotificationsSystem : ECSSystem
	{
		public class RoundWarmingUpStateNode : Node
		{
			public RoundStopTimeComponent roundStopTime;

			public RoundActiveStateComponent roundActiveState;

			public RoundWarmingUpStateComponent roundWarmingUpState;
		}

		public class SelfBattleUserNode : Node
		{
			public BattleGroupComponent battleGroup;

			public UserGroupComponent userGroup;

			public SelfBattleUserComponent selfBattleUser;
		}

		public class BattleNode : Node
		{
			public TimeLimitComponent timeLimit;

			public BattleStartTimeComponent battleStartTime;

			public BattleGroupComponent battleGroup;
		}

		public class WarmingUpTimerNotificationsNode : Node
		{
			public WarmingUpTimerNotificationsComponent warmingUpTimerNotifications;
		}

		public class WarmingUpTimerNotificationNode : Node
		{
			public WarmingUpTimerNotificationUIComponent warmingUpTimerNotificationUI;
		}

		public class WarmingUpTimerNotificationDataNode : WarmingUpTimerNotificationNode
		{
			public ResourceDataComponent resourceData;
		}

		[OnEventFire]
		public void InitNotifications(NodeAddedEvent e, BattleNode battle, [JoinByBattle][Context] RoundWarmingUpStateNode round, WarmingUpTimerNotificationsNode notifications)
		{
			float remainingTime = battle.battleStartTime.RoundStartTime.UnityTime - Date.Now.UnityTime;
			notifications.warmingUpTimerNotifications.Init(remainingTime);
		}

		[OnEventFire]
		public void ShowStartBattleNotification(NodeRemoveEvent e, RoundWarmingUpStateNode round, [JoinAll] WarmingUpTimerNotificationsNode notifications)
		{
			notifications.warmingUpTimerNotifications.ShowStartBattleNotification();
		}

		[OnEventFire]
		public void DeactivateNotifications(NodeRemoveEvent e, RoundWarmingUpStateNode round, WarmingUpTimerNotificationsNode notifications)
		{
			notifications.warmingUpTimerNotifications.DeactivateNotifications();
		}

		[OnEventFire]
		public void ShowWarmingUpTimerNotifications(UpdateEvent e, BattleNode battle, [JoinByBattle] SelfBattleUserNode self, [JoinByBattle] RoundWarmingUpStateNode round, [JoinAll] WarmingUpTimerNotificationsNode notifications)
		{
			if (notifications.warmingUpTimerNotifications.HasNotifications())
			{
				float num = battle.battleStartTime.RoundStartTime.UnityTime - Date.Now.UnityTime;
				if (notifications.warmingUpTimerNotifications.NextNotificationTime > num)
				{
					ScheduleEvent<DisableOldMultikillNotificationsEvent>(notifications);
					notifications.warmingUpTimerNotifications.ShowNextNotification();
				}
			}
		}

		[OnEventFire]
		public void LoadWarmingUpTimerNotificationSound(NodeAddedEvent e, WarmingUpTimerNotificationNode node)
		{
			AssetReference voiceReference = node.warmingUpTimerNotificationUI.VoiceReference;
			if (voiceReference != null && !string.IsNullOrEmpty(voiceReference.AssetGuid))
			{
				AssetReferenceComponent component = new AssetReferenceComponent(voiceReference);
				node.Entity.AddComponent(component);
				node.Entity.AddComponent<AssetRequestComponent>();
			}
		}

		[OnEventFire]
		public void PlayWarmingUpTimerNotificationSound(NodeAddedEvent e, WarmingUpTimerNotificationDataNode node)
		{
			node.warmingUpTimerNotificationUI.PlaySound((GameObject)node.resourceData.Data);
		}
	}
}
