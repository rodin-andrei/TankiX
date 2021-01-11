using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Platform.System.Data.Exchange.ClientNetwork.API;
using Tanks.Lobby.ClientNavigation.API;

namespace Tanks.Lobby.ClientNavigation.Impl
{
	public class NavigationStatisticsSystem : ECSSystem
	{
		public class ActiveScreenNode : Node
		{
			public ScreenComponent screen;

			public ActiveScreenComponent activeScreen;
		}

		public class ClientSessionNode : Node
		{
			public ClientSessionComponent clientSession;
		}

		[OnEventFire]
		public void SendEnterScreen(NodeAddedEvent e, ActiveScreenNode screen, [JoinAll] ClientSessionNode clientSession)
		{
			ScheduleEvent(new EnterScreenEvent(screen.screen.gameObject.name), clientSession);
		}
	}
}
