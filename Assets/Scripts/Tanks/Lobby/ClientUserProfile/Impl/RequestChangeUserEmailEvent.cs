using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	[Shared]
	[SerialVersionUID(1457935367814L)]
	public class RequestChangeUserEmailEvent : Event
	{
		public string Email
		{
			get;
			set;
		}

		public RequestChangeUserEmailEvent()
		{
		}

		public RequestChangeUserEmailEvent(string email)
		{
			Email = email;
		}
	}
}
