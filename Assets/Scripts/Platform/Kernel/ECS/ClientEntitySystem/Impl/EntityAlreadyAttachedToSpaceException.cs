using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class EntityAlreadyAttachedToSpaceException : Exception
	{
		public EntityAlreadyAttachedToSpaceException(Entity entity)
		{
		}

	}
}
