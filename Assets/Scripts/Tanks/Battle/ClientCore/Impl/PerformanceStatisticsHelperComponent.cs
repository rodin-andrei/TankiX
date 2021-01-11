using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class PerformanceStatisticsHelperComponent : Component
	{
		public float startRoundTimeInSec;

		public FramesCollection frames;

		public StatisticCollection tankCount;
	}
}
