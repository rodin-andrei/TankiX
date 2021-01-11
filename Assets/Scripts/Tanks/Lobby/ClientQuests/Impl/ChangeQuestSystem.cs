using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientQuests.API;
using Tanks.Lobby.ClientUserProfile.API;

namespace Tanks.Lobby.ClientQuests.Impl
{
	public class ChangeQuestSystem : ECSSystem
	{
		[Not(typeof(TakenBonusComponent))]
		public class QuestBonusNode : Node
		{
			public UserGroupComponent userGroup;

			public QuestExchangeBonusComponent questExchangeBonus;
		}

		public class UserNode : Node
		{
			public UserComponent user;

			public SelfUserComponent selfUser;

			public UserGroupComponent userGroup;

			public LeagueGroupComponent leagueGroup;
		}

		public class QuestNode : Node
		{
			public QuestComponent quest;

			public QuestRarityComponent questRarity;

			public UserGroupComponent userGroup;
		}

		[OnEventFire]
		public void ChangeQuests(ChangeQuestEvent e, QuestNode quest, [JoinByUser] QuestBonusNode bonus)
		{
			NewEvent<UseBonusEvent>().Attach(bonus).Attach(quest).Schedule();
		}
	}
}
