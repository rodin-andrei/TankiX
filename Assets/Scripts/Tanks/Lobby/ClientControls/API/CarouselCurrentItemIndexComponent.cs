using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientControls.API
{
	public class CarouselCurrentItemIndexComponent : Component
	{
		public int Index
		{
			get;
			set;
		}

		public CarouselCurrentItemIndexComponent(int index)
		{
			Index = index;
		}
	}
}
