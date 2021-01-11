using System;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	[ExecuteInEditMode]
	public class DependentSize : ResizeListener, ILayoutElement
	{
		public bool useMinWidth;

		public bool usePreferredWidth;

		public bool useFlexibleWidth;

		public bool useMinHeight;

		public bool usePreferredHeight;

		public bool useFlexibleHeight;

		private float calculatedMinWidth;

		private float calculatedMinHeight;

		private float calculatedPreferredWidth;

		private float calculatedPreferredHeight;

		private float calculatedFlexibleWidth;

		private float calculatedFlexibleHeight;

		private RectTransform layoutSource;

		public float minWidth
		{
			get
			{
				return calculatedMinWidth;
			}
		}

		public float preferredWidth
		{
			get
			{
				return calculatedPreferredWidth;
			}
		}

		public float flexibleWidth
		{
			get
			{
				return calculatedFlexibleWidth;
			}
		}

		public float minHeight
		{
			get
			{
				return calculatedMinHeight;
			}
		}

		public float preferredHeight
		{
			get
			{
				return calculatedPreferredHeight;
			}
		}

		public float flexibleHeight
		{
			get
			{
				return calculatedFlexibleHeight;
			}
		}

		public int layoutPriority
		{
			get
			{
				return 0;
			}
		}

		public override void OnResize(RectTransform source)
		{
			layoutSource = source;
			CalculateLayoutInputHorizontal();
			CalculateLayoutInputVertical();
			LayoutRebuilder.MarkLayoutForRebuild(GetComponent<RectTransform>());
		}

		public void CalculateLayoutInputHorizontal()
		{
			calculatedMinWidth = GetValue(useMinWidth, () => LayoutUtility.GetMinWidth(layoutSource));
			calculatedFlexibleWidth = GetValue(useFlexibleWidth, () => LayoutUtility.GetFlexibleWidth(layoutSource));
			calculatedPreferredWidth = GetValue(usePreferredWidth, () => LayoutUtility.GetPreferredWidth(layoutSource));
		}

		public void CalculateLayoutInputVertical()
		{
			calculatedMinHeight = GetValue(useMinHeight, () => LayoutUtility.GetMinHeight(layoutSource));
			calculatedFlexibleHeight = GetValue(useFlexibleHeight, () => LayoutUtility.GetFlexibleHeight(layoutSource));
			calculatedPreferredHeight = GetValue(usePreferredHeight, () => LayoutUtility.GetPreferredHeight(layoutSource));
		}

		private float GetValue(bool use, Func<float> value)
		{
			return (!use || !(layoutSource != null)) ? (-1f) : value();
		}
	}
}
