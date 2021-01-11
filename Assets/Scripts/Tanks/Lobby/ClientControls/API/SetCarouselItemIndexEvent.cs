using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientControls.API
{
	public class SetCarouselItemIndexEvent : Event
	{
		public int Index
		{
			get;
			set;
		}

		public SetCarouselItemIndexEvent(int index)
		{
			Index = index;
		}
	}
}
