using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Lobby.ClientBattleSelect.API;
using Tanks.Lobby.ClientNavigation.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class JoinToScreenBattleSystem : ECSSystem
	{
		public class ScreenNode : Node
		{
			public BattleGroupComponent battleGroup;

			public ScreenGroupComponent screenGroup;

			public ScreenComponent screen;
		}

		public class BattleNode : Node
		{
			public BattleComponent battle;

			public BattleGroupComponent battleGroup;
		}

		[Not(typeof(BattleGroupComponent))]
		public class JoinToScreenBattleNode : Node
		{
			public JoinToScreenBattleComponent joinToScreenBattle;

			public ScreenGroupComponent screenGroup;
		}

		[OnEventFire]
		public void Join(NodeAddedEvent e, [Combine] JoinToScreenBattleNode joinToScreenBattle, [Context][JoinByScreen] ScreenNode screen, [JoinByBattle] BattleNode battle)
		{
			battle.battleGroup.Attach(joinToScreenBattle.Entity);
		}
	}
}
