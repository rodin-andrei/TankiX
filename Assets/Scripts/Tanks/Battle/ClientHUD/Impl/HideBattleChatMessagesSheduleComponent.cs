using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class HideBattleChatMessagesSheduleComponent : Component
	{
		public ScheduledEvent ScheduledEvent
		{
			get;
			set;
		}

		public HideBattleChatMessagesSheduleComponent(ScheduledEvent scheduledEvent)
		{
			ScheduledEvent = scheduledEvent;
		}

		public HideBattleChatMessagesSheduleComponent()
		{
		}
	}
}
