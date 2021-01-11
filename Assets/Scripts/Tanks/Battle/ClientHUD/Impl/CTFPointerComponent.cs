using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class CTFPointerComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public RectTransform parentCanvasRect;

		public RectTransform selfRect;

		public CanvasGroup canvasGroup;

		public Text text;

		public void Hide()
		{
			canvasGroup.alpha = 0f;
		}

		public void Show()
		{
			canvasGroup.alpha = 1f;
		}

		private void OnDisable()
		{
			Hide();
		}
	}
}
