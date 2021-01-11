using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	[SerialVersionUID(635824352545785226L)]
	public class MapInstanceComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject SceneRoot
		{
			get;
			set;
		}

		public MapInstanceComponent()
		{
		}

		public MapInstanceComponent(GameObject sceneRoot)
		{
			SceneRoot = sceneRoot;
		}
	}
}
