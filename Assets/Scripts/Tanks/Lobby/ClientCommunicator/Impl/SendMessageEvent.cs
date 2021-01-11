using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientCommunicator.Impl
{
	public class SendMessageEvent : Event
	{
		public string Message
		{
			get;
			set;
		}

		public SendMessageEvent(string message)
		{
			Message = message;
		}
	}
}
