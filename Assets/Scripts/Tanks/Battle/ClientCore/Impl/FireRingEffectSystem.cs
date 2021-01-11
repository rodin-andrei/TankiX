using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientGraphics.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class FireRingEffectSystem : ECSSystem
	{
		public class FireEffectNode : Node
		{
			public FireRingEffectComponent fireRingEffect;
		}

		public class TankNode : Node
		{
			public AssembledTankActivatedStateComponent assembledTankActivatedState;

			public TankActiveStateComponent tankActiveState;

			public RigidbodyComponent rigidbody;

			public ModuleVisualEffectObjectsComponent moduleVisualEffectObjects;
		}

		[OnEventFire]
		public void EnableEffect(NodeAddedEvent e, FireEffectNode effectNode, [JoinByTank] TankNode tank)
		{
			GameObject fireRingEffect = tank.moduleVisualEffectObjects.FireRingEffect;
			if (!fireRingEffect.activeInHierarchy)
			{
				fireRingEffect.transform.position = tank.rigidbody.RigidbodyTransform.position;
				fireRingEffect.SetActive(true);
			}
			ScheduleEvent<StartSplashEffectEvent>(effectNode);
		}
	}
}
