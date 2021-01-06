using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class BroadcastEventHandlerFactory : ConcreteEventHandlerFactory
	{
		protected BroadcastEventHandlerFactory(Type annotationEventClass, Type parameterClass) : base(default(Type), default(Type))
		{
		}

	}
}
