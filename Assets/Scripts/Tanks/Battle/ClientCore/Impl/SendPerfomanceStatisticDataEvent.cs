using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class SendPerfomanceStatisticDataEvent : Event
	{
		public SendPerfomanceStatisticDataEvent(PerformanceStatisticData data)
		{
		}

	}
}
