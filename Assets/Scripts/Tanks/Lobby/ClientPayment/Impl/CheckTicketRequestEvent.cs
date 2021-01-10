using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientPayment.Impl
{
	public class CheckTicketRequestEvent : Event
	{
		public CheckTicketRequestEvent(string steamId, string ticket)
		{
		}

	}
}
