using System;
using System.Collections.Generic;
using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientCommunicator.Impl
{
	public class ChatDialogComponent : BehaviourComponent, MainScreenComponent.IPanelShowListener
	{
		[Serializable]
		public class ChatUISettings
		{
			[SerializeField]
			private ChatType type;

			[SerializeField]
			private Color color;

			[SerializeField]
			private string iconName;

			[SerializeField]
			private LocalizedField defaultName;

			[SerializeField]
			private EntityBehaviour chatTabPrefab;

			public ChatType Type
			{
				get
				{
					return type;
				}
			}

			public Color Color
			{
				get
				{
					return color;
				}
			}

			public string IconName
			{
				get
				{
					return iconName;
				}
			}

			public LocalizedField DefaultName
			{
				get
				{
					return defaultName;
				}
			}

			public EntityBehaviour ChatTabPrefab
			{
				get
				{
					return chatTabPrefab;
				}
			}
		}

		public enum ChatSectionType
		{
			Common,
			Group,
			Personal
		}

		[Serializable]
		public class ChannelRoot
		{
			[SerializeField]
			private Transform parent;

			[SerializeField]
			private ChatSectionType chatSection;

			public Transform Parent
			{
				get
				{
					return parent;
				}
			}

			public ChatSectionType ChatSection
			{
				get
				{
					return chatSection;
				}
			}
		}

		[SerializeField]
		private CanvasGroup maximazedCanvasGroup;

		[SerializeField]
		private CanvasGroup minimazedCanvasGroup;

		[SerializeField]
		private GameObject minimizeButton;

		[SerializeField]
		private GameObject maximizeButton;

		private bool hidden;

		private int MAX_MESSAGE_LENGTH = 200;

		[SerializeField]
		private int baseBottomHeight = 60;

		[SerializeField]
		private int bottomHeightLineAdditional = 24;

		[SerializeField]
		private RectTransform bottom;

		[SerializeField]
		private TMP_InputField inputField;

		[SerializeField]
		private GameObject inputFieldInactivePlaceholder;

		[SerializeField]
		private GameObject sendButton;

		private int caretCrutch;

		private int MAX_NEW_LINES = 5;

		private int forceNewLine;

		[SerializeField]
		private TMP_Text lastMessage;

		[SerializeField]
		private TMP_Text unreadCounter;

		private int unread;

		[SerializeField]
		private GameObject unreadBadge;

		[SerializeField]
		private ScrollRect messagesScroll;

		private int waitMessagesScroll;

		private bool autoScroll = true;

		private float lastScrollPos;

		private const int MAX_MESSAGES = 50;

		[SerializeField]
		private ImageSkin activePersonalChannelIcon;

		[SerializeField]
		private ImageSkin activeNotPersonalChannelIcon;

		[SerializeField]
		private GameObject chatIcon;

		[SerializeField]
		private GameObject userIcon;

		[SerializeField]
		private TMP_Text activeChannelName;

		[SerializeField]
		private MessageObject firstSelfMessagePrefab;

		[SerializeField]
		private MessageObject secondSelfMessagePrefab;

		[SerializeField]
		private MessageObject firstOpponentMessagePrefab;

		[SerializeField]
		private MessageObject secondOpponentMessagePrefab;

		private List<MessageObject> messages = new List<MessageObject>();

		[SerializeField]
		private Transform messagesRoot;

		[SerializeField]
		private List<ChatUISettings> uiSettings;

		[SerializeField]
		private List<ChannelRoot> channelRoots;

		public int Unread
		{
			get
			{
				return unread;
			}
			set
			{
				unread = ((value > 0) ? value : 0);
				unreadBadge.SetActive(unread > 0);
				if (unread > 99)
				{
					unreadCounter.text = "99+";
				}
				else
				{
					unreadCounter.text = unread.ToString();
				}
			}
		}

		public bool IsHidden()
		{
			return hidden;
		}

		public bool IsOpen()
		{
			return maximazedCanvasGroup.interactable;
		}

		public void Minimize(bool memory = false)
		{
			if (!hidden)
			{
				ForceMinimize();
			}
		}

		public void ForceMinimize()
		{
			hidden = false;
			maximizeButton.SetActive(true);
			minimizeButton.SetActive(false);
			maximazedCanvasGroup.alpha = 0f;
			maximazedCanvasGroup.blocksRaycasts = false;
			maximazedCanvasGroup.interactable = false;
			minimazedCanvasGroup.alpha = 1f;
			GetComponent<Animator>().SetBool("show", false);
		}

		public void Maximaze()
		{
			hidden = false;
			minimazedCanvasGroup.alpha = 0f;
			minimazedCanvasGroup.blocksRaycasts = false;
			minimazedCanvasGroup.interactable = false;
			maximazedCanvasGroup.alpha = 1f;
			maximazedCanvasGroup.blocksRaycasts = true;
			maximazedCanvasGroup.interactable = true;
			maximizeButton.SetActive(false);
			minimizeButton.SetActive(true);
			ScrollToEnd();
			GetComponent<Animator>().SetBool("show", true);
			ECSBehaviour.EngineService.Engine.ScheduleEvent(new ChatMaximazedEvent(), new EntityStub());
		}

		public void Hide()
		{
			hidden = true;
			maximizeButton.SetActive(false);
			minimizeButton.SetActive(false);
			minimazedCanvasGroup.alpha = 0f;
			minimazedCanvasGroup.blocksRaycasts = false;
			minimazedCanvasGroup.interactable = false;
			maximazedCanvasGroup.alpha = 0f;
			maximazedCanvasGroup.blocksRaycasts = false;
			maximazedCanvasGroup.interactable = false;
			GetComponent<Animator>().SetBool("show", false);
		}

		public void Show()
		{
			if (MainScreenComponent.Instance.isActiveAndEnabled && !TutorialCanvas.Instance.IsShow)
			{
				OnPanelShow(MainScreenComponent.Instance.GetCurrentPanel());
			}
		}

		public void OnPanelShow(MainScreenComponent.MainScreens screen)
		{
			switch (screen)
			{
			case MainScreenComponent.MainScreens.MatchLobby:
			case MainScreenComponent.MainScreens.MatchSearching:
			case MainScreenComponent.MainScreens.Cards:
			case MainScreenComponent.MainScreens.StarterPack:
			case MainScreenComponent.MainScreens.TankRent:
				Hide();
				break;
			default:
				ForceMinimize();
				break;
			}
		}

		public void OnHide()
		{
		}

		public void OnShow()
		{
		}

		private void CheckInput()
		{
			if (!hidden && IsOpen() && Input.GetKeyDown(KeyCode.Escape))
			{
				Minimize();
			}
			if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
			{
				if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
				{
					lastMessage.gameObject.SetActive(false);
				}
				else if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus))
				{
					lastMessage.gameObject.SetActive(true);
				}
			}
		}

		public void OnInputFieldSubmit(string text)
		{
			if (!Input.GetKey(KeyCode.Return))
			{
				return;
			}
			if (Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
			{
				if (forceNewLine < MAX_NEW_LINES && inputField.text.Length < MAX_MESSAGE_LENGTH)
				{
					inputField.text += "\n";
					forceNewLine++;
					caretCrutch = 3;
				}
				else
				{
					caretCrutch = 2;
				}
			}
			else
			{
				Send();
			}
		}

		public void Send()
		{
			SendMessage(inputField.text);
			inputField.ActivateInputField();
			inputField.text = string.Empty;
			ResetBottomSize();
			forceNewLine = 0;
			autoScroll = true;
		}

		public void ValidateInput(string text)
		{
			caretCrutch = 1;
		}

		public void SetInputInteractable(bool interactable)
		{
			sendButton.SetActive(interactable);
			inputField.gameObject.SetActive(interactable);
			inputFieldInactivePlaceholder.SetActive(!interactable);
		}

		private void UpdateCaretAndSize()
		{
			if (caretCrutch > 0)
			{
				caretCrutch--;
				if (caretCrutch == 1)
				{
					inputField.ActivateInputField();
					inputField.MoveTextEnd(false);
				}
				if (caretCrutch == 0)
				{
					bottom.sizeDelta = new Vector2(bottom.sizeDelta.x, Math.Max(baseBottomHeight, inputField.textComponent.preferredHeight + 36f));
				}
			}
		}

		private void ResetBottomSize()
		{
			bottom.sizeDelta = new Vector2(bottom.sizeDelta.x, baseBottomHeight);
		}

		private void SetBadgeOnStart()
		{
			unreadBadge.SetActive(unread > 0);
		}

		public void AddUIMessage(ChatMessage message)
		{
			if (messages.Count == 50)
			{
				UnityEngine.Object.DestroyImmediate(messages[0].gameObject);
				messages.RemoveAt(0);
				if (!messages[0].First)
				{
					ChatMessage message2 = messages[0].Message;
					UnityEngine.Object.DestroyImmediate(messages[0].gameObject);
					messages[0] = CreateMessage(message2, true);
					messages[0].transform.SetAsFirstSibling();
				}
			}
			bool first = messages.Count == 0 || message.System || messages.Last().Message.Author != message.Author || messages.Last().Message.ChatId != message.ChatId;
			messages.Add(CreateMessage(message, first));
		}

		private MessageObject CreateMessage(ChatMessage message, bool first)
		{
			MessageObject original = secondOpponentMessagePrefab;
			if (message.Self)
			{
				original = ((!first) ? secondSelfMessagePrefab : firstSelfMessagePrefab);
			}
			else if (first)
			{
				original = firstOpponentMessagePrefab;
			}
			ScrollToEnd();
			MessageObject messageObject = UnityEngine.Object.Instantiate(original);
			messageObject.Set(message, GetColorByChatType);
			messageObject.transform.SetParent(messagesRoot, false);
			return messageObject;
		}

		public void SetLastMessage(ChatMessage message)
		{
			lastMessage.text = message.GetEllipsis(GetColorByChatType);
		}

		public new void SendMessage(string message)
		{
			ECSBehaviour.EngineService.Engine.ScheduleEvent(new SendMessageEvent(message), new EntityStub());
		}

		public void Reset()
		{
			autoScroll = true;
			lastScrollPos = 0f;
			waitMessagesScroll = 3;
		}

		public void OnScrollRectChanged(Vector2 pos)
		{
			if (autoScroll)
			{
				if (waitMessagesScroll == 0 && (double)pos.y > 0.1 && lastScrollPos != pos.y && (double)pos.y <= 0.99)
				{
					autoScroll = false;
				}
			}
			else if ((double)pos.y <= 0.1)
			{
				autoScroll = true;
			}
			lastScrollPos = pos.y;
		}

		private void ScrollToEnd()
		{
			if (autoScroll)
			{
				waitMessagesScroll = 3;
			}
		}

		private void ScrollWaitUpdate()
		{
			if (waitMessagesScroll > 0)
			{
				waitMessagesScroll--;
				if (waitMessagesScroll == 0)
				{
					messagesRoot.GetComponent<CanvasGroup>().alpha = 1f;
					messagesScroll.normalizedPosition = Vector2.zero;
				}
			}
		}

		public ChatSectionType GetSection(ChatType type)
		{
			switch (type)
			{
			case ChatType.PERSONAL:
				return ChatSectionType.Personal;
			case ChatType.SQUAD:
			case ChatType.CUSTOMGROUP:
				return ChatSectionType.Group;
			default:
				return ChatSectionType.Common;
			}
		}

		private Color GetColorByChatType(ChatType chatType)
		{
			return uiSettings.Find((ChatUISettings x) => x.Type == chatType).Color;
		}

		public EntityBehaviour CreateChatChannel(ChatType type)
		{
			ChatSectionType sectionType = GetSection(type);
			Transform parent = channelRoots.Find((ChannelRoot x) => x.ChatSection == sectionType).Parent;
			ChatUISettings chatUISettings = uiSettings.Find((ChatUISettings x) => x.Type == type);
			EntityBehaviour entityBehaviour = UnityEngine.Object.Instantiate(chatUISettings.ChatTabPrefab);
			entityBehaviour.transform.SetParent(parent, false);
			ChatChannelUIComponent component = entityBehaviour.gameObject.GetComponent<ChatChannelUIComponent>();
			component.Tab = entityBehaviour.gameObject;
			if (type != ChatType.PERSONAL)
			{
				component.SetIcon(chatUISettings.IconName);
			}
			component.Name = chatUISettings.DefaultName.Value;
			return entityBehaviour;
		}

		public void ChangeName(GameObject tab, ChatType type, string name)
		{
			ChatUISettings chatUISettings = uiSettings.Find((ChatUISettings x) => x.Type == type);
			ChatChannelUIComponent component = tab.GetComponent<ChatChannelUIComponent>();
			activeNotPersonalChannelIcon.SpriteUid = chatUISettings.IconName;
			if (string.IsNullOrEmpty(name))
			{
				name = chatUISettings.DefaultName.Value;
			}
			string text2 = (component.Name = string.Format("<color=#{0}>{1}</color>", chatUISettings.Color.ToHexString(), name));
		}

		public void SetHeader(string spriteUid, string header, bool personal = false)
		{
			activePersonalChannelIcon.SpriteUid = spriteUid;
			activeNotPersonalChannelIcon.SpriteUid = spriteUid;
			activeChannelName.text = header;
			chatIcon.SetActive(!personal);
			userIcon.SetActive(personal);
		}

		public void SelectChannel(ChatType type, List<ChatMessage> messages)
		{
			messagesRoot.GetComponent<CanvasGroup>().alpha = 0f;
			Reset();
			inputField.text = string.Empty;
			forceNewLine = 0;
			ResetBottomSize();
			foreach (MessageObject message in this.messages)
			{
				UnityEngine.Object.DestroyImmediate(message.gameObject);
			}
			this.messages = new List<MessageObject>();
			int num = messages.Count - 50;
			if (num < 0)
			{
				num = 0;
			}
			for (int i = num; i < messages.Count; i++)
			{
				AddUIMessage(messages[i]);
			}
		}

		private void Awake()
		{
			SetBadgeOnStart();
		}

		private void Update()
		{
			if (IsOpen())
			{
				Carousel.BlockAxisAtCurrentTick();
			}
		}

		public void LateUpdate()
		{
			ScrollWaitUpdate();
			UpdateCaretAndSize();
			CheckInput();
		}
	}
}
