using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class NodeRemovedCompleteHandlerFactory : ConcreteEventHandlerFactory
	{
		public NodeRemovedCompleteHandlerFactory() : base(default(Type), default(Type))
		{
		}

	}
}
