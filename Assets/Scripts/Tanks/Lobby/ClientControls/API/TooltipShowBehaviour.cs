using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class TooltipShowBehaviour : MonoBehaviour
	{
		public bool showTooltip;
		public bool customContentPrefab;
		public GameObject customPrefab;
		public bool defaultBackground;
		public bool overrideDelay;
		public float customDelay;
		public LocalizedField localizedTip;
	}
}
