using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientGraphics.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class ExplosiveMassEffectSystem : ECSSystem
	{
		public class ExplosiveMassEffectNode : Node
		{
			public ExplosiveMassEffectComponent explosiveMassEffect;

			public EffectComponent effect;
		}

		public class TankNode : Node
		{
			public AssembledTankActivatedStateComponent assembledTankActivatedState;

			public TankActiveStateComponent tankActiveState;

			public TankGroupComponent tankGroup;

			public BattleGroupComponent battleGroup;

			public RigidbodyComponent rigidbody;

			public BaseRendererComponent baseRenderer;

			public TankCollidersComponent tankColliders;

			public ModuleVisualEffectObjectsComponent moduleVisualEffectObjects;
		}

		public class RemoteTankNode : TankNode
		{
			public RemoteTankComponent remoteTank;
		}

		public class SelfTankNode : TankNode
		{
			public SelfTankComponent selfTank;
		}

		public class SelfTankTeamNode : SelfTankNode
		{
			public TeamGroupComponent teamGroup;
		}

		[Not(typeof(TeamGroupComponent))]
		public class SelfTankNonTeamNode : SelfTankNode
		{
		}

		public class TeamNode : Node
		{
			public TeamComponent team;

			public TeamGroupComponent teamGroup;

			public BattleGroupComponent battleGroup;
		}

		public class BattleNode : Node
		{
			public BattleComponent battle;

			public BattleGroupComponent battleGroup;
		}

		public class TeamBattleNode : BattleNode
		{
			public TeamBattleComponent teamBattle;
		}

		[Not(typeof(TeamGroupComponent))]
		public class NonTeamBattleNode : BattleNode
		{
		}

		[OnEventFire]
		public void PlayEffect(NodeAddedEvent e, ExplosiveMassEffectNode effectNode, [JoinByTank] TankNode tank)
		{
			GameObject explosiveMassEffect = tank.moduleVisualEffectObjects.ExplosiveMassEffect;
			if (!explosiveMassEffect.activeInHierarchy)
			{
				explosiveMassEffect.transform.position = tank.rigidbody.RigidbodyTransform.position;
				explosiveMassEffect.SetActive(true);
			}
			NewEvent(new TankFallEvent
			{
				FallingPower = 100f,
				FallingType = TankFallingType.NOTHING
			}).Attach(tank).ScheduleDelayed((float)effectNode.explosiveMassEffect.Delay / 1000f);
		}

		[OnEventFire]
		public void CollectTargetsInTeamBattle(NodeAddedEvent e, ExplosiveMassEffectNode effect, [JoinByTank] SelfTankTeamNode selfTank, [JoinByTeam] TeamNode selfTeam, [JoinByBattle] TeamBattleNode battle, [JoinByBattle][Combine] TeamNode team)
		{
			if (!team.Entity.Equals(selfTeam.Entity))
			{
				NewEvent(new CollectTargetsInRadius
				{
					Radius = effect.explosiveMassEffect.Radius
				}).AttachAll(effect, selfTank, battle, team).ScheduleDelayed((float)effect.explosiveMassEffect.Delay / 1000f);
			}
		}

		[OnEventFire]
		public void CollectTargetsInNonTeamBattle(NodeAddedEvent e, ExplosiveMassEffectNode effect, [JoinByTank] SelfTankNonTeamNode selfTank, [JoinByBattle] NonTeamBattleNode battle, [JoinByBattle] ICollection<RemoteTankNode> otherTanks)
		{
			NewEvent(new CollectTargetsInRadius
			{
				Radius = effect.explosiveMassEffect.Radius
			}).AttachAll(effect, selfTank, battle).ScheduleDelayed((float)effect.explosiveMassEffect.Delay / 1000f);
		}

		[OnEventComplete]
		public void SendTargetsToServer(CollectTargetsInRadius evt, ExplosiveMassEffectNode effect, SelfTankNode tank)
		{
			SelfHitEvent selfHitEvent = new SelfHitEvent();
			selfHitEvent.Targets = new List<HitTarget>();
			SelfHitEvent selfHitEvent2 = selfHitEvent;
			foreach (Entity target in evt.Targets)
			{
				Entity tankIncarnation = target.SendEvent(new GetTankIncarnationEvent()).TankIncarnation;
				if (tankIncarnation != null)
				{
					selfHitEvent2.Targets.Add(new HitTarget
					{
						Entity = target,
						LocalHitPoint = Vector3.zero,
						HitDirection = Vector3.zero,
						HitDistance = 0f,
						IncarnationEntity = tankIncarnation,
						TargetPosition = Vector3.zero
					});
				}
			}
			ScheduleEvent<SynchronizeSelfTankPositionBeforeEffectEvent>(tank);
			ScheduleEvent(selfHitEvent2, effect);
		}

		[OnEventFire]
		public void GetIncarnation(GetTankIncarnationEvent e, TankNode tank, [JoinByTank] SingleNode<TankIncarnationComponent> incarnation)
		{
			e.TankIncarnation = incarnation.Entity;
		}
	}
}
