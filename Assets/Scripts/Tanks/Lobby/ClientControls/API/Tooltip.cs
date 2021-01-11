using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	public class Tooltip : MonoBehaviour
	{
		public GameObject defaultTooltipContentPrefab;

		public float localPositionXOffset = 10f;

		public float maxWidth = 600f;

		public float marginX = 40f;

		public GameObject background;

		private GameObject tooltipContent;

		private RectTransform tooltipContentRect;

		private RectTransform thisRectTransform;

		private void Awake()
		{
			thisRectTransform = GetComponent<RectTransform>();
			base.gameObject.SetActive(false);
		}

		public void Show(Vector3 canvasLocalPosition, object contentData, GameObject tooltipContentPrefab, bool backgroundActive)
		{
			SetBackground(backgroundActive);
			thisRectTransform.anchoredPosition = canvasLocalPosition;
			thisRectTransform.sizeDelta = new Vector2(maxWidth, thisRectTransform.sizeDelta.y);
			if (tooltipContent != null)
			{
				Object.Destroy(tooltipContent);
			}
			tooltipContent = Object.Instantiate((!(tooltipContentPrefab != null)) ? defaultTooltipContentPrefab : tooltipContentPrefab);
			tooltipContent.transform.SetParent(base.transform, false);
			tooltipContent.GetComponent<ITooltipContent>().Init(contentData);
			tooltipContentRect = tooltipContent.GetComponent<RectTransform>();
			tooltipContent.SetActive(true);
			base.gameObject.SetActive(true);
			Canvas.ForceUpdateCanvases();
			if (tooltipContentRect.rect.width < maxWidth - marginX)
			{
				thisRectTransform.sizeDelta = new Vector2(tooltipContentRect.rect.width, thisRectTransform.sizeDelta.y);
			}
			CanvasScaler componentInParent = GetComponentInParent<CanvasScaler>();
			Vector2 referenceResolution = componentInParent.referenceResolution;
			Vector2 zero = Vector2.zero;
			if (canvasLocalPosition.x + thisRectTransform.rect.width > referenceResolution.x / 2f)
			{
				zero.x = 1f;
			}
			else
			{
				zero.x = 0f;
			}
			if (canvasLocalPosition.y - thisRectTransform.rect.height < (0f - referenceResolution.y) / 2f)
			{
				zero.y = 0f;
			}
			else
			{
				zero.y = 1f;
			}
			thisRectTransform.pivot = zero;
			if (zero.x == 0f && zero.y == 1f)
			{
				canvasLocalPosition += new Vector3(localPositionXOffset, 0f);
			}
			thisRectTransform.anchoredPosition = canvasLocalPosition;
			GetComponent<Animator>().SetBool("show", true);
		}

		private void SetBackground(bool backgroundActive)
		{
			if (background != null)
			{
				background.SetActive(backgroundActive);
				return;
			}
			Debug.LogWarningFormat("Background reference wasn't set in tooltip {1}/{0}", base.gameObject.name, base.transform.parent.gameObject.name);
		}

		public void Hide()
		{
			if (tooltipContent != null)
			{
				CanvasGroup component = tooltipContent.GetComponent<CanvasGroup>();
				if (component != null)
				{
					component.interactable = false;
				}
			}
			Animator component2 = GetComponent<Animator>();
			if (base.gameObject.activeSelf)
			{
				component2.SetBool("show", false);
				Object.Destroy(tooltipContent, component2.GetCurrentAnimatorStateInfo(0).length);
			}
			else
			{
				Object.Destroy(tooltipContent);
			}
		}
	}
}
