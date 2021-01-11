using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class TutorialCanvas : MonoBehaviour
	{
		public static TutorialCanvas Instance;

		[SerializeField]
		public GameObject overlay;

		[SerializeField]
		private TutorialIntroDialog introDialog;

		[SerializeField]
		public TutorialDialog dialog;

		[SerializeField]
		public TutorialArrow arrow;

		[SerializeField]
		private GameObject tutorialScreen;

		[SerializeField]
		private GameObject skipTutorialButton;

		private List<Selectable> disabledSelectables = new List<Selectable>();

		private List<Selectable> allowSelectables = new List<Selectable>();

		private List<GameObject> additionalMaskRects = new List<GameObject>();

		private bool isShow;

		private bool isPaused;

		private bool allowCancelHandler = true;

		private List<GameObject> maskedObjects = new List<GameObject>();

		[SerializeField]
		private CanvasGroup backgroundCanvasGroup;

		private Material backgroundMaterial;

		[SerializeField]
		private Canvas overlayCanvas;

		[SerializeField]
		private Camera outlineCamera;

		[SerializeField]
		private Camera tutorialCamera;

		public GameObject SkipTutorialButton
		{
			get
			{
				return skipTutorialButton;
			}
		}

		public bool IsShow
		{
			get
			{
				return isShow;
			}
		}

		public bool IsPaused
		{
			get
			{
				return isPaused;
			}
		}

		public bool AllowCancelHandler
		{
			get
			{
				return allowCancelHandler;
			}
		}

		public Camera OutlineCamera
		{
			get
			{
				return outlineCamera;
			}
		}

		private void Awake()
		{
			Image component = backgroundCanvasGroup.GetComponent<Image>();
			backgroundMaterial = new Material(component.material);
			component.material = backgroundMaterial;
		}

		private void Start()
		{
			Instance = this;
		}

		private void CheckForOverlayCamera()
		{
			if (overlayCanvas.worldCamera == null)
			{
				overlayCanvas.worldCamera = GameObject.Find("UICamera").GetComponent<Camera>();
				overlayCanvas.planeDistance = 10f;
			}
		}

		public void ShowIntroDialog(TutorialData data, bool canSkipTutorial)
		{
			tutorialCamera.gameObject.SetActive(true);
			BlockInteractable();
			CheckForOverlayCamera();
			overlay.SetActive(true);
			introDialog.Show(data.TutorialStep, canSkipTutorial);
			GetComponent<Animator>().SetBool("show", true);
			overlayCanvas.GetComponent<Animator>().SetBool("show", true);
			isShow = true;
			tutorialScreen.SetActive(true);
			MainScreenComponent.Instance.ToggleNews(false);
		}

		public void Show(TutorialData data, bool useOverlay, GameObject[] highlightedRects = null, RectTransform arrowPositionRect = null)
		{
			tutorialCamera.gameObject.SetActive(true);
			CheckForOverlayCamera();
			dialog.Init(data);
			allowCancelHandler = false;
			overlay.SetActive(useOverlay);
			CreateMasks(highlightedRects);
			BlockInteractable();
			if (arrowPositionRect != null)
			{
				SetArrowPosition(arrowPositionRect);
			}
			Invoke("DelayedShow", data.ShowDelay);
			tutorialScreen.SetActive(true);
		}

		private void DelayedShow()
		{
			MainScreenComponent.Instance.ToggleNews(false);
			BlockInteractable();
			CancelInvoke();
			GetComponent<Animator>().SetBool("show", true);
			overlayCanvas.GetComponent<Animator>().SetBool("show", true);
			TutorialDialog tutorialDialog = dialog;
			tutorialDialog.PopupContinue = (TutorialPopupContinue)Delegate.Combine(tutorialDialog.PopupContinue, new TutorialPopupContinue(Hide));
			dialog.Show();
			isShow = true;
			tutorialScreen.SetActive(true);
		}

		private void SetArrowPosition(RectTransform arrowPositionRect)
		{
			arrow.Setup(arrowPositionRect);
			arrow.gameObject.SetActive(true);
		}

		public void Hide()
		{
			CancelInvoke();
			if (GetComponent<Animator>().GetBool("show"))
			{
				GetComponent<Animator>().SetBool("show", false);
				overlayCanvas.GetComponent<Animator>().SetBool("show", false);
			}
			else
			{
				isShow = true;
				Hidden();
			}
		}

		private void Hidden()
		{
			if (isShow)
			{
				allowCancelHandler = true;
				isShow = false;
				UnblockInteractable();
				ClearMasks();
				tutorialCamera.gameObject.SetActive(false);
				allowSelectables.Clear();
				arrow.gameObject.SetActive(false);
				dialog.gameObject.SetActive(false);
				tutorialScreen.SetActive(false);
				skipTutorialButton.SetActive(false);
				MainScreenComponent.Instance.ToggleNews(true);
				dialog.TutorialHidden();
				introDialog.TutorialHidden();
			}
		}

		public void BlockInteractable()
		{
			Selectable[] array = UnityEngine.Object.FindObjectsOfType<Selectable>();
			Selectable[] array2 = array;
			foreach (Selectable selectable in array2)
			{
				if (selectable.interactable && !allowSelectables.Contains(selectable) && selectable.gameObject != skipTutorialButton)
				{
					disabledSelectables.Add(selectable);
					selectable.interactable = false;
				}
			}
		}

		public void UnblockInteractable()
		{
			foreach (Selectable disabledSelectable in disabledSelectables)
			{
				if (disabledSelectable != null)
				{
					disabledSelectable.interactable = true;
				}
			}
			disabledSelectables.Clear();
		}

		public void AddAllowSelectable(Selectable selectable)
		{
			if (!allowSelectables.Contains(selectable))
			{
				allowSelectables.Add(selectable);
			}
		}

		private void CreateMasks(GameObject[] rects)
		{
			ClearMasks();
			if (rects != null)
			{
				foreach (GameObject rect in rects)
				{
					CreateMask(rect);
				}
			}
			foreach (GameObject additionalMaskRect in additionalMaskRects)
			{
				CreateMask(additionalMaskRect);
			}
			additionalMaskRects.Clear();
		}

		private void CreateMask(GameObject rect)
		{
			Canvas component = rect.GetComponent<Canvas>();
			if (component == null)
			{
				component = rect.gameObject.AddComponent<Canvas>();
				component.overrideSorting = true;
				component.sortingLayerName = "Overlay";
				component.sortingOrder = 30;
				rect.gameObject.AddComponent<GraphicRaycaster>();
				maskedObjects.Add(rect.gameObject);
			}
		}

		private void ClearMasks()
		{
			foreach (GameObject maskedObject in maskedObjects)
			{
				if (maskedObject != null)
				{
					GraphicRaycaster component = maskedObject.GetComponent<GraphicRaycaster>();
					if (component != null)
					{
						UnityEngine.Object.Destroy(component);
					}
					Canvas component2 = maskedObject.GetComponent<Canvas>();
					if (component2 != null)
					{
						UnityEngine.Object.Destroy(component2);
					}
				}
			}
			Canvas.ForceUpdateCanvases();
			maskedObjects.Clear();
		}

		public void ShowOverlay()
		{
			GetComponent<Animator>().SetBool("show", false);
		}

		private void Update()
		{
			CheckForOverlayCamera();
			backgroundMaterial.SetColor("_TintColor", new Color(0.078f, 0.078f, 0.078f, backgroundCanvasGroup.alpha * 0.8f));
			backgroundMaterial.SetFloat("_Size", backgroundCanvasGroup.alpha * 6f);
		}

		public void AddAdditionalMaskRect(GameObject maskRect)
		{
			additionalMaskRects.Add(maskRect);
		}

		public void SetupActivePopup(TutorialData data)
		{
			dialog.OverrideData(data);
		}

		public void CardsNotificationsEnabled(bool value)
		{
			GetComponent<Animator>().SetBool("showOverlay", !value);
		}

		public void Pause()
		{
			Debug.Log("Pause");
			ToggleMask(false);
			isPaused = true;
			GetComponent<Animator>().SetBool("pause", true);
			overlayCanvas.GetComponent<Animator>().SetBool("pause", true);
		}

		public void Continue()
		{
			if (isPaused)
			{
				Debug.Log("Continue");
				ToggleMask(true);
				GetComponent<Animator>().SetBool("pause", false);
				overlayCanvas.GetComponent<Animator>().SetBool("pause", false);
			}
		}

		private void ToggleMask(bool value)
		{
			foreach (GameObject maskedObject in maskedObjects)
			{
				if (maskedObject != null)
				{
					Canvas component = maskedObject.GetComponent<Canvas>();
					if (component != null)
					{
						component.enabled = value;
					}
				}
			}
		}
	}
}
