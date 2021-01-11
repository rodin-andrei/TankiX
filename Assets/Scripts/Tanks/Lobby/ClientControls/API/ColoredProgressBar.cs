using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	[ExecuteInEditMode]
	public class ColoredProgressBar : MonoBehaviour
	{
		[Range(0f, 1f)]
		[SerializeField]
		private float initialProgress;

		[Range(0f, 1f)]
		[SerializeField]
		private float coloredProgress;

		[SerializeField]
		private RectTransform initialMask;

		[SerializeField]
		private RectTransform initialFiller;

		[SerializeField]
		private RectTransform coloredMask;

		[SerializeField]
		private RectTransform coloredInnerMask;

		[SerializeField]
		private RectTransform coloredFiller;

		private Image initialMaskImage;

		private Image coloredMaskImage;

		private Image coloredInnerMaskImage;

		public float InitialProgress
		{
			get
			{
				return initialProgress;
			}
			set
			{
				initialProgress = value;
				initialMaskImage.fillAmount = initialProgress;
			}
		}

		public float ColoredProgress
		{
			get
			{
				return coloredProgress;
			}
			set
			{
				coloredProgress = value;
				coloredMaskImage.fillAmount = coloredProgress;
				coloredInnerMaskImage.fillAmount = 1f - initialProgress;
			}
		}

		private void Awake()
		{
			initialMaskImage = initialMask.GetComponent<Image>();
			coloredMaskImage = coloredMask.GetComponent<Image>();
			coloredInnerMaskImage = coloredInnerMask.GetComponent<Image>();
		}

		private void Reset()
		{
			CreateIfAbsent(ref initialMask, base.transform, "InitialMask");
			if (initialMask.GetComponent<Mask>() == null)
			{
				Mask mask = initialMask.gameObject.AddComponent<Mask>();
				mask.showMaskGraphic = false;
			}
			Image image = initialMask.GetComponent<Image>();
			if (image == null)
			{
				image = initialMask.gameObject.AddComponent<Image>();
			}
			image.fillMethod = Image.FillMethod.Horizontal;
			image.fillOrigin = 0;
			image.type = Image.Type.Filled;
			Stretch(initialMask);
			CreateIfAbsent(ref initialFiller, initialMask, "Filler");
			if (initialFiller.GetComponent<Image>() == null)
			{
				initialFiller.gameObject.AddComponent<Image>();
			}
			Stretch(initialFiller);
			CreateIfAbsent(ref coloredMask, base.transform, "ColoredMask");
			if (coloredMask.GetComponent<Mask>() == null)
			{
				Mask mask2 = coloredMask.gameObject.AddComponent<Mask>();
				mask2.showMaskGraphic = false;
			}
			image = coloredMask.GetComponent<Image>();
			if (image == null)
			{
				image = coloredMask.gameObject.AddComponent<Image>();
			}
			image.fillMethod = Image.FillMethod.Horizontal;
			image.fillOrigin = 0;
			image.type = Image.Type.Filled;
			Stretch(coloredMask);
			CreateIfAbsent(ref coloredInnerMask, coloredMask, "InnerMask");
			if (coloredInnerMask.GetComponent<Mask>() == null)
			{
				Mask mask3 = coloredInnerMask.gameObject.AddComponent<Mask>();
				mask3.showMaskGraphic = false;
			}
			image = coloredInnerMask.GetComponent<Image>();
			if (image == null)
			{
				image = coloredInnerMask.gameObject.AddComponent<Image>();
			}
			image.fillMethod = Image.FillMethod.Horizontal;
			image.fillOrigin = 1;
			image.type = Image.Type.Filled;
			Stretch(coloredInnerMask);
			CreateIfAbsent(ref coloredFiller, coloredInnerMask, "Filler");
			if (coloredFiller.GetComponent<Image>() == null)
			{
				coloredFiller.gameObject.AddComponent<Image>().color = Color.green;
			}
			Stretch(coloredFiller);
		}

		private void CreateIfAbsent(ref RectTransform child, Transform parent, string name)
		{
			if (child == null)
			{
				child = parent.Find(name) as RectTransform;
				if (child == null)
				{
					child = new GameObject(name).AddComponent<RectTransform>();
					child.SetParent(parent, false);
				}
			}
		}

		private void Stretch(RectTransform child)
		{
			child.anchorMax = new Vector2(1f, 1f);
			child.anchorMin = new Vector2(0f, 0f);
			child.anchoredPosition = Vector2.zero;
			child.sizeDelta = Vector2.zero;
		}
	}
}
