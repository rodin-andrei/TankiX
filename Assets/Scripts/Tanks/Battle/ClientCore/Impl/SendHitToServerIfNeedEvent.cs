using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class SendHitToServerIfNeedEvent : Event
	{
		public TargetingData TargetingData
		{
			get;
			set;
		}

		public SendHitToServerIfNeedEvent()
		{
		}

		public SendHitToServerIfNeedEvent(TargetingData targetingData)
		{
			TargetingData = targetingData;
		}
	}
}
