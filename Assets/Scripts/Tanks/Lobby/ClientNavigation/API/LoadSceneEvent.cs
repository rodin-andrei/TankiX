using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class LoadSceneEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
	{
		public string SceneName
		{
			get;
			private set;
		}

		public Object SceneAsset
		{
			get;
			private set;
		}

		public LoadSceneEvent(string sceneName, Object sceneAsset)
		{
			SceneName = sceneName;
			SceneAsset = sceneAsset;
		}
	}
}
