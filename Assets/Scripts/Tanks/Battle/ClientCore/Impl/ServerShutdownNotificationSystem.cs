using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Lobby.ClientUserProfile.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class ServerShutdownNotificationSystem : ECSSystem
	{
		public class NotificationNode : Node
		{
			public ServerShutdownNotificationComponent serverShutdownNotification;

			public ServerShutdownTextComponent serverShutdownText;
		}

		public class NotificationMessageNode : Node
		{
			public ServerShutdownNotificationComponent serverShutdownNotification;

			public ServerShutdownTextComponent serverShutdownText;

			public NotificationMessageComponent notificationMessage;
		}

		public class ShutdownNode : Node
		{
			public ServerShutdownComponent serverShutdown;
		}

		[OnEventFire]
		public void PrepareNotificationText(NodeAddedEvent e, NotificationNode notification)
		{
			notification.Entity.AddComponent(new NotificationMessageComponent(string.Empty));
		}

		[OnEventFire]
		public void UpdateTimeNotification(UpdateEvent e, NotificationMessageNode notification, [JoinAll] ShutdownNode shutdown, [Combine][JoinAll] SingleNode<LocalizedTimerComponent> timer)
		{
			float num = shutdown.serverShutdown.StopDateForClient.UnityTime - Date.Now.UnityTime;
			if (num < 0f)
			{
				num = 0f;
			}
			string arg = timer.component.GenerateTimerString(num);
			notification.notificationMessage.Message = string.Format(notification.serverShutdownText.Text, arg);
		}
	}
}
