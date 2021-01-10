using Platform.Kernel.ECS.ClientEntitySystem.API;
using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class AddChildGroupToGroupEvent : Event
	{
		public AddChildGroupToGroupEvent(GroupComponent groupComponent, Type childGroupClass)
		{
		}

	}
}
