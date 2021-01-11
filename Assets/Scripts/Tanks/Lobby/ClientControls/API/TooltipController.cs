using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class TooltipController : MonoBehaviour
	{
		private static TooltipController instance;

		public Tooltip tooltip;

		public float delayBeforeTooltipShowAfterCursorStop = 0.1f;

		public float maxDelayForQuickShowAfterCursorStop = 0.2f;

		[HideInInspector]
		public bool quickShow;

		public float delayBeforeQuickShow = 0.1f;

		private bool tooltipIsShow;

		private float afterHideTimer;

		public static TooltipController Instance
		{
			get
			{
				return instance;
			}
		}

		private void Awake()
		{
			instance = this;
		}

		public void ShowTooltip(Vector3 position, object data, GameObject tooltipContentPrefab = null, bool backgroundActive = true)
		{
			tooltipIsShow = true;
			Vector2 localPoint;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), position, null, out localPoint))
			{
				tooltip.Show(localPoint, data, tooltipContentPrefab, backgroundActive);
			}
		}

		public void HideTooltip()
		{
			afterHideTimer = 0f;
			quickShow = true;
			tooltipIsShow = false;
			tooltip.Hide();
		}

		private void Update()
		{
			if (!tooltipIsShow && quickShow)
			{
				afterHideTimer += Time.deltaTime;
				if (afterHideTimer > maxDelayForQuickShowAfterCursorStop)
				{
					quickShow = false;
				}
			}
		}
	}
}
