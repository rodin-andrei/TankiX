using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class TooltipController : MonoBehaviour
	{
		public Tooltip tooltip;
		public float delayBeforeTooltipShowAfterCursorStop;
		public float maxDelayForQuickShowAfterCursorStop;
		public bool quickShow;
		public float delayBeforeQuickShow;
	}
}
