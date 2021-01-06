using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class NodeAddedFireHandlerFactory : ConcreteEventHandlerFactory
	{
		public NodeAddedFireHandlerFactory() : base(default(Type), default(Type))
		{
		}

	}
}
