using Platform.Kernel.ECS.ClientEntitySystem.API;
using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class RemoveChildGroupFromGroupEvent : Event
	{
		public RemoveChildGroupFromGroupEvent(GroupComponent groupComponent, Type childGroupClass)
		{
		}

	}
}
