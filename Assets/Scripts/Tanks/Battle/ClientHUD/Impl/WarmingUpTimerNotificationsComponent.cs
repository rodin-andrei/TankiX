using Platform.Library.ClientUnityIntegration.API;
using System;
using UnityEngine;
using System.Collections.Generic;

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
		private List<WarmingUpTimerNotificationsComponent.NotificationTime> warmingUpTimerNotifications;
		[SerializeField]
		private GameObject startBattleNotification;
	}
}
