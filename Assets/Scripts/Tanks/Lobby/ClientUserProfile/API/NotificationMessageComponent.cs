using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class NotificationMessageComponent : Component
	{
		public string Message
		{
			get;
			set;
		}

		public NotificationMessageComponent()
		{
		}

		public NotificationMessageComponent(string message)
		{
			Message = message;
		}
	}
}
