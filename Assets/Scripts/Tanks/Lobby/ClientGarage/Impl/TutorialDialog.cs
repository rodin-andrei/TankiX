using System;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientUserProfile.Impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class TutorialDialog : ECSBehaviour
	{
		private TutorialData tutorialData;

		[SerializeField]
		protected AnimatedText animatedText;

		[SerializeField]
		protected Image backgroundImage;

		[SerializeField]
		protected Button continueButton;

		[SerializeField]
		protected ImageSkin image;

		[SerializeField]
		private TextMeshProUGUI tutorialProgressLabel;

		[SerializeField]
		private GameObject characterBig;

		[SerializeField]
		private GameObject characterSmall;

		private Entity tutorialStep;

		private RectTransform popupPositionRect;

		private TutorialPopupContinue popupContinue;

		[HideInInspector]
		public bool continueOnClick;

		[SerializeField]
		private Material blurMaterial;

		private CanvasGroup canvasGroup;

		[SerializeField]
		private LayerMask highlightLayer;

		private float oldCameraOffset;

		private float newsContainerAlpha;

		private bool highlightHull;

		private bool highlightWeapon;

		private float cameraOffset;

		private Camera highlightCamera;

		private GameObject[] outlines;

		private GameObject outlinePrefab;

		private float showTimer;

		private float minShowTime = 1f;

		public bool InBattleMode
		{
			set
			{
				characterBig.SetActive(!value);
				characterSmall.SetActive(value);
				GetComponent<HorizontalLayoutGroup>().childAlignment = ((!value) ? TextAnchor.MiddleLeft : TextAnchor.UpperLeft);
			}
		}

		public TutorialPopupContinue PopupContinue
		{
			get
			{
				return popupContinue;
			}
			set
			{
				popupContinue = value;
			}
		}

		private void Start()
		{
			if (continueButton != null)
			{
				continueButton.onClick.AddListener(OnContinue);
			}
			blurMaterial = new Material(blurMaterial);
			canvasGroup = GetComponent<CanvasGroup>();
		}

		public void OverrideData(TutorialData data)
		{
			tutorialStep = data.TutorialStep;
			continueOnClick = data.ContinueOnClick;
		}

		public void Init(TutorialData data)
		{
			tutorialData = data;
			tutorialStep = tutorialData.TutorialStep;
			animatedText.ResultText = tutorialData.Message;
			popupPositionRect = tutorialData.PopupPositionRect;
			InBattleMode = data.InBattleMode;
			if (data.StepCountInTutorial > 1)
			{
				tutorialProgressLabel.gameObject.SetActive(true);
				tutorialProgressLabel.text = string.Format("{0}/{1}", data.CurrentStepNumber, data.StepCountInTutorial);
			}
			else
			{
				tutorialProgressLabel.gameObject.SetActive(false);
			}
			continueOnClick = data.ContinueOnClick;
			SetupAdditionalImage(tutorialData);
			InitTankHighlighting(tutorialData);
			if (continueOnClick)
			{
				continueButton.gameObject.SetActive(true);
				continueButton.interactable = true;
				TutorialCanvas.Instance.AddAllowSelectable(continueButton);
			}
			else
			{
				continueButton.gameObject.SetActive(false);
			}
		}

		private void SetupAdditionalImage(TutorialData data)
		{
			if (!string.IsNullOrEmpty(data.ImageUid))
			{
				image.gameObject.SetActive(true);
				image.SpriteUid = data.ImageUid;
			}
			else
			{
				image.gameObject.SetActive(false);
			}
		}

		private void SetupInteractableButton(TutorialData data)
		{
			if (data.InteractableButton != null)
			{
				data.InteractableButton.onClick.AddListener(OnInteractableButtonClick);
				TutorialCanvas.Instance.AddAllowSelectable(data.InteractableButton);
				data.InteractableButton.interactable = true;
			}
		}

		public void Show()
		{
			animatedText.Animate();
			showTimer = 0f;
			base.gameObject.SetActive(true);
			SetupInteractableButton(tutorialData);
			HighlightTank();
		}

		private void OnInteractableButtonClick()
		{
			OnContinue();
		}

		private void OnContinue()
		{
			HighlightingContinue();
			if (tutorialData.InteractableButton != null)
			{
				tutorialData.InteractableButton.onClick.RemoveListener(OnInteractableButtonClick);
			}
			if (popupContinue != null)
			{
				popupContinue();
				popupContinue = null;
			}
		}

		protected void OnDisable()
		{
			popupContinue = null;
		}

		private void Update()
		{
			showTimer += Time.deltaTime;
			if (Input.GetMouseButtonUp(0))
			{
				if (animatedText.TextAnimation)
				{
					animatedText.ForceComplete();
				}
				else if (continueOnClick && showTimer > minShowTime)
				{
					OnContinue();
				}
				return;
			}
			if (InputMapping.Cancel && Environment.CommandLine.Contains("completeTutorialByEsc") && tutorialStep != null)
			{
				ScheduleEvent<CompleteTutorialByEscEvent>(tutorialStep);
				TutorialCanvas.Instance.Hide();
			}
			RectTransform component = GetComponent<RectTransform>();
			if (popupPositionRect != null)
			{
				component.pivot = popupPositionRect.pivot;
				component.position = popupPositionRect.position;
			}
			else
			{
				component.position = new Vector2(2000f, 2000f);
			}
			blurMaterial.SetColor("_TintColor", new Color(0f, 0f, 0f, canvasGroup.alpha * 0.5f));
			blurMaterial.SetFloat("_Size", canvasGroup.alpha * 7f);
		}

		private void InitTankHighlighting(TutorialData data)
		{
			if (data.Type == TutorialType.HighlightTankPart)
			{
				highlightHull = data.HighlightHull;
				highlightWeapon = data.HighlightWeapon;
				cameraOffset = data.CameraOffset;
				outlinePrefab = data.OutlinePrefab;
			}
		}

		public void HighlightTank()
		{
			if (tutorialData.Type != TutorialType.HighlightTankPart)
			{
				return;
			}
			string tag = "TankHull";
			string tag2 = "TankWeapon";
			CameraOffsetBehaviour cameraOffsetBehaviour = UnityEngine.Object.FindObjectOfType<CameraOffsetBehaviour>();
			if (cameraOffsetBehaviour != null)
			{
				oldCameraOffset = cameraOffsetBehaviour.Offset;
				cameraOffsetBehaviour.AnimateOffset(cameraOffset);
				Camera outlineCamera = TutorialCanvas.Instance.OutlineCamera;
				highlightCamera = UnityEngine.Object.Instantiate(outlineCamera);
				highlightCamera.transform.SetParent(cameraOffsetBehaviour.transform, false);
				highlightCamera.transform.localPosition = Vector3.zero;
				highlightCamera.transform.localEulerAngles = Vector3.zero;
				highlightCamera.depth = outlineCamera.depth + 1f;
				highlightCamera.cullingMask = highlightLayer;
				highlightCamera.gameObject.SetActive(true);
				List<GameObject> list = new List<GameObject>();
				if (highlightHull)
				{
					GameObject item = GameObject.FindGameObjectWithTag(tag);
					list.Add(item);
				}
				if (highlightWeapon)
				{
					GameObject item2 = GameObject.FindGameObjectWithTag(tag2);
					list.Add(item2);
				}
				outlines = CreateOutlines(list.ToArray());
			}
			NewsContainerComponent newsContainerComponent = UnityEngine.Object.FindObjectOfType<NewsContainerComponent>();
			if (newsContainerComponent != null)
			{
				newsContainerAlpha = newsContainerComponent.GetComponent<CanvasGroup>().alpha;
				newsContainerComponent.GetComponent<CanvasGroup>().alpha = 0f;
			}
			Invoke("StartOutlineAnimation", 0.6f);
		}

		private GameObject[] CreateOutlines(GameObject[] tankParts)
		{
			List<GameObject> list = new List<GameObject>();
			for (int i = 0; i < tankParts.Length; i++)
			{
				GameObject gameObject = tankParts[i];
				if (!(gameObject == null))
				{
					GameObject gameObject2 = ((!(outlinePrefab == null)) ? UnityEngine.Object.Instantiate(outlinePrefab) : new GameObject("Outline"));
					if (i != 0)
					{
					}
					list.Add(gameObject2);
					gameObject2.layer = gameObject.layer;
					gameObject2.transform.SetParent(gameObject.transform, false);
					gameObject2.transform.localScale = Vector3.one;
					gameObject2.transform.localRotation = Quaternion.identity;
					gameObject2.transform.localPosition = Vector3.zero;
					if (i != 0)
					{
						gameObject2.transform.SetParent(list[i - 1].transform, true);
					}
					gameObject2.SendMessage("Init", gameObject);
				}
			}
			foreach (GameObject item in list)
			{
				if (!(item == null))
				{
					item.SetActive(false);
				}
			}
			return list.ToArray();
		}

		private void StartOutlineAnimation()
		{
			Debug.Log("Start outline animation");
			GameObject[] array = outlines;
			foreach (GameObject gameObject in array)
			{
				if (!(gameObject == null))
				{
					gameObject.SetActive(true);
					gameObject.GetComponent<Animator>().SetBool("visible", true);
				}
			}
		}

		private void HighlightingContinue()
		{
			if (tutorialData.Type != TutorialType.HighlightTankPart)
			{
				return;
			}
			CancelInvoke();
			CameraOffsetBehaviour cameraOffsetBehaviour = UnityEngine.Object.FindObjectOfType<CameraOffsetBehaviour>();
			if (cameraOffsetBehaviour != null)
			{
				cameraOffsetBehaviour.AnimateOffset(oldCameraOffset);
			}
			NewsContainerComponent newsContainerComponent = UnityEngine.Object.FindObjectOfType<NewsContainerComponent>();
			if (newsContainerComponent != null)
			{
				newsContainerComponent.GetComponent<CanvasGroup>().alpha = newsContainerAlpha;
			}
			GameObject[] array = outlines;
			foreach (GameObject gameObject in array)
			{
				if (!(gameObject == null))
				{
					gameObject.SendMessage("Disable");
				}
			}
		}

		public void TutorialHidden()
		{
			if (highlightCamera != null)
			{
				UnityEngine.Object.Destroy(highlightCamera.gameObject);
			}
			if (outlines != null)
			{
				GameObject[] array = outlines;
				foreach (GameObject gameObject in array)
				{
					if (!(gameObject == null))
					{
						UnityEngine.Object.Destroy(gameObject);
					}
				}
				outlines = null;
			}
			Entity entity = tutorialStep;
			tutorialStep = null;
			if (entity != null)
			{
				ScheduleEvent<TutorialStepCompleteEvent>(entity);
			}
		}
	}
}
