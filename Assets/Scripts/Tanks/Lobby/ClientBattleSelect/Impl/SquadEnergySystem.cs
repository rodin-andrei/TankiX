using System.Collections.Generic;
using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientBattleSelect.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientUserProfile.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class SquadEnergySystem : ECSSystem
	{
		public class SquadNode : Node
		{
			public SquadComponent squad;

			public SquadGroupComponent squadGroup;
		}

		public class SquadUserNode : Node
		{
			public UserComponent user;

			public UserGroupComponent userGroup;

			public SquadGroupComponent squadGroup;
		}

		public class SquadSelfUserNode : SquadUserNode
		{
			public SelfUserComponent selfUser;
		}

		public class EnergyUserItemNode : Node
		{
			public UserGroupComponent userGroup;

			public EnergyItemComponent energyItem;

			public UserItemComponent userItem;

			public UserItemCounterComponent userItemCounter;
		}

		public class CheckUserEnergyEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
		{
			public bool HaveEnoughtEnergyForEntrance
			{
				get;
				set;
			}
		}

		[OnEventFire]
		public void CheckSquadEnergy(CheckSquadEnergyEvent e, SquadSelfUserNode squadSelfUser, [JoinBySquad] ICollection<SquadUserNode> squadUsers)
		{
			bool flag = true;
			foreach (SquadUserNode squadUser in squadUsers)
			{
				CheckUserEnergyEvent checkUserEnergyEvent = new CheckUserEnergyEvent();
				ScheduleEvent(checkUserEnergyEvent, squadUser);
				flag &= checkUserEnergyEvent.HaveEnoughtEnergyForEntrance;
				Debug.Log(string.Concat("SquadEnergySystem.CheckSquadEnergy ", squadUser.Entity, " ", checkUserEnergyEvent.HaveEnoughtEnergyForEntrance, " ", flag));
			}
			e.HaveEnoughtEnergyForEntrance = flag;
		}

		[OnEventFire]
		public void CheckUserEnergy(CheckUserEnergyEvent e, SquadUserNode user, [JoinByUser] EnergyUserItemNode energy, SquadUserNode userToLeague, [JoinByLeague] SingleNode<LeagueEnergyConfigComponent> league)
		{
			e.HaveEnoughtEnergyForEntrance = energy.userItemCounter.Count >= league.component.Cost;
		}
	}
}
