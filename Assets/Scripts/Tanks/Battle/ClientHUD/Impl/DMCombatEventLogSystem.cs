using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Battle.ClientHUD.API;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class DMCombatEventLogSystem : ECSSystem
	{
		public class BattleUserNode : Node
		{
			public BattleUserComponent battleUser;

			public UserInBattleAsTankComponent userInBattleAsTank;

			public UserGroupComponent userGroup;

			public BattleGroupComponent battleGroup;

			public SelfBattleUserComponent selfBattleUser;
		}

		public class CombatEventLogNode : Node
		{
			public CombatLogDMMessagesComponent combatLogDMMessages;

			public CombatEventLogComponent combatEventLog;

			public ActiveCombatLogComponent activeCombatLog;

			public UILogComponent uiLog;
		}

		[OnEventFire]
		public void OnBattleStart(NodeAddedEvent e, CombatEventLogNode combatEventLog, BattleUserNode battleUser, [JoinByBattle] SingleNode<DMComponent> dm)
		{
			string battleStartMessage = combatEventLog.combatLogDMMessages.BattleStartMessage;
			combatEventLog.uiLog.UILog.AddMessage(battleStartMessage);
		}
	}
}
