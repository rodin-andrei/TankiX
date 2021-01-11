using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Lobby.ClientBattleSelect.API;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class BattleDetailsDMSystem : ECSSystem
	{
		public class BattleDMNode : Node
		{
			public DMComponent dm;

			public BattleComponent battle;

			public SelectedListItemComponent selectedListItem;

			public BattleGroupComponent battleGroup;

			public UserLimitComponent userLimit;
		}

		public class ScreenNode : Node
		{
			public BattleSelectScreenComponent battleSelectScreen;

			public BattleGroupComponent battleGroup;
		}

		[OnEventFire]
		public void ShowDMInfoPanel(NodeAddedEvent e, BattleDMNode battleDm, [Context][JoinByBattle] ScreenNode screen)
		{
			screen.battleSelectScreen.DMInfoPanel.gameObject.SetActive(true);
		}

		[OnEventFire]
		public void HideDMInfoPanel(NodeRemoveEvent e, BattleDMNode battleDm, ScreenNode screen)
		{
			screen.battleSelectScreen.DMInfoPanel.gameObject.SetActive(false);
		}
	}
}
