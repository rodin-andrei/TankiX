using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class FramesCollection
	{
		private readonly int maxFrameDurationInMs;

		private readonly int measuringIntervalInSec;

		private StatisticCollection frames;

		private float intervalStartTime = float.NaN;

		private StatisticCollection intervalFrames;

		private int hugeFrameCount;

		private int minAverageForInterval = int.MaxValue;

		private int maxAverageForInterval = int.MinValue;

		[Inject]
		public static UnityTime UnityTime
		{
			get;
			set;
		}

		public int Moda
		{
			get
			{
				return frames.Moda;
			}
		}

		public int Average
		{
			get
			{
				return (int)Mathf.Round(frames.Average);
			}
		}

		public int StandartDevation
		{
			get
			{
				return (int)frames.StandartDeviation;
			}
		}

		public int HugeFrameCount
		{
			get
			{
				return hugeFrameCount;
			}
		}

		public int MinAverageForInterval
		{
			get
			{
				ProcessCurrentInterval();
				return minAverageForInterval;
			}
		}

		public int MaxAverageForInterval
		{
			get
			{
				ProcessCurrentInterval();
				return maxAverageForInterval;
			}
		}

		public FramesCollection(int maxFrameDurationInMs, int measuringIntervalInSec)
		{
			this.maxFrameDurationInMs = maxFrameDurationInMs;
			this.measuringIntervalInSec = measuringIntervalInSec;
			frames = new StatisticCollection(maxFrameDurationInMs);
			intervalFrames = new StatisticCollection(maxFrameDurationInMs);
		}

		public void AddFrame(int durationInMs)
		{
			if (FrameIsHuge(durationInMs))
			{
				hugeFrameCount++;
				return;
			}
			frames.Add(durationInMs);
			if (CurrentIntervalNotExist())
			{
				StartNewInterval();
			}
			if (CurrentIntervalCompleted())
			{
				ProcessCurrentInterval();
				StartNewInterval();
			}
			AddFrameToInterval(durationInMs);
		}

		private void AddFrameToInterval(int durationInMs)
		{
			intervalFrames.Add(durationInMs);
		}

		private bool FrameIsHuge(int durationInMs)
		{
			return durationInMs >= maxFrameDurationInMs;
		}

		private void ProcessCurrentInterval()
		{
			if (intervalFrames.TotalCount != 0)
			{
				if (intervalFrames.Average < (float)minAverageForInterval)
				{
					minAverageForInterval = (int)intervalFrames.Average;
				}
				if (intervalFrames.Average > (float)maxAverageForInterval)
				{
					maxAverageForInterval = (int)intervalFrames.Average;
				}
			}
		}

		private bool CurrentIntervalCompleted()
		{
			return UnityTime.realtimeSinceStartup - intervalStartTime >= (float)measuringIntervalInSec;
		}

		private bool CurrentIntervalNotExist()
		{
			return float.IsNaN(intervalStartTime);
		}

		private void StartNewInterval()
		{
			intervalStartTime = UnityTime.realtimeSinceStartup;
			intervalFrames = new StatisticCollection(maxFrameDurationInMs);
		}
	}
}
