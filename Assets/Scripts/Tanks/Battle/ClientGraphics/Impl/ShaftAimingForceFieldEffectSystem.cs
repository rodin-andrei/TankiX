using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftAimingForceFieldEffectSystem : ECSSystem
	{
		public class ShaftNode : Node
		{
			public ShaftComponent shaft;

			public WeaponComponent weapon;

			public WeaponVisualRootComponent weaponVisualRoot;

			public WeaponEnergyComponent weaponEnergy;

			public TankGroupComponent tankGroup;
		}

		public class ReadyShaftNode : ShaftNode
		{
			public ShaftAimingForceFieldReadyComponent shaftAimingForceFieldReady;
		}

		public class IdleReadyShaftNode : ReadyShaftNode
		{
			public ShaftIdleStateComponent shaftIdleState;
		}

		public class WaitingReadyShaftNode : ReadyShaftNode
		{
			public ShaftWaitingStateComponent shaftWaitingState;
		}

		public class WorkActivationReadyShaftNode : ReadyShaftNode
		{
			public ShaftAimingWorkActivationStateComponent shaftAimingWorkActivationState;
		}

		public class WorkingReadyShaftNode : ReadyShaftNode
		{
			public ShaftAimingWorkingStateComponent shaftAimingWorkingState;
		}

		public class TankNode : Node
		{
			public TankComponent tank;

			public TankGroupComponent tankGroup;

			public BattleGroupComponent battleGroup;
		}

		public class SelfTankNode : TankNode
		{
			public SelfTankComponent selfTank;
		}

		public class EnemyRemoteTankNode : TankNode
		{
			public RemoteTankComponent remoteTank;

			public EnemyComponent enemy;
		}

		public class ForceFieldEffectNode : Node
		{
			public ForceFieldEffectComponent forceFieldEffect;

			public EffectRendererGraphicsComponent effectRendererGraphics;

			public TankGroupComponent tankGroup;
		}

		public class ReadyForceFieldEffectNode : ForceFieldEffectNode
		{
			public ForceFieldEffectReadyForShaftComponent forceFieldEffectReadyForShaft;
		}

		private const float SHAFT_AIMING_FORCE_FIELD_MULTIPLIER = 7.5f;

		private const float MIN_DISTANCE = 30f;

		private const float MAX_DISTANCE = 100f;

		private const string GLOBAL_SHAFT_AIMING_FORCE_FIELD_DATA_NAME = "_ShaftAimingForceFieldData";

		private const string GLOBAL_SHAFT_AIMING_FORCE_FIELD_SETTINGS_NAME = "_ShaftAimingForceFieldSettings";

		[OnEventFire]
		public void InitDataForShaftAiming(NodeAddedEvent e, ShaftNode weapon, [JoinByTank][Context] SelfTankNode tank)
		{
			weapon.Entity.AddComponent(new ShaftAimingForceFieldReadyComponent(Shader.PropertyToID("_ShaftAimingForceFieldData")));
		}

		[OnEventFire]
		public void InitEveryForceFieldForShaft(NodeAddedEvent e, ForceFieldEffectNode effect)
		{
			InitFriendlyForceField(effect);
			effect.Entity.AddComponent<ForceFieldEffectReadyForShaftComponent>();
		}

		[OnEventFire]
		public void InitEveryForceFieldForShaft(NodeAddedEvent e, [Combine] ReadyForceFieldEffectNode effect, [JoinByTank][Context] EnemyRemoteTankNode enemyTank)
		{
			InitEnemyForceField(effect);
		}

		private void InitEnemyForceField(ForceFieldEffectNode effect)
		{
			effect.effectRendererGraphics.Renderer.material.SetVector("_ShaftAimingForceFieldSettings", new Vector4(30f, 100f, 0f, 0f));
		}

		private void InitFriendlyForceField(ForceFieldEffectNode effect)
		{
			effect.effectRendererGraphics.Renderer.material.SetVector("_ShaftAimingForceFieldSettings", new Vector4(30f, 100f, 1f, 0f));
		}

		[OnEventFire]
		public void ResetEffect(NodeAddedEvent e, IdleReadyShaftNode weapon)
		{
			ResetEffect(weapon);
		}

		[OnEventFire]
		public void ResetEffect(NodeAddedEvent e, WaitingReadyShaftNode weapon)
		{
			ResetEffect(weapon);
		}

		[OnEventFire]
		public void ResetEffect(NodeAddedEvent e, WorkActivationReadyShaftNode weapon)
		{
			ResetEffect(weapon);
		}

		[OnEventFire]
		public void UpdateEffect(UpdateEvent e, WorkActivationReadyShaftNode weapon)
		{
			UpdateEffect(weapon);
		}

		[OnEventFire]
		public void UpdateEffect(UpdateEvent e, WorkingReadyShaftNode weapon)
		{
			UpdateEffect(weapon);
		}

		private void ResetEffect(ReadyShaftNode shaft)
		{
			UpdateEffect(shaft, 0f);
		}

		private void UpdateEffect(ReadyShaftNode shaft)
		{
			UpdateEffect(shaft, 7.5f * (1f - shaft.weaponEnergy.Energy));
		}

		private void UpdateEffect(ReadyShaftNode shaft, float value)
		{
			Vector3 position = shaft.weaponVisualRoot.transform.position;
			value = Mathf.Clamp01(value);
			Shader.SetGlobalVector(shaft.shaftAimingForceFieldReady.PropertyID, new Vector4(position.x, position.y, position.z, value));
		}
	}
}
