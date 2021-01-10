using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class CTFPointerComponent : MonoBehaviour
	{
		public RectTransform parentCanvasRect;
		public RectTransform selfRect;
		public CanvasGroup canvasGroup;
		public Text text;
	}
}
