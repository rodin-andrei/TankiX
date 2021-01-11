using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class ShaftAimingTargetCollectorSystem : ECSSystem
	{
		public class targetCollectorNode : Node
		{
			public TargetCollectorComponent targetCollector;
		}

		[OnEventFire]
		public void CollectTargetsOnDirections(ShaftAimingCollectTargetsEvent evt, targetCollectorNode targetCollectorNode)
		{
			targetCollectorNode.targetCollector.Collect(evt.TargetingData, LayerMasks.VISUAL_TARGETING);
		}
	}
}
