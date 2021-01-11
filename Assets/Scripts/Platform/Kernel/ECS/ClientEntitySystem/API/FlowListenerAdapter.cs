namespace Platform.Kernel.ECS.ClientEntitySystem.API
{
	public class FlowListenerAdapter : FlowListener
	{
		public static readonly FlowListenerAdapter Stub = new FlowListenerAdapter();

		public void OnFlowFinish()
		{
		}

		public void OnFlowClean()
		{
		}
	}
}
