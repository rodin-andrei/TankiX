using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Lobby.ClientBattleSelect.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class DMScoreTableSystem : ECSSystem
	{
		public class RoundUserNode : Node
		{
			public RoundUserStatisticsComponent roundUserStatistics;

			public UserGroupComponent userGroup;

			public BattleGroupComponent battleGroup;
		}

		public class DMScoreTableNode : Node
		{
			public ScoreTableComponent scoreTable;

			public BattleGroupComponent battleGroup;

			public ScoreTableGroupComponent scoreTableGroup;

			public DMScoreTableComponent dmScoreTable;

			public ScoreTableUserRowIndicatorsComponent scoreTableUserRowIndicators;
		}

		public class InitedScoreTable : DMScoreTableNode
		{
			public ScoreTableRowsCacheInitedComponent scoreTableRowsCacheInited;
		}

		public class DMBattleNode : Node
		{
			public BattleGroupComponent battleGroup;

			public UserLimitComponent userLimit;

			public DMComponent dm;
		}

		[OnEventFire]
		public void InitRowsCache(NodeAddedEvent e, [Combine] DMScoreTableNode scoreTable, [Context][JoinByBattle] DMBattleNode battle)
		{
			scoreTable.scoreTable.InitRowsCache(battle.userLimit.UserLimit, scoreTable.scoreTableUserRowIndicators.indicators);
			scoreTable.Entity.AddComponent<ScoreTableRowsCacheInitedComponent>();
		}

		[OnEventFire]
		public void AddUser(NodeAddedEvent e, [Combine] InitedScoreTable scoreTable, [Context][JoinByBattle][Combine] RoundUserNode roundUser)
		{
			ScoreTableRowComponent scoreTableRowComponent = scoreTable.scoreTable.AddRow();
			Entity entity = scoreTableRowComponent.GetComponent<EntityBehaviour>().Entity;
			entity.AddComponent(new ScoreTableGroupComponent(scoreTable.scoreTableGroup.Key));
			entity.AddComponent(new UserGroupComponent(roundUser.userGroup.Key));
			foreach (ScoreTableRowIndicator value in scoreTableRowComponent.indicators.Values)
			{
				EntityBehaviour component = value.GetComponent<EntityBehaviour>();
				if (!(component == null))
				{
					component.BuildEntity(entity);
				}
			}
		}
	}
}
