using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class JoinToSelectedBattleSystem : ECSSystem
	{
		public class SelectedBattleNode : Node
		{
			public BattleComponent battle;

			public BattleGroupComponent battleGroup;

			public SelectedListItemComponent selectedListItem;

			public BattleConfiguredComponent battleConfigured;
		}

		public class JoinToSelectedBattleNode : Node
		{
			public JoinToSelectedBattleComponent joinToSelectedBattle;
		}

		public class JoinedSelectedBattleNode : Node
		{
			public JoinToSelectedBattleComponent joinToSelectedBattle;

			public BattleGroupComponent battleGroup;
		}

		[OnEventFire]
		public void Join(NodeAddedEvent e, SelectedBattleNode selectedBattle, [Context][Combine] JoinToSelectedBattleNode joinToSelectedBattle)
		{
			selectedBattle.battleGroup.Attach(joinToSelectedBattle.Entity);
		}

		[OnEventComplete]
		public void BreakJoin(NodeRemoveEvent e, SelectedBattleNode selectedBattle, [JoinByBattle][Combine] JoinedSelectedBattleNode joinedToSelectedBattle)
		{
			selectedBattle.battleGroup.Detach(joinedToSelectedBattle.Entity);
		}
	}
}
