using Tanks.Lobby.ClientUserProfile.API;

namespace Tanks.Lobby.ClientGarage.API
{
	public class UserInteractionsData
	{
		public bool canRequestFrendship;
		public bool friendshipRequestWasSend;
		public bool isMuted;
		public bool isReported;
		public long userId;
		public InteractionSource interactionSource;
		public long sourceId;
		public string OtherUserName;
	}
}
