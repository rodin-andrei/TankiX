using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientCommunicator.Impl
{
	public class RecievedLobbyChatMessageEvent : Event
	{
		public ChatMessage Message
		{
			get;
			set;
		}

		public RecievedLobbyChatMessageEvent(ChatMessage message)
		{
			Message = message;
		}
	}
}
