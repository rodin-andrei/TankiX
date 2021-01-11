using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Tanks.Lobby.ClientUserProfile.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	[Shared]
	[SerialVersionUID(1506939447770L)]
	public class RequestFriendshipByUserId : Event
	{
		public long UserId
		{
			get;
			set;
		}

		public InteractionSource InteractionSource
		{
			get;
			set;
		}

		public long SourceId
		{
			get;
			set;
		}

		public RequestFriendshipByUserId(long userId, InteractionSource interactionSource, long sourceId)
		{
			UserId = userId;
			InteractionSource = interactionSource;
			SourceId = sourceId;
		}
	}
}
