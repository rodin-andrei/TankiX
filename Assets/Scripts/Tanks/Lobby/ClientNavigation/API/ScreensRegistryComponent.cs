using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class ScreensRegistryComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public List<GameObject> screens = new List<GameObject>();
	}
}
