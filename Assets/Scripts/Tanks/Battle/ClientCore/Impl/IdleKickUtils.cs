using Platform.Library.ClientUnityIntegration.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public static class IdleKickUtils
	{
		public static float CalculateTimeLeft(IdleCounterComponent idleCounter, IdleBeginTimeComponent idleBeginTime, IdleKickConfigComponent config)
		{
			float num = CalculateIdleTime(idleCounter, idleBeginTime.IdleBeginTime);
			float num2 = (float)config.IdleKickTimeSec - num;
			return (!(num2 < 0f)) ? num2 : 0f;
		}

		public static float CalculateIdleTime(IdleCounterComponent idleCounter, Date? idleBeginTime)
		{
			if (!idleBeginTime.HasValue)
			{
				return 0f;
			}
			Date date = ((!idleCounter.SkipBeginTime.HasValue) ? Date.Now : idleCounter.SkipBeginTime.Value);
			float num = date - idleBeginTime.Value;
			return num - (float)idleCounter.SkippedMillis / 1000f;
		}
	}
}
