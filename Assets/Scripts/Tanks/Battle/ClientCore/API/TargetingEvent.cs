using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientCore.API
{
	public class TargetingEvent : Event
	{
		public TargetingData TargetingData
		{
			get;
			set;
		}

		public TargetingEvent()
		{
		}

		public TargetingEvent(TargetingData targetingData)
		{
			TargetingData = targetingData;
		}

		public TargetingEvent Init(TargetingData targetingData)
		{
			TargetingData = targetingData;
			return this;
		}
	}
}
