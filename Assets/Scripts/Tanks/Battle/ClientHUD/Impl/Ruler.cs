using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	[ExecuteInEditMode]
	public class Ruler : MonoBehaviour
	{
		[SerializeField]
		private Image segment;

		[SerializeField]
		private float spacing = 2f;

		public int segmentsCount = 1;

		public List<Image> segments = new List<Image>();

		private RectTransform rectTransform;

		private float fillAmount;

		public Color Color;

		private Color imageColor;

		public float Spacing
		{
			get
			{
				return spacing;
			}
			set
			{
				spacing = value;
			}
		}

		public RectTransform RectTransform
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

		public float FillAmount
		{
			get
			{
				return fillAmount;
			}
			set
			{
				fillAmount = value;
				float num = 1f / (float)segments.Count;
				for (int i = 0; i < segments.Count; i++)
				{
					float t = Mathf.Clamp01((value - (float)i * num) / num);
					float segmentAnchorMin = GetSegmentAnchorMin(i);
					float segmentAnchorMax = GetSegmentAnchorMax(i);
					segments[i].rectTransform.anchorMax = new Vector2(Mathf.Lerp(segmentAnchorMin, segmentAnchorMax, t), 1f);
				}
			}
		}

		private void Update()
		{
			if (imageColor != Color)
			{
				for (int i = 0; i < segments.Count; i++)
				{
					segments[i].color = (imageColor = Color);
				}
			}
		}

		public void UpdateSegments()
		{
			Clear();
			for (int i = 0; i < segmentsCount; i++)
			{
				Image image = Object.Instantiate(segment, base.transform);
				image.rectTransform.anchorMin = new Vector2(GetSegmentAnchorMin(i), 0f);
				image.rectTransform.anchorMax = new Vector2(GetSegmentAnchorMax(i), 1f);
				RectTransform obj = image.rectTransform;
				Vector2 zero = Vector2.zero;
				image.rectTransform.offsetMax = zero;
				obj.offsetMin = zero;
				image.gameObject.SetActive(true);
				segments.Add(image);
			}
		}

		private float GetSegmentAnchorMin(int i)
		{
			float width = RectTransform.rect.width;
			float num = width / (float)segmentsCount;
			float num2 = spacing / width / 2f;
			return num / width * (float)i + ((i <= 0) ? 0f : num2);
		}

		private float GetSegmentAnchorMax(int i)
		{
			float width = RectTransform.rect.width;
			float num = width / (float)segmentsCount;
			float num2 = spacing / width / 2f;
			return num / width * (float)(i + 1) - ((i >= segmentsCount - 1) ? 0f : num2);
		}

		public void Clear()
		{
			imageColor = Color.clear;
			foreach (Image segment2 in segments)
			{
				if (segment2 != null)
				{
					Object.DestroyImmediate(segment2.gameObject);
				}
			}
			segments.Clear();
		}
	}
}
