using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class EarlyUpdateFireHandlerFactory : BroadcastEventHandlerFactory
	{
		public EarlyUpdateFireHandlerFactory() : base(default(Type), default(Type))
		{
		}

	}
}
