using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class TimeUpdateCompleteHandlerFactory : BroadcastEventHandlerFactory
	{
		public TimeUpdateCompleteHandlerFactory() : base(default(Type), default(Type))
		{
		}

	}
}
