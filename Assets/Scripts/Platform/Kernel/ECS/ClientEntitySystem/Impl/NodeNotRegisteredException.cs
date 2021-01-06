using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class NodeNotRegisteredException : Exception
	{
		public NodeNotRegisteredException(NodeDescription nodeDescription)
		{
		}

	}
}
