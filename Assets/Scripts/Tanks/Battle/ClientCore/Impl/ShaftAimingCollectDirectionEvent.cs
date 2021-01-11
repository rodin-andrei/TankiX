using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class ShaftAimingCollectDirectionEvent : Event
	{
		public TargetingData TargetingData
		{
			get;
			set;
		}

		public ShaftAimingCollectDirectionEvent()
		{
		}

		public ShaftAimingCollectDirectionEvent(TargetingData targetingData)
		{
			TargetingData = targetingData;
		}
	}
}
