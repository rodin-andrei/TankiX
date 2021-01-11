using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	[Shared]
	[SerialVersionUID(1452777153835L)]
	public class RequestBattleEvent : Event
	{
		public long BattleId
		{
			get;
			set;
		}

		public RequestBattleEvent()
		{
		}

		public RequestBattleEvent(long battleId)
		{
			BattleId = battleId;
		}
	}
}
