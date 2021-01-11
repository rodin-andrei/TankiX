using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.ClientLauncher.Impl
{
	public class LauncherDownloadScreenComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component, NoScaleScreen
	{
		public Text loadingInfo;
	}
}
