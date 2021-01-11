using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class TwinsBulletSystem : AbstractBulletSystem
	{
		public class TankNode : Node
		{
			public AssembledTankComponent assembledTank;

			public RigidbodyComponent rigidbody;
		}

		public class BulletNode : Node
		{
			public TankGroupComponent tankGroup;

			public BulletComponent bullet;

			public ReadyBulletComponent readyBullet;

			public BulletConfigComponent bulletConfig;

			public TwinsBulletComponent twinsBullet;
		}

		public class WeaponNode : Node
		{
			public TankGroupComponent tankGroup;

			public TwinsComponent twins;

			public MuzzlePointComponent muzzlePoint;

			public WeaponBulletShotComponent weaponBulletShot;

			public ShotIdComponent shotId;
		}

		[OnEventFire]
		public void Build(BulletBuildEvent e, WeaponNode weaponNode, [JoinByTank] TankNode tankNode)
		{
			Entity entity = CreateEntity<TwinsBulletTemplate>("battle/weapon/twins/bullet");
			BulletComponent bulletComponent = new BulletComponent();
			WeaponBulletShotComponent weaponBulletShot = weaponNode.weaponBulletShot;
			bulletComponent.Speed = weaponBulletShot.BulletSpeed;
			bulletComponent.Radius = weaponBulletShot.BulletRadius;
			MuzzleVisualAccessor muzzleVisualAccessor = new MuzzleVisualAccessor(weaponNode.muzzlePoint);
			BulletConfigComponent bulletConfigComponent = entity.AddComponentAndGetInstance<BulletConfigComponent>();
			BulletTargetingComponent bulletTargetingComponent = new BulletTargetingComponent();
			bulletTargetingComponent.RadialRaysCount = bulletConfigComponent.RadialRaysCount;
			bulletTargetingComponent.Radius = bulletComponent.Radius;
			BulletTargetingComponent component = bulletTargetingComponent;
			Vector3 worldPosition = muzzleVisualAccessor.GetWorldPosition();
			Rigidbody rigidbody = tankNode.rigidbody.Rigidbody;
			bulletComponent.ShotId = weaponNode.shotId.ShotId;
			entity.AddComponent(component);
			TargetCollectorComponent component2 = new TargetCollectorComponent(new TargetCollector(tankNode.Entity), new TargetValidator(tankNode.Entity));
			entity.AddComponent(component2);
			InitBullet(bulletComponent, worldPosition, e.Direction, bulletComponent.Radius, rigidbody);
			entity.AddComponent(bulletComponent);
			entity.AddComponent(new TankGroupComponent(weaponNode.tankGroup.Key));
			entity.AddComponent<TwinsBulletComponent>();
			entity.AddComponent<ReadyBulletComponent>();
		}

		[OnEventComplete]
		public void HandleFrame(UpdateBulletEvent e, BulletNode bulletNode)
		{
			BulletComponent bullet = bulletNode.bullet;
			BulletConfigComponent bulletConfig = bulletNode.bulletConfig;
			DirectionData directionData = e.TargetingData.Directions[0];
			if (directionData.StaticHit != null)
			{
				bullet.Distance += (bullet.Position - directionData.StaticHit.Position).magnitude;
				SetPositionNearHitPoint(bullet, directionData.StaticHit.Position);
				SendBulletStaticHitEvent(bulletNode.Entity, bullet);
				DestroyBullet(bulletNode.Entity);
			}
			else if (!DestroyOnAnyTargetHit(bulletNode.Entity, bullet, bulletConfig, e.TargetingData))
			{
				MoveBullet(bulletNode.Entity, bullet);
				if (bullet.Distance > bulletConfig.FullDistance)
				{
					DestroyBullet(bulletNode.Entity);
				}
			}
		}
	}
}
