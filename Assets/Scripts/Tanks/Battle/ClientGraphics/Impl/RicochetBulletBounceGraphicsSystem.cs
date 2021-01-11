using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class RicochetBulletBounceGraphicsSystem : ECSSystem
	{
		public class WeaponNode : Node
		{
			public TankGroupComponent tankGroup;

			public RicochetComponent ricochet;

			public BulletEffectComponent bulletEffect;
		}

		public class BulletNode : Node
		{
			public TankGroupComponent tankGroup;

			public RicochetBulletComponent ricochetBullet;
		}

		[OnEventFire]
		public void SpawnExplosionOnBounce(UpdateBulletEvent e, BulletNode bulletNode, [JoinByTank] WeaponNode weaponNode)
		{
			BulletEffectComponent bulletEffect = weaponNode.bulletEffect;
			DirectionData directionData = e.TargetingData.Directions.First();
			if (directionData.StaticHit != null)
			{
				GetInstanceFromPoolEvent getInstanceFromPoolEvent = new GetInstanceFromPoolEvent();
				getInstanceFromPoolEvent.Prefab = bulletEffect.ExplosionPrefab;
				getInstanceFromPoolEvent.AutoRecycleTime = bulletEffect.ExplosionTime;
				GetInstanceFromPoolEvent getInstanceFromPoolEvent2 = getInstanceFromPoolEvent;
				ScheduleEvent(getInstanceFromPoolEvent2, new EntityStub());
				Transform instance = getInstanceFromPoolEvent2.Instance;
				instance.position = directionData.StaticHit.Position + directionData.StaticHit.Normal * bulletEffect.ExplosionOffset;
				instance.rotation = Quaternion.LookRotation(directionData.StaticHit.Normal);
				instance.gameObject.SetActive(true);
			}
		}
	}
}
