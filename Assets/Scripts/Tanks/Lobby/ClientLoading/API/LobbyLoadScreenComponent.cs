using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientLoading.API
{
	public class LobbyLoadScreenComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component, NoScaleScreen
	{
		public TextMeshProUGUI initialization;

		public ResourcesLoadProgressBarComponent progressBar;

		public LoadingStatusView loadingStatus;

		private void Awake()
		{
			GetComponent<LoadBundlesTaskProviderComponent>().OnDataChange = OnDataChange;
		}

		private void OnDataChange(LoadBundlesTaskComponent loadBundlesTask)
		{
			progressBar.UpdateView(loadBundlesTask);
			initialization.gameObject.SetActive(loadBundlesTask.BytesToLoad <= loadBundlesTask.BytesLoaded);
			loadingStatus.UpdateView(loadBundlesTask);
		}
	}
}
