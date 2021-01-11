using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class HangarCameraRotateScheduledComponent : Component
	{
		public ScheduledEvent ScheduledEvent
		{
			get;
			set;
		}

		public HangarCameraRotateScheduledComponent()
		{
		}

		public HangarCameraRotateScheduledComponent(ScheduledEvent scheduledEvent)
		{
			ScheduledEvent = scheduledEvent;
		}
	}
}
