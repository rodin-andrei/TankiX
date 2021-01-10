using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class UpdateEventFireHandlerFactory : BroadcastEventHandlerFactory
	{
		public UpdateEventFireHandlerFactory() : base(default(Type), default(Type))
		{
		}

	}
}
