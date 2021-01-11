using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientControls.API
{
	[ExecuteInEditMode]
	public class ContentSize : UIBehaviour
	{
		public Vector2 offsets;

		public bool constantWidth;

		private Rect lastCanvasRect;

		private RectTransform canvasRectTransform;

		private RectTransform CanvasRectTransform
		{
			get
			{
				if (canvasRectTransform == null)
				{
					Canvas componentInParent = GetComponentInParent<Canvas>();
					if (componentInParent != null)
					{
						canvasRectTransform = componentInParent.GetComponent<RectTransform>();
					}
				}
				return canvasRectTransform;
			}
		}

		protected override void OnEnable()
		{
			Validate();
		}

		protected override void OnRectTransformDimensionsChange()
		{
			Validate();
		}

		protected override void OnTransformParentChanged()
		{
			canvasRectTransform = null;
		}

		private void Update()
		{
			if (lastCanvasRect != CanvasRectTransform.rect)
			{
				lastCanvasRect = CanvasRectTransform.rect;
				Validate();
			}
		}

		private void Validate()
		{
			RectTransform rectTransform = CanvasRectTransform;
			if (!(rectTransform == null))
			{
				RectTransform component = GetComponent<RectTransform>();
				Vector2 sizeDelta = component.sizeDelta;
				if (!constantWidth)
				{
					sizeDelta.x = rectTransform.rect.width - offsets.x;
				}
				sizeDelta.y = rectTransform.rect.height - offsets.y;
				component.sizeDelta = sizeDelta;
			}
		}
	}
}
