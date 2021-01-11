using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientPayment.Impl
{
	[Shared]
	[SerialVersionUID(1470652819513L)]
	public class GoToPaymentRequestEvent : Event
	{
		private string steamId;

		private string ticket;

		public bool SteamIsActive
		{
			get;
			set;
		}

		public string SteamId
		{
			get
			{
				return steamId ?? string.Empty;
			}
			set
			{
				steamId = value;
			}
		}

		public string Ticket
		{
			get
			{
				return ticket ?? string.Empty;
			}
			set
			{
				ticket = value;
			}
		}
	}
}
