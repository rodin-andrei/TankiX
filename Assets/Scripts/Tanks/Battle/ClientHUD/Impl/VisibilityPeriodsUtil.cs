using Tanks.Battle.ClientHUD.API;

namespace Tanks.Battle.ClientHUD.Impl
{
	public static class VisibilityPeriodsUtil
	{
		private const int SPACE_DELAY = 60;

		public static int CalculateTotalPeriodCount(VisibilityPeriodsComponent periods, float totalRoundTimeInSec)
		{
			if (totalRoundTimeInSec <= 0f)
			{
				return 0;
			}
			if (totalRoundTimeInSec <= (float)periods.firstIntervalInSec)
			{
				return 1;
			}
			if (totalRoundTimeInSec <= (float)(periods.firstIntervalInSec + periods.lastIntervalInSec))
			{
				return 2;
			}
			int num = (int)((totalRoundTimeInSec - (float)periods.lastIntervalInSec) / 60f);
			num -= periods.firstIntervalInSec / 60;
			if ((float)(num * 60) == totalRoundTimeInSec - (float)periods.lastIntervalInSec)
			{
				num--;
			}
			return num + 2;
		}

		public static int CalculateCurrentPeriodIndex(VisibilityPeriodsComponent periods, float elapsedRoundTimeInSec, float remainingRoundTimeInSec)
		{
			if (elapsedRoundTimeInSec < (float)periods.firstIntervalInSec)
			{
				return 0;
			}
			if (elapsedRoundTimeInSec < 60f)
			{
				return 1;
			}
			if (remainingRoundTimeInSec <= (float)periods.lastIntervalInSec)
			{
				int num = CalculateTotalPeriodCount(periods, elapsedRoundTimeInSec + remainingRoundTimeInSec);
				return num - 1;
			}
			int num2 = (int)(elapsedRoundTimeInSec / 60f);
			if (elapsedRoundTimeInSec - (float)(num2 * 60) < (float)periods.spaceIntervalInSec)
			{
				return num2;
			}
			return num2 + 1;
		}

		public static float GetCurrentPeriodDelay(VisibilityPeriodsComponent periods, float elapsedRoundTimeInSec, float remainingRoundTimeInSec)
		{
			int num = CalculateTotalPeriodCount(periods, elapsedRoundTimeInSec + remainingRoundTimeInSec);
			int num2 = CalculateCurrentPeriodIndex(periods, elapsedRoundTimeInSec, remainingRoundTimeInSec);
			if (num2 == 0)
			{
				return 0f;
			}
			if (num2 == num - 1)
			{
				return remainingRoundTimeInSec - (float)periods.lastIntervalInSec;
			}
			float num3 = num2 * 60;
			if (elapsedRoundTimeInSec >= num3)
			{
				return 0f;
			}
			return num3 - elapsedRoundTimeInSec;
		}

		public static float GetCurrentPeriodInterval(VisibilityPeriodsComponent periods, float elapsedRoundTimeInSec, float remainingRoundTimeInSec)
		{
			if (remainingRoundTimeInSec <= (float)periods.lastIntervalInSec)
			{
				return remainingRoundTimeInSec;
			}
			if (elapsedRoundTimeInSec < (float)periods.firstIntervalInSec)
			{
				return (float)periods.firstIntervalInSec - elapsedRoundTimeInSec;
			}
			int num = (int)(elapsedRoundTimeInSec / 60f);
			return (float)periods.spaceIntervalInSec - (elapsedRoundTimeInSec - (float)(num * 60));
		}
	}
}
