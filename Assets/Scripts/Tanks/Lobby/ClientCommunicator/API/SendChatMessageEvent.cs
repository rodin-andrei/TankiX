using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientCommunicator.API
{
	[Shared]
	[SerialVersionUID(1446035600297L)]
	public class SendChatMessageEvent : Event
	{
		public string Message
		{
			get;
			set;
		}

		public SendChatMessageEvent()
		{
		}

		public SendChatMessageEvent(string message)
		{
			Message = message;
		}
	}
}
