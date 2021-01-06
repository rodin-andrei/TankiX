using Platform.Kernel.ECS.ClientEntitySystem.Impl;

namespace Platform.System.Data.Exchange.ClientNetwork.Impl
{
	public class EventCommandCollector : AbstractCommandCollector
	{
		public EventCommandCollector(CommandCollector commandCollector, ComponentAndEventRegistrator componentAndEventRegistrator, SharedEntityRegistry entityRegistry) : base(default(CommandCollector))
		{
		}

	}
}
