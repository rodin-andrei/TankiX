using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientCore.API
{
	public class CollectTargetsEvent : Event
	{
		public TargetingData TargetingData
		{
			get;
			set;
		}

		public CollectTargetsEvent()
		{
		}

		public CollectTargetsEvent(TargetingData targetingData)
		{
			TargetingData = targetingData;
		}

		public CollectTargetsEvent Init(TargetingData targetingData)
		{
			TargetingData = targetingData;
			return this;
		}
	}
}
