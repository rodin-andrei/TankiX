using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class ScreensLayerComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public RectTransform selfRectTransform;

		public RectTransform dialogsLayer;

		public RectTransform dialogs60Layer;

		public RectTransform screensLayer;

		public RectTransform screens60Layer;
	}
}
