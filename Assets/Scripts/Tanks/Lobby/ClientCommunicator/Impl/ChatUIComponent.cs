using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientCommunicator.Impl
{
	public class ChatUIComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject inputPanel;

		[SerializeField]
		private Image bottomLineImage;

		[SerializeField]
		private TextMeshProUGUI inputHintText;

		[SerializeField]
		private Color commonNicknameColor;

		[SerializeField]
		private Color commonTextColor;

		[SerializeField]
		private Color redTeamNicknameColor;

		[SerializeField]
		private Color redTeamTextColor;

		[SerializeField]
		private Color blueTeamNicknameColor;

		[SerializeField]
		private Color blueTeamTextColor;

		[SerializeField]
		private PaletteColorField systemMessageColor;

		[SerializeField]
		private GameObject messagesContainer;

		[SerializeField]
		private LayoutElement scrollViewLayoutElement;

		[SerializeField]
		private RectTransform scrollViewRectTransform;

		[SerializeField]
		private RectTransform inputFieldRectTransform;

		[SerializeField]
		private GameObject scrollBarHandle;

		[SerializeField]
		private int maxVisibleMessagesInActiveState = 6;

		[SerializeField]
		private int maxVisibleMessagesInPassiveState = 3;

		private string savedInputMessage = string.Empty;

		public string SavedInputMessage
		{
			get
			{
				return savedInputMessage;
			}
			set
			{
				savedInputMessage = value;
			}
		}

		public Color BottomLineColor
		{
			get
			{
				return bottomLineImage.color;
			}
			set
			{
				if (!(bottomLineImage == null))
				{
					value.a = 0.4f;
					bottomLineImage.color = value;
				}
			}
		}

		public string InputHintText
		{
			get
			{
				return inputHintText.text;
			}
			set
			{
				inputHintText.text = value;
			}
		}

		public Color InputHintColor
		{
			get
			{
				return inputHintText.color;
			}
			set
			{
				inputHintText.color = value;
			}
		}

		public Color InputTextColor
		{
			get
			{
				return inputPanel.GetComponentInChildren<InputField>().textComponent.color;
			}
			set
			{
				inputPanel.GetComponentInChildren<InputField>().textComponent.color = value;
			}
		}

		public bool InputPanelActivity
		{
			get
			{
				return inputPanel.activeSelf;
			}
			set
			{
				inputPanel.SetActive(value);
			}
		}

		public GameObject MessagesContainer
		{
			get
			{
				return messagesContainer;
			}
		}

		public float ScrollViewHeight
		{
			get
			{
				return scrollViewLayoutElement.preferredHeight;
			}
			set
			{
				scrollViewLayoutElement.preferredHeight = value;
			}
		}

		public float ScrollViewPosY
		{
			get
			{
				return scrollViewRectTransform.anchoredPosition.y;
			}
		}

		public bool ScrollBarActivity
		{
			get
			{
				return scrollBarHandle.activeSelf;
			}
			set
			{
				scrollBarHandle.SetActive(value);
			}
		}

		public Color CommonNicknameColor
		{
			get
			{
				return commonNicknameColor;
			}
		}

		public Color CommonTextColor
		{
			get
			{
				return commonTextColor;
			}
		}

		public Color RedTeamNicknameColor
		{
			get
			{
				return redTeamNicknameColor;
			}
		}

		public Color RedTeamTextColor
		{
			get
			{
				return redTeamTextColor;
			}
		}

		public Color BlueTeamNicknameColor
		{
			get
			{
				return blueTeamNicknameColor;
			}
		}

		public Color BlueTeamTextColor
		{
			get
			{
				return blueTeamTextColor;
			}
		}

		public Color SystemMessageColor
		{
			get
			{
				return systemMessageColor;
			}
		}

		public int MaxVisibleMessagesInActiveState
		{
			get
			{
				return maxVisibleMessagesInActiveState;
			}
		}

		public int MaxVisibleMessagesInPassiveState
		{
			get
			{
				return maxVisibleMessagesInPassiveState;
			}
		}

		public void SetHintSize(bool teamMode)
		{
			inputHintText.rectTransform.sizeDelta = new Vector2((!teamMode) ? 56f : 86f, inputHintText.rectTransform.sizeDelta.y);
			inputFieldRectTransform.sizeDelta = new Vector2((!teamMode) ? 340f : 310f, inputHintText.rectTransform.sizeDelta.y);
		}
	}
}
