using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;

namespace Platform.System.Data.Exchange.ClientNetwork.Impl
{
	public class AbstractCommandCollector
	{
		private readonly CommandCollector commandCollector;

		[Inject]
		public static FlowInstancesCache Cache
		{
			get;
			set;
		}

		[Inject]
		public static ProtocolFlowInstancesCache ProtcolCache
		{
			get;
			set;
		}

		public bool DecodeStage
		{
			get;
			set;
		}

		public AbstractCommandCollector(CommandCollector commandCollector)
		{
			this.commandCollector = commandCollector;
		}

		protected void AddCommand(Command command)
		{
			commandCollector.Add(command);
		}
	}
}
