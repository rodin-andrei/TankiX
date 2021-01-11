using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class SearchResultComponent : Component
	{
		private List<BattleEntry> pinnedBattles = new List<BattleEntry>();

		private List<PersonalBattleInfo> personalInfos = new List<PersonalBattleInfo>();

		public List<BattleEntry> PinnedBattles
		{
			get
			{
				return pinnedBattles;
			}
			set
			{
				pinnedBattles = value;
			}
		}

		public List<PersonalBattleInfo> PersonalInfos
		{
			get
			{
				return personalInfos;
			}
			set
			{
				personalInfos = value;
			}
		}

		public int BattlesCount
		{
			get;
			set;
		}
	}
}
