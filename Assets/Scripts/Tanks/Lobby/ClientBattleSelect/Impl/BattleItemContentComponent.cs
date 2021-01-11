using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class BattleItemContentComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
	{
		private const string GEAR_SPEED_MULTIPLIER = "GearTransparencySign";

		private const string GEAR_TRANSPARENCY_STATE_NAME = "GearTransparency";

		private const string SHOW_PREVIEW_NAME = "ShowPreview";

		private const string HIGHLIGHTED_NAME = "Highlighted";

		private const string NORMAL_NAME = "Normal";

		private const float GEAR_REVERSE_MULTIPLIER = -0.66f;

		private const int GEAR_TRANSPARENCY_STATE_LAYER_INDEX = 1;

		[SerializeField]
		private Text battleModeTextField;

		[SerializeField]
		private Text debugInfoTextField;

		[SerializeField]
		private Text timeTextField;

		[SerializeField]
		private Text userCountTextField;

		[SerializeField]
		private Text scoreTextField;

		[SerializeField]
		private RawImage previewImage;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private Material grayscaleMaterial;

		[SerializeField]
		private RectTransform timeTransform;

		[SerializeField]
		private RectTransform scoreTransform;

		[SerializeField]
		private RectTransform scoreTankIcon;

		[SerializeField]
		private RectTransform scoreFlagIcon;

		private bool entranceLocked;

		private int showPreviewID;

		private int gearTransparencyStateID;

		private int gearSpeedMultiplierID;

		private int showGearID;

		private int highlightedID;

		private int normalID;

		public bool EntranceLocked
		{
			get
			{
				return entranceLocked;
			}
			set
			{
				entranceLocked = value;
				if (value)
				{
					previewImage.material = grayscaleMaterial;
					SendMessageUpwards("OnItemDisabled", SendMessageOptions.RequireReceiver);
				}
				else
				{
					previewImage.material = null;
					SendMessageUpwards("OnItemEnabled", SendMessageOptions.RequireReceiver);
				}
			}
		}

		protected override void Awake()
		{
			showPreviewID = Animator.StringToHash("ShowPreview");
			normalID = Animator.StringToHash("Normal");
			highlightedID = Animator.StringToHash("Highlighted");
			gearSpeedMultiplierID = Animator.StringToHash("GearTransparencySign");
			gearTransparencyStateID = Animator.StringToHash("GearTransparency");
		}

		public void SetModeField(string text)
		{
			battleModeTextField.text = text;
		}

		public void SetDebugField(string text)
		{
			debugInfoTextField.text = text;
		}

		public void SetTimeField(string text)
		{
			timeTextField.text = text;
		}

		public void SetUserCountField(string text)
		{
			userCountTextField.text = text;
		}

		public void SetScoreField(string text)
		{
			scoreTextField.text = text;
		}

		public void SetPreview(Texture2D image)
		{
			previewImage.texture = image;
			animator.SetTrigger(showPreviewID);
			animator.SetFloat(gearSpeedMultiplierID, -0.66f);
			float normalizedTime = Mathf.Clamp01(animator.GetCurrentAnimatorStateInfo(1).normalizedTime);
			animator.Play(gearTransparencyStateID, 1, normalizedTime);
			OnRectTransformDimensionsChange();
		}

		public void HideTime()
		{
			scoreTransform.anchoredPosition = timeTransform.anchoredPosition;
			timeTransform.gameObject.SetActive(false);
		}

		public void HideScore()
		{
			scoreTransform.gameObject.SetActive(false);
		}

		public void SetFlagAsScoreIcon()
		{
			scoreTankIcon.gameObject.SetActive(false);
			scoreFlagIcon.gameObject.SetActive(true);
		}

		protected override void OnRectTransformDimensionsChange()
		{
			if (!(previewImage.texture == null))
			{
				Rect rect = new Rect(0f, 0f, previewImage.texture.width, previewImage.texture.height);
				float num = rect.width / rect.height;
				RectTransform rectTransform = (RectTransform)base.transform;
				RectTransform rectTransform2 = (RectTransform)previewImage.transform;
				float num2 = rectTransform.rect.width / rectTransform.rect.height;
				rectTransform2.sizeDelta = ((!(num2 < num)) ? new Vector2(rectTransform.rect.width, rectTransform.rect.width / num) : new Vector2(num * rectTransform.rect.height, rectTransform.rect.height));
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			animator.SetTrigger(highlightedID);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			animator.SetTrigger(normalID);
		}
	}
}
