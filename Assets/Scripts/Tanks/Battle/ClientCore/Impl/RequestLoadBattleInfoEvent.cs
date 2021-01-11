using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Battle.ClientCore.Impl
{
	[Shared]
	[SerialVersionUID(635890723433891050L)]
	public class RequestLoadBattleInfoEvent : Event
	{
		public long BattleId
		{
			get;
			private set;
		}

		public RequestLoadBattleInfoEvent(long battleId)
		{
			BattleId = battleId;
		}
	}
}
