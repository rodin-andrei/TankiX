using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	[SerialVersionUID(635838815918272155L)]
	public class HangarInstanceComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject SceneRoot
		{
			get;
			set;
		}

		public HangarInstanceComponent()
		{
		}

		public HangarInstanceComponent(GameObject sceneRoot)
		{
			SceneRoot = sceneRoot;
		}
	}
}
