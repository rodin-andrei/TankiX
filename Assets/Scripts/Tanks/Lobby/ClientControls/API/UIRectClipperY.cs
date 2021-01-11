using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	[ExecuteInEditMode]
	public class UIRectClipperY : MonoBehaviour, IClipper
	{
		[HideInInspector]
		[SerializeField]
		private float fromY;

		[HideInInspector]
		[SerializeField]
		private float toY = 1f;

		private RectTransform rectTransform;

		private List<MaskableGraphic> maskableCache = new List<MaskableGraphic>();

		private readonly List<Canvas> canvases = new List<Canvas>();

		private readonly Vector3[] worldCorners = new Vector3[4];

		private readonly Vector3[] canvasCorners = new Vector3[4];

		public float FromY
		{
			get
			{
				return fromY;
			}
			set
			{
				fromY = value;
				PerformClipping();
			}
		}

		public float ToY
		{
			get
			{
				return toY;
			}
			set
			{
				toY = value;
				PerformClipping();
			}
		}

		private RectTransform RectTransform
		{
			get
			{
				if (rectTransform == null)
				{
					rectTransform = GetComponent<RectTransform>();
				}
				return rectTransform;
			}
		}

		private void OnEnable()
		{
			ClipperRegistry.Register(this);
		}

		private void OnDisable()
		{
			ClipperRegistry.Unregister(this);
		}

		public void PerformClipping()
		{
			Rect canvasRect = GetCanvasRect();
			float height = canvasRect.height;
			canvasRect.yMin = Mathf.Max(canvasRect.yMin, canvasRect.yMin + FromY * height);
			canvasRect.yMax = Mathf.Min(canvasRect.yMax, canvasRect.yMax - (1f - ToY) * height);
			CanvasRenderer component = GetComponent<CanvasRenderer>();
			if (component != null)
			{
				component.EnableRectClipping(canvasRect);
			}
			maskableCache.Clear();
			GetComponentsInChildren(maskableCache);
			foreach (MaskableGraphic item in maskableCache)
			{
				item.SetClipRect(canvasRect, true);
			}
		}

		public Rect GetCanvasRect()
		{
			Canvas canvas = null;
			base.gameObject.GetComponentsInParent(false, canvases);
			if (canvases.Count > 0)
			{
				canvas = canvases[canvases.Count - 1];
				canvases.Clear();
				RectTransform.GetWorldCorners(worldCorners);
				Transform transform = canvas.transform;
				for (int i = 0; i < 4; i++)
				{
					canvasCorners[i] = transform.InverseTransformPoint(worldCorners[i]);
				}
				return new Rect(canvasCorners[0].x, canvasCorners[0].y, canvasCorners[2].x - canvasCorners[0].x, canvasCorners[2].y - canvasCorners[0].y);
			}
			return default(Rect);
		}
	}
}
