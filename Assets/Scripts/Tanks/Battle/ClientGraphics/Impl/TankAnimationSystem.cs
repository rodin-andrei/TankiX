using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TankAnimationSystem : ECSSystem
	{
		public class AnimationNode : Node
		{
			public AnimationComponent animation;

			public TankGroupComponent tankGroup;
		}

		public class ActivatedTankNode : Node
		{
			public AssembledTankActivatedStateComponent assembledTankActivatedState;

			public TankGroupComponent tankGroup;
		}

		public class PreparedAnimationNode : Node
		{
			public AnimationComponent animation;

			public AnimationPreparedComponent animationPrepared;
		}

		private static readonly string INACTIVE_STATE_TAG = "Inaction";

		[OnEventFire]
		public void SetNewAnimationAsNotPrepared(NodeAddedEvent evt, [Combine] AnimationNode animationNode, [Context][JoinByTank] ActivatedTankNode tank)
		{
			animationNode.Entity.AddComponent<AnimationPreparedComponent>();
		}
	}
}
