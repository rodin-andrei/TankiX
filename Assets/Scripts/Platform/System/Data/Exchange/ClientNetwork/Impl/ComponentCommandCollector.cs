using Platform.Kernel.ECS.ClientEntitySystem.Impl;

namespace Platform.System.Data.Exchange.ClientNetwork.Impl
{
	public class ComponentCommandCollector : AbstractCommandCollector
	{
		public ComponentCommandCollector(CommandCollector commandCollector, ComponentAndEventRegistrator componentAndEventRegistrator, SharedEntityRegistry entityRegistry) : base(default(CommandCollector))
		{
		}

	}
}
