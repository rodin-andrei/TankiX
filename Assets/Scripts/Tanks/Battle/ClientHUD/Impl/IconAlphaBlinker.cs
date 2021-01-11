using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	[RequireComponent(typeof(CanvasGroup))]
	public class IconAlphaBlinker : MonoBehaviour
	{
		private CanvasGroup icon;

		private void Awake()
		{
			icon = GetComponent<CanvasGroup>();
		}

		public void OnBlink(float value)
		{
			icon.alpha = value;
		}
	}
}
