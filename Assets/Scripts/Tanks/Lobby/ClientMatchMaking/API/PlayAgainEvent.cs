using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientMatchMaking.API
{
	public class PlayAgainEvent : Event
	{
		private bool modeIsAvailable;

		public bool ModeIsAvailable
		{
			get
			{
				return modeIsAvailable;
			}
			set
			{
				modeIsAvailable = value;
			}
		}

		public Entity MatchMackingMode
		{
			get;
			set;
		}
	}
}
