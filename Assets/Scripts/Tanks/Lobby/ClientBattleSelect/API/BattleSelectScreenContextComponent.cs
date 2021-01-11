using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class BattleSelectScreenContextComponent : Component
	{
		public long? BattleId
		{
			get;
			set;
		}

		public BattleSelectScreenContextComponent()
		{
		}

		public BattleSelectScreenContextComponent(long? battleId)
		{
			BattleId = battleId;
		}
	}
}
