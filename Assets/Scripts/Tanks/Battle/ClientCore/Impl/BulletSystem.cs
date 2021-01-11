using System;
using System.Collections.Generic;
using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class BulletSystem : ECSSystem
	{
		public class BulletNode : Node
		{
			public TankGroupComponent tankGroup;

			public BulletComponent bullet;

			public ReadyBulletComponent readyBullet;

			public BulletConfigComponent bulletConfig;
		}

		public class WeaponNode : Node
		{
			public WeaponComponent weapon;

			public TankGroupComponent tankGroup;

			public MuzzlePointComponent muzzlePoint;

			public WeaponInstanceComponent weaponInstance;
		}

		public class UnblockedWeaponNode : Node
		{
			public TankGroupComponent tankGroup;

			public MuzzlePointComponent muzzlePoint;
		}

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
		public void PrepareTargetsAtFirstFrame(NodeAddedEvent e, BulletNode bulletNode, [JoinByTank] WeaponNode weaponNode)
		{
			BulletComponent bullet = bulletNode.bullet;
			MuzzleLogicAccessor muzzleLogicAccessor = new MuzzleLogicAccessor(weaponNode.muzzlePoint, weaponNode.weaponInstance);
			Vector3 barrelOriginWorld = muzzleLogicAccessor.GetBarrelOriginWorld();
			Vector3 worldPosition = muzzleLogicAccessor.GetWorldPosition();
			float fullDistance = (worldPosition - barrelOriginWorld).magnitude * 1.2f;
			TargetingData targetingData = BattleCache.targetingData.GetInstance().Init();
			targetingData.Origin = barrelOriginWorld;
			targetingData.Dir = bullet.Direction;
			targetingData.FullDistance = fullDistance;
			ScheduleEvent(BattleCache.targetingEvent.GetInstance().Init(targetingData), bulletNode);
			ScheduleEvent(BattleCache.updateBulletEvent.GetInstance().Init(targetingData), bulletNode);
		}

		[OnEventFire]
		public void PrepareTargets(UpdateEvent e, BulletNode bulletNode, [JoinByTank] WeaponNode weaponNode)
		{
			BulletComponent bullet = bulletNode.bullet;
			BulletConfigComponent bulletConfig = bulletNode.bulletConfig;
			float num = UnityTime.time - bullet.LastUpdateTime;
			float val = Math.Max(0f, bulletConfig.FullDistance - bullet.Distance);
			float fullDistance = Math.Min(val, bullet.Speed * num);
			TargetingData targetingData = BattleCache.targetingData.GetInstance().Init();
			targetingData.Origin = bullet.Position - bullet.Direction * 0.1f;
			targetingData.Dir = bullet.Direction;
			targetingData.FullDistance = fullDistance;
			ScheduleEvent(BattleCache.targetingEvent.GetInstance().Init(targetingData), bulletNode);
			ScheduleEvent(BattleCache.updateBulletEvent.GetInstance().Init(targetingData), bulletNode);
		}

		[OnEventComplete]
		public void SendHitEvent(TargetingEvent e, SingleNode<BulletComponent> bulletNode, [JoinByTank] UnblockedWeaponNode weaponNode, [JoinByTank] SingleNode<TankSyncComponent> tankNode)
		{
			if (e.TargetingData.HasBaseStaticHit())
			{
				return;
			}
			foreach (DirectionData direction in e.TargetingData.Directions)
			{
				if (direction.HasTargetHit())
				{
					TargetData targetData = direction.Targets.First();
					if (targetData.TargetEntity.HasComponent<TankActiveStateComponent>())
					{
						PrepareTargetData(targetData, bulletNode.component);
						SelfHitEvent selfHitEvent = new SelfHitEvent();
						selfHitEvent.Targets = new List<HitTarget>
						{
							HitTargetAdapter.Adapt(targetData)
						};
						selfHitEvent.ShotId = bulletNode.component.ShotId;
						SelfHitEvent eventInstance = selfHitEvent;
						ScheduleEvent(eventInstance, weaponNode.Entity);
						break;
					}
				}
			}
		}

		[OnEventFire]
		public void DestroyBulletsOnRemoveWeapon(NodeRemoveEvent e, WeaponNode weapon, [JoinByTank][Combine] BulletNode bullet)
		{
			bullet.Entity.RemoveComponent<BulletComponent>();
			DeleteEntity(bullet.Entity);
		}

		protected void PrepareTargetData(TargetData targetData, BulletComponent bulletComponent)
		{
			targetData.HitDistance += bulletComponent.Distance;
			targetData.HitDirection = bulletComponent.Direction;
		}
	}
}
