using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientGarage.API
{
	public class ChangeScreenEvent : Event
	{
		public ChangeScreenEvent(string currentScreen, string nextScreen, double duration)
		{
		}

	}
}
