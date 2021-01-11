using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class DisbalanceInfoSystem : ECSSystem
	{
		public class TankNode : Node
		{
			public SelfTankComponent selfTank;
		}

		public class BattleUserNode : Node
		{
			public SelfBattleUserComponent selfBattleUser;

			public UserReadyToBattleComponent userReadyToBattle;
		}

		public class BattleNode : Node
		{
			public BattleModeComponent battleMode;

			public BattleComponent battle;
		}

		public class RoundNode : Node
		{
			public RoundDisbalancedComponent roundDisbalanced;

			public RoundComponent round;
		}

		[OnEventFire]
		public void RoundDisbalanced(NodeAddedEvent e, SingleNode<RoundDisbalancedComponent> roundDisbalanced, SingleNode<DisbalanceStartedWinNotificationComponent> winDisbalance, SingleNode<DisbalanceStartedLooseNotificationComponent> looseDisbalance, SingleNode<DisbalanceInfoComponent> disbalanceInfo, BattleUserNode user, [JoinByTeam] SingleNode<TeamColorComponent> team, [JoinByBattle] BattleNode battle)
		{
			TeamColor loser = roundDisbalanced.component.Loser;
			float time = roundDisbalanced.component.FinishTime.UnityTime - Date.Now.UnityTime;
			disbalanceInfo.component.Timer.Set(time, true);
			if (loser == team.component.TeamColor)
			{
				disbalanceInfo.component.ShowDisbalanceInfo(false, battle.battleMode.BattleMode);
				ActivateEffect(looseDisbalance);
			}
			else
			{
				disbalanceInfo.component.ShowDisbalanceInfo(true, battle.battleMode.BattleMode);
				ActivateEffect(winDisbalance);
			}
		}

		[OnEventFire]
		public void RoundReturnedToBalance(RoundBalanceRestoredEvent e, SingleNode<RoundDisbalancedComponent> roundDisbalanced, [JoinAll] SingleNode<SelfTankComponent> tank, [JoinByTeam] SingleNode<TeamColorComponent> team, [JoinAll] SingleNode<DisbalanceRemovedWinNotificationComponent> winDisbalance, [JoinAll] SingleNode<DisbalanceRemovedLooseNotificationComponent> looseDisbalance)
		{
			TeamColor loser = roundDisbalanced.component.Loser;
			if (loser == team.component.TeamColor)
			{
				ActivateEffect(looseDisbalance);
			}
			else
			{
				ActivateEffect(winDisbalance);
			}
		}

		[OnEventFire]
		public void RoundReturnedToBalance(NodeRemoveEvent e, RoundNode roundDisbalanced, [JoinAll] SingleNode<DisbalanceInfoComponent> disbalanceInfo)
		{
			disbalanceInfo.component.HideDisbalanceInfo();
		}

		private void ActivateEffect(Node node)
		{
			ScheduleEvent<ActivateMultikillNotificationEvent>(node);
		}
	}
}
