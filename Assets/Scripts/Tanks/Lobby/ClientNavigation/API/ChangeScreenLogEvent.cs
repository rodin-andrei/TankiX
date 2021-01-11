using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class ChangeScreenLogEvent : Event
	{
		public LogScreen NextScreen
		{
			get;
			set;
		}

		public ChangeScreenLogEvent(LogScreen nextScreen)
		{
			NextScreen = nextScreen;
		}
	}
}
