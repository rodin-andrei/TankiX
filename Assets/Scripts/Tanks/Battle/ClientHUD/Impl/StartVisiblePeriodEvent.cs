using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class StartVisiblePeriodEvent : Event
	{
		public float DurationInSec
		{
			get;
			set;
		}

		public StartVisiblePeriodEvent()
		{
		}

		public StartVisiblePeriodEvent(float durationInSec)
		{
			DurationInSec = durationInSec;
		}
	}
}
