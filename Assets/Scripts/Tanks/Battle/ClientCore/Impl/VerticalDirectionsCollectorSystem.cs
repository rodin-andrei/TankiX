using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class VerticalDirectionsCollectorSystem : AbstractDirectionsCollectorSystem
	{
		public class VerticalTargetingNode : Node
		{
			public VerticalTargetingComponent verticalTargeting;

			public MuzzlePointComponent muzzlePoint;

			public WeaponInstanceComponent weaponInstance;
		}

		[OnEventFire]
		public void CollectDirections(CollectDirectionsEvent evt, VerticalTargetingNode verticalTargeting)
		{
			TargetingData targetingData = evt.TargetingData;
			VerticalTargetingComponent verticalTargeting2 = verticalTargeting.verticalTargeting;
			AbstractDirectionsCollectorSystem.CollectDirection(targetingData.Origin, targetingData.Dir, 0f, targetingData);
			Vector3 leftDirectionWorld = new MuzzleLogicAccessor(verticalTargeting.muzzlePoint, verticalTargeting.weaponInstance).GetLeftDirectionWorld();
			if (verticalTargeting2.NumRaysUp > 0)
			{
				CollectSectorDirections(targetingData.Origin, targetingData.Dir, leftDirectionWorld, verticalTargeting2.AngleUp / (float)verticalTargeting2.NumRaysUp, verticalTargeting2.NumRaysUp, targetingData);
			}
			if (verticalTargeting2.NumRaysDown > 0)
			{
				CollectSectorDirections(targetingData.Origin, targetingData.Dir, leftDirectionWorld, (0f - verticalTargeting2.AngleDown) / (float)verticalTargeting2.NumRaysDown, verticalTargeting2.NumRaysDown, targetingData);
			}
		}
	}
}
