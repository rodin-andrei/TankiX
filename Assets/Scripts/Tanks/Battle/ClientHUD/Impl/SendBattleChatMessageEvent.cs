using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Battle.ClientHUD.Impl
{
	[Shared]
	[SerialVersionUID(1450949620229L)]
	public class SendBattleChatMessageEvent : Event
	{
		public string Message
		{
			get;
			set;
		}

		public SendBattleChatMessageEvent()
		{
		}

		public SendBattleChatMessageEvent(string message)
		{
			Message = message;
		}
	}
}
