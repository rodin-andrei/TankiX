using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class ShowScreenEvent : Event
	{
		public ShowScreenData ShowScreenData
		{
			get;
			protected set;
		}

		public ShowScreenEvent(Type screenType, AnimationDirection animationDirection)
		{
			ShowScreenData = new ShowScreenData(screenType, animationDirection);
		}

		public void SetContext(Entity context, bool autoDelete)
		{
			ShowScreenData.Context = context;
			ShowScreenData.AutoDeleteContext = autoDelete;
		}
	}
}
