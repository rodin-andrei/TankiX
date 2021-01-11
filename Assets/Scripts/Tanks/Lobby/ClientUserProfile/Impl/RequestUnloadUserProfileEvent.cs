using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	[Shared]
	[SerialVersionUID(1451368523887L)]
	public class RequestUnloadUserProfileEvent : Event
	{
		public long UserId
		{
			get;
			set;
		}

		public RequestUnloadUserProfileEvent()
		{
		}

		public RequestUnloadUserProfileEvent(long userId)
		{
			UserId = userId;
		}
	}
}
