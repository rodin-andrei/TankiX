using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class UpdateEventCompleteHandlerFactory : BroadcastEventHandlerFactory
	{
		public UpdateEventCompleteHandlerFactory() : base(default(Type), default(Type))
		{
		}

	}
}
