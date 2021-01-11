using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientNavigation.Impl
{
	[Shared]
	[SerialVersionUID(1453867134827L)]
	public class EnterScreenEvent : Event
	{
		public string Screen
		{
			get;
			set;
		}

		public EnterScreenEvent()
		{
		}

		public EnterScreenEvent(string screen)
		{
			Screen = screen;
		}
	}
}
