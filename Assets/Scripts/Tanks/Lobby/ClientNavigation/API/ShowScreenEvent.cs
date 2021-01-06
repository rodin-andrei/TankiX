using Platform.Kernel.ECS.ClientEntitySystem.API;
using System;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class ShowScreenEvent : Event
	{
		public ShowScreenEvent(Type screenType, AnimationDirection animationDirection)
		{
		}

	}
}
