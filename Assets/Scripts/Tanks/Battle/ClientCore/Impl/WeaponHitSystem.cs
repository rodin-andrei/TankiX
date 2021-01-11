using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class WeaponHitSystem : ECSSystem
	{
		public class UnblockedWeaponNode : Node
		{
			public WeaponHitComponent weaponHit;

			public MuzzlePointComponent muzzlePoint;

			public WeaponUnblockedComponent weaponUnblocked;

			public ShotIdComponent shotId;
		}

		[Inject]
		public static BattleFlowInstancesCache BattleCache
		{
			get;
			set;
		}

		[OnEventComplete]
		public void PrepareTargets(ShotPrepareEvent evt, UnblockedWeaponNode weaponNode)
		{
			TargetingData targetingData = BattleCache.targetingData.GetInstance().Init();
			ScheduleEvent(new TargetingEvent(targetingData), weaponNode);
			ScheduleEvent(new SendShotToServerEvent(targetingData), weaponNode);
			ScheduleEvent(new SendHitToServerIfNeedEvent(targetingData), weaponNode);
		}

		[OnEventComplete]
		public void SendHit(SendHitToServerIfNeedEvent evt, UnblockedWeaponNode weapon)
		{
			WeaponHitComponent weaponHit = weapon.weaponHit;
			StaticHit staticHit = null;
			List<HitTarget> list = new List<HitTarget>(4);
			if (evt.TargetingData.HasTargetHit())
			{
				if (weaponHit.RemoveDuplicateTargets)
				{
					HashSet<Entity> hashSet = new HashSet<Entity>();
					for (int i = 0; i < evt.TargetingData.Directions.Count; i++)
					{
						DirectionData directionData = evt.TargetingData.Directions[i];
						for (int j = 0; j < directionData.Targets.Count; j++)
						{
							TargetData targetData = directionData.Targets[j];
							if (hashSet.Add(targetData.TargetEntity))
							{
								list.Add(HitTargetAdapter.Adapt(targetData));
							}
						}
					}
				}
				else
				{
					list = HitTargetAdapter.Adapt(evt.TargetingData.BestDirection.Targets);
				}
			}
			if (weaponHit.SendStaticHit && evt.TargetingData.HasStaticHit())
			{
				staticHit = evt.TargetingData.BestDirection.StaticHit;
			}
			if (staticHit != null || list.Count != 0)
			{
				ScheduleEvent(new SendHitToServerEvent(evt.TargetingData, list, staticHit), weapon);
			}
			else
			{
				ScheduleEvent<SelfHitSkipEvent>(weapon);
			}
		}

		[OnEventComplete]
		public void SendHitToServer(SendHitToServerEvent e, UnblockedWeaponNode weapon)
		{
			SelfHitEvent selfHitEvent = new SelfHitEvent(e.Targets, e.StaticHit);
			selfHitEvent.ShotId = weapon.shotId.ShotId;
			ScheduleEvent(selfHitEvent, weapon);
		}
	}
}
