using System;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class ShowScreenLeftEvent<T> : ShowScreenEvent
	{
		public ShowScreenLeftEvent() : base(default(Type), default(AnimationDirection))
		{
		}

	}
}
