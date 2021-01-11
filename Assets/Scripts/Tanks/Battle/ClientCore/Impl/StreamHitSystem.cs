using System;
using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class StreamHitSystem : ECSSystem
	{
		public class CheckingNode : Node
		{
			public StreamHitConfigComponent streamHitConfig;

			public StreamHitCheckingComponent streamHitChecking;
		}

		public class HitNode : Node
		{
			public StreamHitConfigComponent streamHitConfig;

			public StreamHitCheckingComponent streamHitChecking;

			public StreamHitComponent streamHit;

			public WeaponInstanceComponent weaponInstance;
		}

		private static readonly float NEAR_HIT_POSITION_EPSILON = 0.2f;

		[Inject]
		public static BattleFlowInstancesCache BattleCache
		{
			get;
			set;
		}

		[Inject]
		public static UnityTime UnityTime
		{
			get;
			set;
		}

		[OnEventFire]
		public void ResendRemoveStreamHit(NodeRemoveEvent e, SingleNode<StreamHitCheckingComponent> weapon)
		{
			ScheduleEvent<RemoveStreamHitEvent>(weapon);
		}

		[OnEventFire]
		public void RemoveStreamHit(RemoveStreamHitEvent e, SingleNode<StreamHitComponent> weapon)
		{
			weapon.Entity.RemoveComponent<StreamHitComponent>();
		}

		[OnEventFire]
		public void ValidateHitEvent(SelfHitEvent e, HitNode weapon)
		{
			if (e.Targets != null && e.Targets.Count > 0)
			{
				if (e.Targets.Count > 1)
				{
					throw new Exception("Invalid stream hit. Targets.Count=" + e.Targets.Count);
				}
				Entity entity = e.Targets.Single().Entity;
				Entity entity2 = weapon.streamHit.TankHit.Entity;
				if (!entity.Equals(entity2))
				{
					throw new Exception(string.Concat("Invalid stream hit. targetTankInEvent=", entity, " targetTankInComponent=", entity2));
				}
			}
		}

		[OnEventFire]
		public void UpdateExistenceBeforeHit(SendHitToServerEvent e, CheckingNode weapon, [JoinSelf] SingleNode<ShootableComponent> node)
		{
			UpdateHitExistence(e.TargetingData, weapon);
		}

		[OnEventFire]
		public void UpdateDataBeforeHit(SendHitToServerEvent e, HitNode weapon, [JoinSelf] SingleNode<ShootableComponent> node)
		{
			if (HasHit(e.TargetingData, weapon.streamHitConfig))
			{
				UpdateHitData(weapon, e.TargetingData, true);
			}
		}

		[OnEventFire]
		public void UpdateFromServer(RemoteUpdateStreamHitEvent e, SingleNode<StreamHitComponent> weapon)
		{
			weapon.component.TankHit = e.TankHit;
			weapon.component.StaticHit = e.StaticHit;
		}

		[OnEventFire]
		public void Check(UpdateEvent e, CheckingNode weapon)
		{
			if (weapon.Entity.HasComponent<StreamHitComponent>() || !(weapon.streamHitChecking.LastCheckTime + weapon.streamHitConfig.LocalCheckPeriod > UnityTime.time))
			{
				TargetingData targetingData = BattleCache.targetingData.GetInstance().Init();
				ScheduleEvent(new TargetingEvent(targetingData), weapon.Entity);
				ScheduleEvent(new StreamHitResultEvent(targetingData), weapon.Entity);
			}
		}

		[OnEventFire]
		public void UpdateChecking(StreamHitResultEvent e, CheckingNode weapon, [JoinSelf] SingleNode<ShootableComponent> node)
		{
			UpdateHitExistence(e.TargetingData, weapon);
		}

		private void UpdateHitExistence(TargetingData targetingData, CheckingNode weapon)
		{
			bool flag = weapon.Entity.HasComponent<StreamHitComponent>();
			if (HasHit(targetingData, weapon.streamHitConfig))
			{
				if (!flag)
				{
					AddStreamHit(weapon.Entity, targetingData, weapon.streamHitConfig, weapon.streamHitChecking);
				}
			}
			else if (flag)
			{
				weapon.Entity.RemoveComponent<StreamHitComponent>();
			}
		}

		private bool HasHit(TargetingData targetingData, StreamHitConfigComponent streamHitConfigComponent)
		{
			return targetingData.BestDirection.HasTargetHit() || (streamHitConfigComponent.DetectStaticHit && targetingData.BestDirection.HasStaticHit());
		}

		[OnEventComplete]
		public void UpdateHit(StreamHitResultEvent e, HitNode weapon, [JoinSelf] SingleNode<ShootableComponent> node)
		{
			UpdateHitData(weapon, e.TargetingData, false);
		}

		private void UpdateHitData(HitNode weapon, TargetingData targetingData, bool skipTimeoutCheck)
		{
			StreamHitConfigComponent streamHitConfig = weapon.streamHitConfig;
			StreamHitCheckingComponent streamHitChecking = weapon.streamHitChecking;
			StreamHitComponent streamHit = weapon.streamHit;
			HitTarget tankHit = GetTankHit(targetingData);
			DirectionData bestDirection = targetingData.BestDirection;
			weapon.streamHitChecking.LastCheckTime = UnityTime.time;
			streamHit.TankHit = tankHit;
			streamHit.StaticHit = bestDirection.StaticHit;
			StaticHit staticHit = ((!streamHitConfig.DetectStaticHit) ? null : bestDirection.StaticHit);
			bool flag = false;
			bool flag2 = false;
			if (!IsSameTank(tankHit, streamHitChecking.LastSentTankHit))
			{
				flag = true;
			}
			else if (skipTimeoutCheck || streamHitChecking.LastSendToServerTime + streamHitConfig.SendToServerPeriod < UnityTime.time)
			{
				if (!IsAlmostEqual(staticHit, streamHitChecking.LastSentStaticHit))
				{
					flag2 = true;
				}
				else if (!IsAlmostEqual(tankHit, streamHitChecking.LastSentTankHit))
				{
					flag2 = true;
				}
			}
			if (flag)
			{
				weapon.Entity.RemoveComponent<StreamHitComponent>();
				AddStreamHit(weapon.Entity, targetingData, streamHitConfig, streamHitChecking);
			}
			else if (flag2)
			{
				ScheduleEvent(new SelfUpdateStreamHitEvent(tankHit, staticHit), weapon);
				SaveHitSentToServer(streamHitChecking, streamHit);
			}
		}

		private void AddStreamHit(Entity weapon, TargetingData targetingData, StreamHitConfigComponent config, StreamHitCheckingComponent checking)
		{
			if (!targetingData.HasAnyHit())
			{
				throw new Exception("No hit in StreamHit " + weapon);
			}
			if (!config.DetectStaticHit && !targetingData.HasTargetHit())
			{
				throw new Exception("No tank in StreamHit" + weapon);
			}
			StreamHitComponent streamHitComponent = new StreamHitComponent();
			FillStreamHit(streamHitComponent, targetingData);
			SaveHitSentToServer(checking, streamHitComponent);
			weapon.AddComponent(streamHitComponent);
		}

		private void FillStreamHit(StreamHitComponent hit, TargetingData targetingData)
		{
			hit.TankHit = GetTankHit(targetingData);
			hit.StaticHit = targetingData.BestDirection.StaticHit;
		}

		private void SaveHitSentToServer(StreamHitCheckingComponent checking, StreamHitComponent streamHit)
		{
			checking.LastSendToServerTime = UnityTime.time;
			checking.LastSentTankHit = streamHit.TankHit;
			checking.LastSentStaticHit = streamHit.StaticHit;
		}

		private bool IsSameTank(HitTarget tankHit, HitTarget lastSentTankHit)
		{
			if (tankHit == null && lastSentTankHit == null)
			{
				return true;
			}
			if (tankHit == null || lastSentTankHit == null)
			{
				return false;
			}
			return tankHit.Entity == lastSentTankHit.Entity;
		}

		private bool IsAlmostEqual(HitTarget tankHit, HitTarget lastSentTankHit)
		{
			return tankHit == null || MathUtil.NearlyEqual(tankHit.LocalHitPoint, lastSentTankHit.LocalHitPoint, NEAR_HIT_POSITION_EPSILON);
		}

		private static bool IsAlmostEqual(StaticHit staticHit, StaticHit lastSentStaticHit)
		{
			if (staticHit == null && lastSentStaticHit == null)
			{
				return true;
			}
			if (staticHit == null || lastSentStaticHit == null)
			{
				return false;
			}
			return MathUtil.NearlyEqual(staticHit.Position, lastSentStaticHit.Position, NEAR_HIT_POSITION_EPSILON);
		}

		private static HitTarget GetTankHit(TargetingData targetingData)
		{
			return (!targetingData.BestDirection.HasTargetHit()) ? null : HitTargetAdapter.Adapt(targetingData.BestDirection.Targets[0]);
		}
	}
}
