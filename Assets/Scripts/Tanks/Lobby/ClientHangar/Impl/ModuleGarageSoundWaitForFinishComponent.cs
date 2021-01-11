using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class ModuleGarageSoundWaitForFinishComponent : Component
	{
		public ScheduleManager ScheduledEvent
		{
			get;
			set;
		}

		public ModuleGarageSoundWaitForFinishComponent(ScheduleManager scheduledEvent)
		{
			ScheduledEvent = scheduledEvent;
		}
	}
}
