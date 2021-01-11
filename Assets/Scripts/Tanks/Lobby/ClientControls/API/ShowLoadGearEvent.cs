using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientControls.API
{
	public class ShowLoadGearEvent : Event
	{
		public bool ShowProgress
		{
			get;
			set;
		}

		public ShowLoadGearEvent()
		{
			ShowProgress = false;
		}

		public ShowLoadGearEvent(bool showProgress)
		{
			ShowProgress = showProgress;
		}
	}
}
