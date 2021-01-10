using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class FixedUpdateEventCompleteHandlerFactory : BroadcastEventHandlerFactory
	{
		public FixedUpdateEventCompleteHandlerFactory() : base(default(Type), default(Type))
		{
		}

	}
}
