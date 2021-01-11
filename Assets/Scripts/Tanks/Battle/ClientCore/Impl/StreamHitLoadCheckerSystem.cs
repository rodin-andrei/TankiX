using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class StreamHitLoadCheckerSystem : ECSSystem
	{
		public class TankNode : Node
		{
			public TankComponent tank;

			public AssembledTankComponent assembledTank;

			public BattleGroupComponent battleGroup;
		}

		public class StreamHitNode : Node
		{
			public StreamHitComponent streamHit;

			public BattleGroupComponent battleGroup;
		}

		public class LoadedHitNode : Node
		{
			public StreamHitComponent streamHit;

			public StreamHitTargetLoadedComponent streamHitTargetLoaded;

			public BattleGroupComponent battleGroup;
		}

		public class LoadedHitForNRNode : Node
		{
			public StreamHitComponent streamHit;

			public BattleGroupComponent battleGroup;
		}

		[OnEventFire]
		public void TryMarkTargetLoaded(NodeAddedEvent e, TankNode tank, [JoinByBattle] ICollection<StreamHitNode> streamHits)
		{
			foreach (StreamHitNode streamHit in streamHits)
			{
				AddIfMatches(tank, streamHit);
			}
		}

		[OnEventFire]
		public void TryMarkTargetLoaded(NodeAddedEvent e, StreamHitNode streamHit, [JoinByBattle] ICollection<TankNode> tanks)
		{
			foreach (TankNode tank in tanks)
			{
				AddIfMatches(tank, streamHit);
			}
		}

		private void AddIfMatches(TankNode tank, StreamHitNode streamHit)
		{
			StreamHitComponent streamHit2 = streamHit.streamHit;
			if (streamHit2.TankHit != null && streamHit2.TankHit.Entity == tank.Entity)
			{
				streamHit.Entity.AddComponentIfAbsent<StreamHitTargetLoadedComponent>();
			}
		}

		[OnEventComplete]
		public void Remove(NodeRemoveEvent e, LoadedHitForNRNode nr, [JoinSelf] LoadedHitNode streamHit)
		{
			streamHit.Entity.RemoveComponent<StreamHitTargetLoadedComponent>();
		}
	}
}
