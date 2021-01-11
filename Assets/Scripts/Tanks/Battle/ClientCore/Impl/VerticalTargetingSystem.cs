using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class VerticalTargetingSystem : ECSSystem
	{
		public class TargetingNode : Node
		{
			public VerticalTargetingComponent verticalTargeting;

			public MuzzlePointComponent muzzlePoint;

			public WeaponInstanceComponent weaponInstance;
		}

		[Inject]
		public static BattleFlowInstancesCache BattleCache
		{
			get;
			set;
		}

		[OnEventFire]
		public void PrepareTargeting(TargetingEvent evt, TargetingNode verticalTargeting)
		{
			TargetingData targetingData = evt.TargetingData;
			VerticalTargetingComponent verticalTargeting2 = verticalTargeting.verticalTargeting;
			MuzzleLogicAccessor muzzleLogicAccessor = new MuzzleLogicAccessor(verticalTargeting.muzzlePoint, verticalTargeting.weaponInstance);
			targetingData.Origin = muzzleLogicAccessor.GetWorldPosition();
			targetingData.Dir = muzzleLogicAccessor.GetFireDirectionWorld();
			targetingData.FullDistance = verticalTargeting2.WorkDistance;
			targetingData.MaxAngle = ((!(verticalTargeting2.AngleUp > verticalTargeting2.AngleDown)) ? verticalTargeting2.AngleDown : verticalTargeting2.AngleUp);
			ScheduleEvent(BattleCache.collectDirectionsEvent.GetInstance().Init(targetingData), verticalTargeting);
			ScheduleEvent(BattleCache.collectTargetsEvent.GetInstance().Init(targetingData), verticalTargeting);
			ScheduleEvent(BattleCache.targetEvaluateEvent.GetInstance().Init(targetingData), verticalTargeting);
		}
	}
}
