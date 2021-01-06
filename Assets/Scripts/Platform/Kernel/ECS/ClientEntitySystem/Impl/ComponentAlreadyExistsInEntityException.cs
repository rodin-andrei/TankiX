using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class ComponentAlreadyExistsInEntityException : Exception
	{
		public ComponentAlreadyExistsInEntityException(EntityInternal entity, Type componentClass)
		{
		}

	}
}
