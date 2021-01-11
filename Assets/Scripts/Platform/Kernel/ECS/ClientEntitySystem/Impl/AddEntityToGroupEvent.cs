using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class AddEntityToGroupEvent : Event
	{
		private GroupComponent groupComponent;

		public GroupComponent Group
		{
			get
			{
				return groupComponent;
			}
		}

		public AddEntityToGroupEvent(GroupComponent group)
		{
			groupComponent = group;
		}
	}
}
