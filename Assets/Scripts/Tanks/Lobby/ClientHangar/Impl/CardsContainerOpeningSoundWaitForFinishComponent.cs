using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class CardsContainerOpeningSoundWaitForFinishComponent : Component
	{
		public ScheduleManager ScheduledEvent
		{
			get;
			set;
		}

		public CardsContainerOpeningSoundWaitForFinishComponent(ScheduleManager scheduledEvent)
		{
			ScheduledEvent = scheduledEvent;
		}
	}
}
