using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class GroupComponenAlreadyInitializedException : Exception
	{
		public GroupComponenAlreadyInitializedException(GroupComponent groupComponent)
		{
		}

	}
}
