using System.Collections.Generic;
using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Battle.ClientGraphics.Impl;
using Tanks.Battle.ClientHUD.API;
using Tanks.Lobby.ClientBattleSelect.API;
using Tanks.Lobby.ClientBattleSelect.Impl;
using Tanks.Lobby.ClientNavigation.API;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class HUDScoreTableSystem : ECSSystem
	{
		public class ScoreTableNode : Node
		{
			public ScoreTableComponent scoreTable;

			public ScreenGroupComponent screenGroup;

			public VisibilityPrerequisitesComponent visibilityPrerequisites;
		}

		public class ScoreTableScrollNode : Node
		{
			public ScreenGroupComponent screenGroup;

			public ScoreTableScrollComponent scoreTableScroll;
		}

		public class TeamScoreTableNode : Node
		{
			public UITeamComponent uiTeam;

			public ScoreTableComponent scoreTable;

			public ScreenGroupComponent screenGroup;

			public ScoreTableGroupComponent scoreTableGroup;

			public VisibilityPrerequisitesComponent visibilityPrerequisites;
		}

		public class ScoreTableRowNode : Node
		{
			public ScoreTableRowComponent scoreTableRow;

			public ScoreTableGroupComponent scoreTableGroup;
		}

		public class ScreenNode : Node
		{
			public ScreenComponent screen;

			public ScreenGroupComponent screenGroup;

			public BattleScreenComponent battleScreen;

			public BattleGroupComponent battleGroup;
		}

		public class BattleUserNode : Node
		{
			public UserGroupComponent userGroup;

			public BattleUserComponent battleUser;
		}

		public class SelfSpectatoUserNode : Node
		{
			public SelfBattleUserComponent selfBattleUser;

			public UserInBattleAsSpectatorComponent userInBattleAsSpectator;
		}

		public class UserScoreTableRowButtonNode : Node
		{
			public ScoreTableRowComponent scoreTableRow;

			public ButtonMappingComponent buttonMapping;

			public UserGroupComponent userGroup;
		}

		private string HIDE_WHEN_EMPTY = "HIDE_WHEN_EMPTY";

		[OnEventFire]
		public void FollowTank(ButtonClickEvent e, UserScoreTableRowButtonNode button, [JoinByUser] BattleUserNode battleUser, [JoinAll] SelfSpectatoUserNode spectator)
		{
			ScheduleEvent<CameraFollowEvent>(battleUser.Entity);
		}

		[OnEventFire]
		public void GroupScoreTable(NodeAddedEvent e, [Combine] ScoreTableNode scoreTable, [Context][JoinByScreen] ScreenNode screen)
		{
			scoreTable.Entity.AddComponent(new BattleGroupComponent(screen.battleGroup.Key));
		}

		[OnEventFire]
		public void GroupScoreTableScroll(NodeAddedEvent e, ScoreTableScrollNode scoreTableScroll, [Context][JoinByScreen] ScreenNode screen)
		{
			scoreTableScroll.Entity.AddComponent(new BattleGroupComponent(screen.battleGroup.Key));
		}

		[OnEventFire]
		public void HideEmptyScoreTable(NodeAddedEvent e, [Combine] TeamScoreTableNode teamScoreTable)
		{
			teamScoreTable.visibilityPrerequisites.AddHidePrerequisite(HIDE_WHEN_EMPTY);
		}

		[OnEventFire]
		public void AddPrerequisite(NodeAddedEvent e, [Combine] ScoreTableRowNode scoreTableRow, [JoinByScoreTable] TeamScoreTableNode scoreTable)
		{
			scoreTable.visibilityPrerequisites.RemoveHidePrerequisite(HIDE_WHEN_EMPTY);
		}

		[OnEventFire]
		public void RemovePrerequisite(NodeRemoveEvent e, [Combine] ScoreTableRowNode scoreTableRow, [JoinByScoreTable] TeamScoreTableNode scoreTable, [JoinByScoreTable] ICollection<ScoreTableRowNode> rows)
		{
			if (rows.Count <= 1)
			{
				scoreTable.visibilityPrerequisites.AddHidePrerequisite(HIDE_WHEN_EMPTY);
			}
		}

		[OnEventFire]
		public void HideEmptyScoreTable(NodeAddedEvent e, ScoreTableNode scoreTable, [Context][JoinByScreen] SingleNode<DMBattleScpectatorScreenComponent> dmSpectatorScreen)
		{
			scoreTable.visibilityPrerequisites.AddHidePrerequisite(HIDE_WHEN_EMPTY);
		}

		[OnEventComplete]
		public void AddPrerequisite(NodeAddedEvent e, [Combine] ScoreTableRowNode scoreTableRow, [JoinByScoreTable] ScoreTableNode scoreTable, [Context][JoinByScreen] SingleNode<DMBattleScpectatorScreenComponent> dmSpectatorScreen)
		{
			scoreTable.visibilityPrerequisites.RemoveHidePrerequisite(HIDE_WHEN_EMPTY);
		}

		[OnEventFire]
		public void RemovePrerequisite(NodeRemoveEvent e, [Combine] ScoreTableRowNode scoreTableRow, [JoinByScoreTable] ScoreTableNode scoreTable, [JoinByScreen] SingleNode<DMBattleScpectatorScreenComponent> dmSpectatorScreen, [JoinByScreen] ScoreTableNode scoreTable2, [JoinByScoreTable] ICollection<ScoreTableRowNode> rows)
		{
			if (rows.Count <= 1)
			{
				scoreTable.visibilityPrerequisites.AddHidePrerequisite(HIDE_WHEN_EMPTY);
			}
		}
	}
}
