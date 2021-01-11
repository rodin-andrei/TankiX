using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class SpiderDirectionCollectorSystem : AbstractDirectionsCollectorSystem
	{
		public class TargetingNode : Node
		{
			public UnitTargetingConfigComponent unitTargetingConfig;

			public UnitReadyComponent unitReady;

			public RigidbodyComponent rigidbody;
		}

		public class ActiveRemoteTank : Node
		{
			public TankComponent tank;

			public RemoteTankComponent remoteTank;

			public TankActiveStateComponent tankActiveState;

			public RigidbodyComponent rigidbody;
		}

		[OnEventFire]
		public void CollectDirections(TargetingEvent evt, TargetingNode targeting, [JoinAll] ICollection<ActiveRemoteTank> enemyTankNodes)
		{
			Rigidbody rigidbody = targeting.rigidbody.Rigidbody;
			Vector3 vector = rigidbody.position + Vector3.up * 1.5f;
			TargetingData targetingData = evt.TargetingData;
			targetingData.FullDistance = targeting.unitTargetingConfig.WorkDistance;
			float num = 5f;
			foreach (ActiveRemoteTank enemyTankNode in enemyTankNodes)
			{
				Rigidbody rigidbody2 = enemyTankNode.rigidbody.Rigidbody;
				Vector3 forward = rigidbody.transform.forward;
				float magnitude = (rigidbody2.position - vector).magnitude;
				if (!(magnitude > targeting.unitTargetingConfig.WorkDistance))
				{
					Vector3 normalized = (rigidbody2.position - vector).normalized;
					float angle = Mathf.Acos(Vector3.Dot(forward, normalized));
					AbstractDirectionsCollectorSystem.CollectDirection(vector, normalized, angle, targetingData);
				}
			}
			ScheduleEvent(AbstractDirectionsCollectorSystem.BattleCache.collectTargetsEvent.GetInstance().Init(targetingData), targeting);
			ScheduleEvent(AbstractDirectionsCollectorSystem.BattleCache.targetEvaluateEvent.GetInstance().Init(targetingData), targeting);
		}
	}
}
