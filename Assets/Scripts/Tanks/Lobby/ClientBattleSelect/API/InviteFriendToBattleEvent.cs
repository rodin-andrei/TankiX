using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	[Shared]
	[SerialVersionUID(635900246805239980L)]
	public class InviteFriendToBattleEvent : Event
	{
		public long BattleId
		{
			get;
			set;
		}

		public InviteFriendToBattleEvent(long battleId)
		{
			BattleId = battleId;
		}
	}
}
