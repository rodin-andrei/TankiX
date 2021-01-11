using Tanks.Battle.ClientCore.Impl;

namespace Tanks.Battle.ClientCore.API
{
	public class MoveToTargetNode : BehaviourTreeNode
	{
		public TankAutopilotControllerSystem.AutopilotTankNode tank;

		private float LastMove
		{
			get;
			set;
		}

		private float LastTurn
		{
			get;
			set;
		}

		public override void Start()
		{
		}

		public override TreeNodeState Running()
		{
			return TreeNodeState.RUNNING;
		}

		public override void End()
		{
		}
	}
}
