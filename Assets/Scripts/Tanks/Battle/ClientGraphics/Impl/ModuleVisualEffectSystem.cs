using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ModuleVisualEffectSystem : ECSSystem
	{
		public class TankInstanceNode : Node
		{
			public TankCommonInstanceComponent tankCommonInstance;

			public ModuleVisualEffectPrefabsComponent moduleVisualEffectPrefabs;
		}

		public class TankNode : Node
		{
			public AssembledTankActivatedStateComponent assembledTankActivatedState;

			public TankActiveStateComponent tankActiveState;

			public TankGroupComponent tankGroup;

			public BattleGroupComponent battleGroup;

			public RigidbodyComponent rigidbody;

			public BaseRendererComponent baseRenderer;

			public TankCollidersComponent tankColliders;

			public ModuleVisualEffectObjectsComponent moduleVisualEffectObjects;
		}

		public class InitEffectsEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
		{
		}

		[OnEventFire]
		public void ScheduleInitEffects(NodeAddedEvent e, TankInstanceNode tank)
		{
			NewEvent<InitEffectsEvent>().Attach(tank).ScheduleDelayed(0.3f);
		}

		[OnEventFire]
		public void InitEffects(InitEffectsEvent e, TankInstanceNode tank)
		{
			Transform transform = new GameObject("ModuleVisualEffects").transform;
			transform.SetParent(tank.tankCommonInstance.TankCommonInstance.transform);
			transform.localPosition = Vector3.zero;
			GameObject gameObject = Object.Instantiate(tank.moduleVisualEffectPrefabs.JumpImpactEffectPrefab, transform);
			gameObject.SetActive(false);
			GameObject gameObject2 = Object.Instantiate(tank.moduleVisualEffectPrefabs.ExternalImpactEffectPrefab, transform);
			gameObject2.SetActive(false);
			GameObject gameObject3 = Object.Instantiate(tank.moduleVisualEffectPrefabs.FireRingEffectPrefab, transform);
			gameObject3.SetActive(false);
			GameObject gameObject4 = Object.Instantiate(tank.moduleVisualEffectPrefabs.ExplosiveMassEffectPrefab, transform);
			gameObject4.SetActive(false);
			ModuleVisualEffectObjectsComponent moduleVisualEffectObjectsComponent = new ModuleVisualEffectObjectsComponent();
			moduleVisualEffectObjectsComponent.JumpImpactEffect = gameObject;
			moduleVisualEffectObjectsComponent.ExternalImpactEffect = gameObject2;
			moduleVisualEffectObjectsComponent.FireRingEffect = gameObject3;
			moduleVisualEffectObjectsComponent.ExplosiveMassEffect = gameObject4;
			ModuleVisualEffectObjectsComponent component = moduleVisualEffectObjectsComponent;
			tank.Entity.AddComponent(component);
		}

		[OnEventFire]
		public void TurnOffEffectsOnDeath(NodeRemoveEvent e, TankNode tank)
		{
			tank.moduleVisualEffectObjects.JumpImpactEffect.SetActive(false);
			tank.moduleVisualEffectObjects.ExternalImpactEffect.SetActive(false);
			tank.moduleVisualEffectObjects.FireRingEffect.SetActive(false);
			tank.moduleVisualEffectObjects.ExplosiveMassEffect.SetActive(false);
		}
	}
}
