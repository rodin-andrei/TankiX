using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class EarlyUpdateCompleteHandlerFactory : BroadcastEventHandlerFactory
	{
		public EarlyUpdateCompleteHandlerFactory() : base(default(Type), default(Type))
		{
		}

	}
}
