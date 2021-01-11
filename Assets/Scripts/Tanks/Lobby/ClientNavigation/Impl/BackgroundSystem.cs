using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientNavigation.API;

namespace Tanks.Lobby.ClientNavigation.Impl
{
	public class BackgroundSystem : ECSSystem
	{
		public class ActiveScreenNode : Node
		{
			public ShowBackgroundComponent showBackground;

			public ActiveScreenComponent activeScreen;
		}

		public class HidingScreenNode : Node
		{
			public ShowBackgroundComponent showBackground;

			public ScreenHidingComponent screenHiding;
		}

		[OnEventFire]
		public void MoveBackgroundOnInit(NodeAddedEvent e, SingleNode<BackgroundComponent> background, SingleNode<ScreensLayerComponent> screensLayer)
		{
			background.component.transform.SetParent(screensLayer.component.transform, false);
			background.component.transform.SetAsFirstSibling();
		}

		[OnEventFire]
		public void ShowBackground(NodeAddedEvent e, ActiveScreenNode screen, [JoinAll] SingleNode<BackgroundComponent> background)
		{
			background.component.Show();
		}

		[OnEventFire]
		public void HideBackground(NodeAddedEvent e, HidingScreenNode screen, [JoinAll] SingleNode<BackgroundComponent> background)
		{
			background.component.Hide();
		}
	}
}
