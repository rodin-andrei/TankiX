using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class AfterFixedUpdateEventCompleteHandlerFactory : BroadcastEventHandlerFactory
	{
		public AfterFixedUpdateEventCompleteHandlerFactory() : base(default(Type), default(Type))
		{
		}

	}
}
