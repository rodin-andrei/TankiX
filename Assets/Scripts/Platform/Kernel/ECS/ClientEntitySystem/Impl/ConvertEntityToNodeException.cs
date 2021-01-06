using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class ConvertEntityToNodeException : Exception
	{
		public ConvertEntityToNodeException(NodeDescription nodeDescription, Entity entity)
		{
		}

	}
}
