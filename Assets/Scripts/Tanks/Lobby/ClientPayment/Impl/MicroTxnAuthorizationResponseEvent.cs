using Platform.Kernel.ECS.ClientEntitySystem.API;
using Steamworks;

namespace Tanks.Lobby.ClientPayment.Impl
{
	public class MicroTxnAuthorizationResponseEvent : Event
	{
		public MicroTxnAuthorizationResponseEvent(MicroTxnAuthorizationResponse_t response)
		{
		}

	}
}
