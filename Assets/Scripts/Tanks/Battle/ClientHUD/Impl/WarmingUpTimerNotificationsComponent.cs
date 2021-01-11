using System;
using System.Collections.Generic;
using System.Linq;
using Platform.Library.ClientDataStructures.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class WarmingUpTimerNotificationsComponent : BehaviourComponent
	{
		[Serializable]
		public class NotificationTime
		{
			public float remainingTime;

			public GameObject notification;
		}

		[SerializeField]
		private List<NotificationTime> warmingUpTimerNotifications;

		[SerializeField]
		private GameObject startBattleNotification;

		private bool notificationsInitialized;

		private Queue<NotificationTime> notifications = new Queue<NotificationTime>();

		public float NextNotificationTime
		{
			get;
			set;
		}

		public void Init(float remainingTime)
		{
			SetNotificationsToInactiveState();
			notifications = new Queue<NotificationTime>(warmingUpTimerNotifications.Where((NotificationTime notification) => notification.remainingTime <= remainingTime));
			NextNotificationTime = GetNextNotificationTime();
			notificationsInitialized = true;
		}

		public void ShowNextNotification()
		{
			if (notificationsInitialized)
			{
				notifications.Dequeue().notification.SetActive(true);
				NextNotificationTime = GetNextNotificationTime();
			}
		}

		public void ShowStartBattleNotification()
		{
			startBattleNotification.SetActive(true);
		}

		public bool HasNotifications()
		{
			return notifications.Count > 0;
		}

		public float GetNextNotificationTime()
		{
			return (!HasNotifications()) ? (-1f) : notifications.Peek().remainingTime;
		}

		private void SetNotificationsToInactiveState()
		{
			EnumerableExtension.ForEach(warmingUpTimerNotifications, delegate(NotificationTime notification)
			{
				notification.notification.SetActive(false);
			});
			startBattleNotification.SetActive(false);
		}

		public void DeactivateNotifications()
		{
			notificationsInitialized = false;
		}

		private void OnDisable()
		{
			SetNotificationsToInactiveState();
		}
	}
}
