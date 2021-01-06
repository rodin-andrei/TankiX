using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class GetLeagueByIndexEvent : Event
	{
		public GetLeagueByIndexEvent(int index)
		{
		}

		public int index;
	}
}
