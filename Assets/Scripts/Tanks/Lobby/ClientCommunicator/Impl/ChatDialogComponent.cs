using Platform.Library.ClientUnityIntegration.API;
using System;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Tanks.Lobby.ClientCommunicator.Impl
{
	public class ChatDialogComponent : BehaviourComponent
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
		}

		[Serializable]
		public class ChannelRoot
		{
			[SerializeField]
			private Transform parent;
			[SerializeField]
			private ChatDialogComponent.ChatSectionType chatSection;
		}

		public enum ChatSectionType
		{
			Common = 0,
			Group = 1,
			Personal = 2,
		}

		[SerializeField]
		private CanvasGroup maximazedCanvasGroup;
		[SerializeField]
		private CanvasGroup minimazedCanvasGroup;
		[SerializeField]
		private GameObject minimizeButton;
		[SerializeField]
		private GameObject maximizeButton;
		[SerializeField]
		private int baseBottomHeight;
		[SerializeField]
		private int bottomHeightLineAdditional;
		[SerializeField]
		private RectTransform bottom;
		[SerializeField]
		private TMP_InputField inputField;
		[SerializeField]
		private GameObject inputFieldInactivePlaceholder;
		[SerializeField]
		private GameObject sendButton;
		[SerializeField]
		private TMP_Text lastMessage;
		[SerializeField]
		private TMP_Text unreadCounter;
		[SerializeField]
		private GameObject unreadBadge;
		[SerializeField]
		private ScrollRect messagesScroll;
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
		[SerializeField]
		private Transform messagesRoot;
		[SerializeField]
		private List<ChatDialogComponent.ChatUISettings> uiSettings;
		[SerializeField]
		private List<ChatDialogComponent.ChannelRoot> channelRoots;
	}
}
