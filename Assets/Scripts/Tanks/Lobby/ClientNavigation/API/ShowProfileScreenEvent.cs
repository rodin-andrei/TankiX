using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class ShowProfileScreenEvent : Event
	{
		public long UserId
		{
			get;
			set;
		}

		public ShowProfileScreenEvent(long userId)
		{
			UserId = userId;
		}
	}
}
