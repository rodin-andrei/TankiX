using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientControls.API
{
	public class ScreenRangeChangedEvent : Event
	{
		public IndexRange Range
		{
			get;
			set;
		}

		public ScreenRangeChangedEvent(IndexRange range)
		{
			Range = range;
		}
	}
}
