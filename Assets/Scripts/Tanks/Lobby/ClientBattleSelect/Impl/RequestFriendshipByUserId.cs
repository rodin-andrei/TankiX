using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientUserProfile.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class RequestFriendshipByUserId : Event
	{
		public RequestFriendshipByUserId(long userId, InteractionSource interactionSource, long sourceId)
		{
		}

	}
}
