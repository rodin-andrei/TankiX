using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class NodeAddedCompleteHandlerFactory : ConcreteEventHandlerFactory
	{
		public NodeAddedCompleteHandlerFactory() : base(default(Type), default(Type))
		{
		}

	}
}
