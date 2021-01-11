using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class WeaponStreamTracerSystem : ECSSystem
	{
		public class WeaponStreamTracerInitNode : Node
		{
			public WeaponStreamTracerEffectComponent weaponStreamTracerEffect;

			public MuzzlePointComponent muzzlePoint;

			public WeaponVisualRootComponent weaponVisualRoot;
		}

		public class WeaponStreamTracerShootingEffectNode : Node
		{
			public WeaponStreamTracerEffectReadyComponent weaponStreamTracerEffectReady;

			public WeaponStreamTracerEffectComponent weaponStreamTracerEffect;

			public WeaponUnblockedComponent weaponUnblocked;

			public WeaponStreamShootingComponent weaponStreamShooting;
		}

		public class WeaponStreamTracerStreamHitNode : Node
		{
			public WeaponStreamTracerEffectReadyComponent weaponStreamTracerEffectReady;

			public WeaponStreamTracerEffectComponent weaponStreamTracerEffect;

			public StreamHitComponent streamHit;
		}

		public class HullNode : Node
		{
			public HullInstanceComponent hullInstance;

			public NewHolyshieldEffectComponent newHolyshieldEffect;
		}

		[OnEventFire]
		public void Init(NodeAddedEvent evt, WeaponStreamTracerInitNode weapon)
		{
			GameObject gameObject = Object.Instantiate(weapon.weaponStreamTracerEffect.Tracer);
			UnityUtil.InheritAndEmplace(gameObject.transform, weapon.muzzlePoint.Current);
			gameObject.SetActive(false);
			gameObject.transform.localPosition += Vector3.forward * weapon.weaponStreamTracerEffect.StartTracerOffset;
			weapon.weaponStreamTracerEffect.Tracer = gameObject;
			weapon.Entity.AddComponent<WeaponStreamTracerEffectReadyComponent>();
		}

		[OnEventFire]
		public void StartTracer(NodeAddedEvent evt, WeaponStreamTracerShootingEffectNode weapon)
		{
			weapon.weaponStreamTracerEffect.Tracer.SetActive(true);
		}

		[OnEventComplete]
		public void UpdateTracer(UpdateEvent evt, WeaponStreamTracerShootingEffectNode weapon)
		{
			WeaponStreamTracerBehaviour component = weapon.weaponStreamTracerEffect.Tracer.GetComponent<WeaponStreamTracerBehaviour>();
			if (!weapon.Entity.HasComponent<StreamHitComponent>())
			{
				float tracerMaxLength = weapon.weaponStreamTracerEffect.TracerMaxLength;
				component.TargetPosition = new Vector3(0f, 0f, tracerMaxLength);
			}
			else
			{
				ScheduleEvent<UpdateWeaponStreamTracerByStreamHitEvent>(weapon);
			}
		}

		[OnEventFire]
		public void UpdateTracer(UpdateWeaponStreamTracerByStreamHitEvent evt, WeaponStreamTracerStreamHitNode weapon)
		{
			StreamHitComponent streamHit = weapon.streamHit;
			GameObject tracer = weapon.weaponStreamTracerEffect.Tracer;
			WeaponStreamTracerBehaviour component = tracer.GetComponent<WeaponStreamTracerBehaviour>();
			if (streamHit.StaticHit != null)
			{
				Vector3 position = streamHit.StaticHit.Position;
				component.TargetPosition = MathUtil.WorldPositionToLocalPosition(position, tracer);
			}
			else if (streamHit.TankHit != null && weapon.Entity.HasComponent<StreamHitTargetLoadedComponent>())
			{
				HitTarget tankHit = streamHit.TankHit;
				Entity entity = tankHit.Entity;
				UpdateWeaponStreamTracerByTargetTankEvent updateWeaponStreamTracerByTargetTankEvent = new UpdateWeaponStreamTracerByTargetTankEvent();
				updateWeaponStreamTracerByTargetTankEvent.WeaponStreamTracerBehaviour = component;
				updateWeaponStreamTracerByTargetTankEvent.Hit = streamHit.TankHit;
				updateWeaponStreamTracerByTargetTankEvent.WeaponStreamTracerInstance = tracer;
				ScheduleEvent(updateWeaponStreamTracerByTargetTankEvent, entity);
			}
		}

		[OnEventFire]
		public void UpdateTracer(UpdateWeaponStreamTracerByTargetTankEvent evt, HullNode tank)
		{
			GameObject hullInstance = tank.hullInstance.HullInstance;
			Vector3 position = MathUtil.LocalPositionToWorldPosition(evt.Hit.LocalHitPoint, hullInstance);
			evt.WeaponStreamTracerBehaviour.TargetPosition = MathUtil.WorldPositionToLocalPosition(position, evt.WeaponStreamTracerInstance);
		}

		[OnEventFire]
		public void StopTracer(NodeRemoveEvent evt, WeaponStreamTracerShootingEffectNode node)
		{
			node.weaponStreamTracerEffect.Tracer.SetActive(false);
		}
	}
}
