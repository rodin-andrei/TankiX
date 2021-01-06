using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class AfterFixedUpdateEventFireHandlerFactory : BroadcastEventHandlerFactory
	{
		public AfterFixedUpdateEventFireHandlerFactory() : base(default(Type), default(Type))
		{
		}

	}
}
