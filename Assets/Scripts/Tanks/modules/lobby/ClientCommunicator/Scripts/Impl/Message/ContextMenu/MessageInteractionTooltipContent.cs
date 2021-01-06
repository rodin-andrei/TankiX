using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;
using UnityEngine;

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
	}
}
