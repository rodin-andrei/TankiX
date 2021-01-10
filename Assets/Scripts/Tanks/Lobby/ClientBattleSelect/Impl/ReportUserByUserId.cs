using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientUserProfile.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class ReportUserByUserId : Event
	{
		public ReportUserByUserId(long userId, InteractionSource interactionSource, long sourceId)
		{
		}

	}
}
