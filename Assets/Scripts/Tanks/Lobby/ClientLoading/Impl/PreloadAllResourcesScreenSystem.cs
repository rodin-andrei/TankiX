using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientResources.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientLoading.API;

namespace Tanks.Lobby.ClientLoading.Impl
{
	public class PreloadAllResourcesScreenSystem : ECSSystem
	{
		public class LoadingScreenNode : Node
		{
			public PreloadAllResourcesScreenComponent preloadAllResourcesScreen;

			public ResourcesLoadProgressBarComponent resourcesLoadProgressBar;

			public LoadBundlesTaskComponent loadBundlesTask;
		}

		public class SkipButtonTextNode : Node
		{
			public SkipLoadButtonComponent skipLoadButton;

			public TextMappingComponent textMapping;
		}

		private static readonly float WAIT_TIME_BEFORE_SKIP_BUTTON_ENABLE;

		[OnEventFire]
		public void SkipPreload(ButtonClickEvent e, SingleNode<SkipLoadButtonComponent> button, [JoinAll] LoadingScreenNode screen, [JoinAll] SingleNode<PreloadAllResourcesComponent> preload)
		{
			screen.loadBundlesTask.TrackedBundles.Clear();
			preload.Entity.RemoveComponent<PreloadAllResourcesComponent>();
		}
	}
}
