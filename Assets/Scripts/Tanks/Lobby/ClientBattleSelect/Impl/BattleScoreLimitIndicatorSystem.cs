using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Lobby.ClientBattleSelect.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class BattleScoreLimitIndicatorSystem : ECSSystem
	{
		public class BattleScoreLimitIndicatorNode : Node
		{
			public BattleScoreLimitIndicatorComponent battleScoreLimitIndicator;

			public BattleGroupComponent battleGroup;
		}

		public class BattleLimitNode : Node
		{
			public BattleGroupComponent battleGroup;

			public ScoreLimitComponent scoreLimit;
		}

		[OnEventFire]
		public void SetScoreLimit(NodeAddedEvent e, BattleScoreLimitIndicatorNode battleScoreLimitIndicator, [Context][JoinByBattle] BattleLimitNode battleLimit)
		{
			battleScoreLimitIndicator.battleScoreLimitIndicator.ScoreLimit = battleLimit.scoreLimit.ScoreLimit;
		}
	}
}
