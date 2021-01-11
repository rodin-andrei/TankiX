using Tanks.Lobby.ClientEntrance.API;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public static class DailyBonusUtil
	{
		public static DailyBonusCycleComponent GetCurrentCycle()
		{
			long cycleNumber = SelfUserComponent.SelfUser.GetComponent<UserDailyBonusCycleComponent>().CycleNumber;
			return (cycleNumber <= 0) ? ((DailyBonusCycleComponent)DailyBonusCommonConfigComponent.DailyBonusConfig.GetComponent<DailyBonusFirstCycleComponent>()) : ((DailyBonusCycleComponent)DailyBonusCommonConfigComponent.DailyBonusConfig.GetComponent<DailyBonusEndlessCycleComponent>());
		}

		public static int GetLastIndexInZone(DailyBonusCycleComponent dailyBonusCycleComponent, int zoneIndex)
		{
			return dailyBonusCycleComponent.Zones[zoneIndex];
		}

		public static int GetFirstIndexInZone(DailyBonusCycleComponent dailyBonusCycleComponent, int zoneIndex)
		{
			return (zoneIndex != 0) ? (dailyBonusCycleComponent.Zones[zoneIndex - 1] + 1) : 0;
		}

		public static int GetCurrentZoneIndex()
		{
			return (int)SelfUserComponent.SelfUser.GetComponent<UserDailyBonusZoneComponent>().ZoneNumber;
		}
	}
}
