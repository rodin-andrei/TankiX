using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	[SerialVersionUID(1431504291271L)]
	public class AddChildGroupToGroupEvent : Event
	{
		private readonly GroupComponent groupComponent;

		private readonly Type childGroupClass;

		public GroupComponent Group
		{
			get
			{
				return groupComponent;
			}
		}

		public Type ChildGroupClass
		{
			get
			{
				return childGroupClass;
			}
		}

		public AddChildGroupToGroupEvent(GroupComponent groupComponent, Type childGroupClass)
		{
			this.groupComponent = groupComponent;
			this.childGroupClass = childGroupClass;
		}
	}
}
