using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace tanks.modules.lobby.ClientCommunicator.Scripts.Impl.Message.ContextMenu
{
	public class MessageInteractionTooltipContent : InteractionTooltipContent
	{
		[SerializeField]
		private Button _copyMessageButton;

		[SerializeField]
		private Button _copyMessageWithNameButton;

		[SerializeField]
		private Button _copyNameButton;

		[SerializeField]
		private LocalizedField _messageCopiedText;

		private string _messageWithName;

		public override void Init(object data)
		{
			_messageWithName = (string)data;
		}

		protected override void Awake()
		{
			base.Awake();
			_copyMessageButton.onClick.AddListener(AddMessageToBuffer);
			_copyMessageWithNameButton.onClick.AddListener(AddMessageWithNameToBuffer);
			_copyNameButton.onClick.AddListener(AddNameToBuffer);
		}

		public void AddMessageWithNameToBuffer()
		{
			GUIUtility.systemCopyBuffer = _messageWithName;
			ShowResponse(_messageCopiedText);
			Hide();
		}

		public void AddMessageToBuffer()
		{
			int num = _messageWithName.IndexOf(':') + 1;
			int length = _messageWithName.Length - num;
			GUIUtility.systemCopyBuffer = _messageWithName.Substring(num, length);
			ShowResponse(_messageCopiedText);
			Hide();
		}

		public void AddNameToBuffer()
		{
			int num = _messageWithName.IndexOf(':');
			GUIUtility.systemCopyBuffer = ((num <= 0) ? _messageWithName : _messageWithName.Substring(0, num));
			ShowResponse(_messageCopiedText);
			Hide();
		}
	}
}
