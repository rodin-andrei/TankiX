using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientUserProfile.API;

namespace Tanks.Lobby.ClientFriends.API
{
	public class FriendInviteToSquadEvent : Event
	{
		public FriendInviteToSquadEvent(long userId, InteractionSource interactionSource, long sourceId)
		{
		}

	}
}
