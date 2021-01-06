using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class LoadSceneEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event {
		public LoadSceneEvent(string sceneName, Object sceneAsset)
		{
		}

	}
}
