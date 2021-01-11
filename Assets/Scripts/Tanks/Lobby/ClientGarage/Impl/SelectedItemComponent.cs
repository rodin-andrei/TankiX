using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SelectedItemComponent : Component
	{
		public Entity SelectedItem
		{
			get;
			set;
		}

		public SelectedItemComponent()
		{
		}

		public SelectedItemComponent(Entity selectedItem)
		{
			SelectedItem = selectedItem;
		}
	}
}
