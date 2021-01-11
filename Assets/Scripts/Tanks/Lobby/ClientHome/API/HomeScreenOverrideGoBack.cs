using Tanks.Lobby.ClientNavigation.API;

namespace Tanks.Lobby.ClientHome.API
{
	public class HomeScreenOverrideGoBack : OverrideGoBack
	{
		private ShowScreenData data = new ShowScreenData(typeof(HomeScreenComponent), AnimationDirection.DOWN);

		public override ShowScreenData ScreenData
		{
			get
			{
				return data;
			}
		}
	}
}
