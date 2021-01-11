using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.System.Data.Exchange.ClientNetwork.API;

namespace Tanks.Lobby.ClientEntrance.Impl
{
	public class ConnectionReportSystem : ECSSystem
	{
		public class SessionNode : Node
		{
			public ClientSessionComponent clientSession;
		}

		public bool hasConnection;

		[OnEventFire]
		public void Set(NodeAddedEvent e, SessionNode session)
		{
			hasConnection = true;
		}
	}
}
