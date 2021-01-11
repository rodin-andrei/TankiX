using System;
using UnityEngine;
using UnityEngine.UI;

namespace tanks.modules.lobby.ClientControls.Scripts.API
{
	public class ComplexFillProgressBar : MonoBehaviour
	{
		private const string INVALID_PROGRESS_FORMAT = "Incorrect ProgressValue {0}. The available ProgressValue's range is [0,1]";

		[SerializeField]
		private Image maskImage;

		private RectTransform maskImageRectTransform;

		private RectTransform parentRectTransform;

		private float val;

		public float ProgressValue
		{
			get
			{
				return val;
			}
			set
			{
				if (value < 0f || value > 1f)
				{
					throw new ArgumentException(string.Format("Incorrect ProgressValue {0}. The available ProgressValue's range is [0,1]", value));
				}
				val = value;
				Vector2 offsetMax = maskImageRectTransform.offsetMax;
				offsetMax.x = (val - 1f) * parentRectTransform.rect.width;
				maskImageRectTransform.offsetMax = offsetMax;
			}
		}

		public void Awake()
		{
			if (maskImage == null)
			{
				Mask componentInChildren = base.gameObject.GetComponentInChildren<Mask>();
				maskImage = componentInChildren.gameObject.GetComponent<Image>();
			}
			maskImageRectTransform = maskImage.GetComponent<RectTransform>();
			parentRectTransform = maskImage.transform.parent.GetComponent<RectTransform>();
		}
	}
}
