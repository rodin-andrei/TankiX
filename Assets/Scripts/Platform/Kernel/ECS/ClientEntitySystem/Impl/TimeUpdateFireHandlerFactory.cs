using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class TimeUpdateFireHandlerFactory : BroadcastEventHandlerFactory
	{
		public TimeUpdateFireHandlerFactory() : base(default(Type), default(Type))
		{
		}

	}
}
