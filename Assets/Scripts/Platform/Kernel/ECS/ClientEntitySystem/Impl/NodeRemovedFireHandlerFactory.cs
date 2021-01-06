using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class NodeRemovedFireHandlerFactory : ConcreteEventHandlerFactory
	{
		public NodeRemovedFireHandlerFactory() : base(default(Type), default(Type))
		{
		}

	}
}
