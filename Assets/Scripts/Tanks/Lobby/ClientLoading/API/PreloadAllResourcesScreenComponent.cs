using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;

namespace Tanks.Lobby.ClientLoading.API
{
	public class PreloadAllResourcesScreenComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component, NoScaleScreen
	{
		public ResourcesLoadProgressBarComponent progressBar;

		public LoadingStatusView loadingStatusView;

		private void Awake()
		{
			GetComponent<LoadBundlesTaskProviderComponent>().OnDataChange = OnDataChange;
		}

		private void OnDataChange(LoadBundlesTaskComponent loadBundlesTask)
		{
			progressBar.UpdateView(loadBundlesTask);
			loadingStatusView.UpdateView(loadBundlesTask);
		}
	}
}
