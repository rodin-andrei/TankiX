using System.Collections.Generic;
using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientNavigation.API;
using Tanks.Lobby.ClientUserProfile.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class EnergyBonusSystem : ECSSystem
	{
		[Not(typeof(TakenBonusComponent))]
		public class EnergyBonusNode : Node
		{
			public UserGroupComponent userGroup;

			public EnergyBonusComponent energyBonus;
		}

		public class UserNode : Node
		{
			public UserComponent user;

			public SelfUserComponent selfUser;

			public UserGroupComponent userGroup;

			public LeagueGroupComponent leagueGroup;
		}

		public class EnergyUserItemNode : Node
		{
			public UserGroupComponent userGroup;

			public EnergyItemComponent energyItem;

			public UserItemComponent userItem;

			public UserItemCounterComponent userItemCounter;
		}

		public class LeagueNode : Node
		{
			public LeagueComponent league;

			public LeagueGroupComponent leagueGroup;

			public LeagueEnergyConfigComponent leagueEnergyConfig;
		}

		[OnEventFire]
		public void CountAvailableBonusEnergy(TryUseBonusEvent e, EnergyBonusNode bonus1, [JoinByUser] UserNode user, [JoinByLeague] LeagueNode league, EnergyBonusNode bonus2, [JoinByUser] EnergyUserItemNode energy)
		{
			e.AvailableBonusEnergy = league.leagueEnergyConfig.Capacity - energy.userItemCounter.Count;
		}

		[OnEventComplete]
		public void TryUserBonus(TryUseBonusEvent e, EnergyBonusNode bonus, [JoinAll] SingleNode<Dialogs60Component> dialogs)
		{
			if (e.AvailableBonusEnergy < bonus.energyBonus.Bonus)
			{
				if (e.AvailableBonusEnergy <= 0)
				{
					FullEnergyDialog fullEnergyDialog = dialogs.component.Get<FullEnergyDialog>();
					fullEnergyDialog.Show();
					return;
				}
				CantUseAllEnergyBonusDialog cantUseAllEnergyBonusDialog = dialogs.component.Get<CantUseAllEnergyBonusDialog>();
				cantUseAllEnergyBonusDialog.SetEnergyCount(e.AvailableBonusEnergy);
				List<Animator> animators = new List<Animator>();
				cantUseAllEnergyBonusDialog.Show(animators);
			}
			else
			{
				ScheduleEvent<UseBonusEvent>(bonus);
			}
		}

		[OnEventFire]
		public void UsePartOfEnergyBonus(DialogConfirmEvent e, SingleNode<CantUseAllEnergyBonusDialog> dialog, [JoinAll] UserNode user, [JoinByUser] EnergyBonusNode bonus)
		{
			ScheduleEvent<UseBonusEvent>(bonus);
		}
	}
}
