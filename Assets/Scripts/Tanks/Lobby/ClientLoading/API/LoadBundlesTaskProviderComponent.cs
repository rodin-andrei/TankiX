using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientLoading.API
{
	public class LoadBundlesTaskProviderComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		private LoadBundlesTaskComponent loadBundlesTask;

		public Action<LoadBundlesTaskComponent> OnDataChange;

		public LoadBundlesTaskComponent LoadBundlesTask
		{
			get
			{
				return loadBundlesTask;
			}
		}

		public void UpdateData(LoadBundlesTaskComponent loadBundlesTask)
		{
			this.loadBundlesTask = loadBundlesTask;
			if (OnDataChange != null)
			{
				OnDataChange(loadBundlesTask);
			}
		}
	}
}
