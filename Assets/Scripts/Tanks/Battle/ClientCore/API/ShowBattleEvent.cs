using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientCore.API
{
	public class ShowBattleEvent : Event
	{
		public long BattleId
		{
			get;
			set;
		}

		public ShowBattleEvent()
		{
		}

		public ShowBattleEvent(long battleId)
		{
			BattleId = battleId;
		}
	}
}
