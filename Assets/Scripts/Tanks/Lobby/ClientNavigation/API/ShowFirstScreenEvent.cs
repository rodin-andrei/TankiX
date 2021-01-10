using System;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class ShowFirstScreenEvent : ShowScreenEvent
	{
		public ShowFirstScreenEvent(Type screenType) : base(default(Type), default(AnimationDirection))
		{
		}

	}
}
