using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class ShaftAimingCollectTargetsEvent : Event
	{
		public TargetingData TargetingData
		{
			get;
			set;
		}

		public ShaftAimingCollectTargetsEvent()
		{
		}

		public ShaftAimingCollectTargetsEvent(TargetingData targetingData)
		{
			TargetingData = targetingData;
		}
	}
}
