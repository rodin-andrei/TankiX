using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class FixedUpdateEventFireHandlerFactory : BroadcastEventHandlerFactory
	{
		public FixedUpdateEventFireHandlerFactory() : base(default(Type), default(Type))
		{
		}

	}
}
