using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientCommunicator.Impl
{
	public class RecievedLobbyChatMessageEvent : Event
	{
		public RecievedLobbyChatMessageEvent(ChatMessage message)
		{
		}

	}
}
