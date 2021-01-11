using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class InstanceDestructionSystem : ECSSystem
	{
		public class InstanceDestructionNode : Node
		{
			public InstanceDestructionComponent instanceDestruction;
		}

		[OnEventFire]
		public void OnNodeRemoveEvent(NodeRemoveEvent evt, InstanceDestructionNode instanceDestruction)
		{
			Object.Destroy(instanceDestruction.instanceDestruction.GameObject);
		}
	}
}
