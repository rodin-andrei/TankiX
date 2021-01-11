using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class TargetCollectorComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public TargetCollector TargetCollector
		{
			get;
			protected set;
		}

		public TargetValidator TargetValidator
		{
			get;
			protected set;
		}

		public TargetCollectorComponent(TargetCollector targetCollector, TargetValidator targetValidator)
		{
			TargetCollector = targetCollector;
			TargetValidator = targetValidator;
		}

		public DirectionData Collect(Vector3 origin, Vector3 dir, float fullDistance, int layerMask = 0)
		{
			return TargetCollector.Collect(TargetValidator, fullDistance, origin, dir, layerMask);
		}

		public void Collect(TargetingData targetingData, int layerMask = 0)
		{
			TargetCollector.Collect(TargetValidator, targetingData, layerMask);
		}

		public void Collect(float fullDistance, DirectionData direction, int layerMask = 0)
		{
			TargetCollector.Collect(TargetValidator, fullDistance, direction, layerMask);
		}
	}
}
