using System;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class ShaftStateControllerSystem : ECSSystem
	{
		public class ShaftWeaponNode : Node
		{
			public WeaponEnergyComponent weaponEnergy;

			public CooldownTimerComponent cooldownTimer;

			public DiscreteWeaponComponent discreteWeapon;

			public ShaftStateConfigComponent shaftStateConfig;

			public ShaftStateControllerComponent shaftStateController;
		}

		public class ShaftIdleWeaponControllerNode : ShaftWeaponNode
		{
			public ShaftIdleStateComponent shaftIdleState;
		}

		public class ShaftWaitingWeaponControllerNode : ShaftWeaponNode
		{
			public ShaftWaitingStateComponent shaftWaitingState;

			public ShaftEnergyComponent shaftEnergy;
		}

		public class ShaftAimingWorkActivationWeaponControllerNode : ShaftWeaponNode
		{
			public ShaftAimingWorkActivationStateComponent shaftAimingWorkActivationState;

			public MuzzlePointComponent muzzlePoint;

			public WeaponInstanceComponent weaponInstance;
		}

		public class ShaftAimingWorkingWeaponControllerNode : ShaftWeaponNode
		{
			public ShaftAimingWorkingStateComponent shaftAimingWorkingState;
		}

		public class ShaftAimingWorkFinishWeaponControllerNode : ShaftWeaponNode
		{
			public ShaftAimingWorkFinishStateComponent shaftAimingWorkFinishState;
		}

		public class SelfActiveTankNode : Node
		{
			public TankActiveStateComponent tankActiveState;

			public SelfTankComponent selfTank;

			public TankGroupComponent tankGroup;
		}

		private HashSet<Type> weaponStates;

		[Inject]
		public static InputManager InputManager
		{
			get;
			set;
		}

		public ShaftStateControllerSystem()
		{
			weaponStates = new HashSet<Type>();
			weaponStates.Add(typeof(ShaftIdleStateComponent));
			weaponStates.Add(typeof(ShaftWaitingStateComponent));
			weaponStates.Add(typeof(ShaftAimingWorkActivationStateComponent));
			weaponStates.Add(typeof(ShaftAimingWorkingStateComponent));
			weaponStates.Add(typeof(ShaftAimingWorkFinishStateComponent));
		}

		[OnEventFire]
		public void InitIdleState(NodeAddedEvent evt, ShaftWeaponNode weapon)
		{
			StateUtils.SwitchEntityState<ShaftIdleStateComponent>(weapon.Entity, weaponStates);
		}

		[OnEventFire]
		public void InitWaitingStateOnInput(TimeUpdateEvent evt, ShaftIdleWeaponControllerNode weapon, [JoinByTank] SelfActiveTankNode activeTank)
		{
			StartWaitingStateIfPossible(weapon.Entity);
		}

		[OnEventFire]
		public void CheckWaitingState(TimeUpdateEvent evt, ShaftWaitingWeaponControllerNode weapon)
		{
			if (InputManager.CheckAction(ShotActions.SHOT))
			{
				StartWorkActivationStateIfPossible(weapon, evt.DeltaTime);
			}
			else
			{
				StartQuickShotIfPossible(weapon);
			}
		}

		[OnEventFire]
		public void CheckWorkActivationState(TimeUpdateEvent evt, ShaftAimingWorkActivationWeaponControllerNode weapon)
		{
			if (CheckHandleWeaponIntersectionStatus(weapon.Entity))
			{
				return;
			}
			if (!InputManager.CheckAction(ShotActions.SHOT))
			{
				MakeQuickShot(weapon.Entity);
				return;
			}
			float activationTimer = weapon.shaftAimingWorkActivationState.ActivationTimer;
			float activationToWorkingTransitionTimeSec = weapon.shaftStateConfig.ActivationToWorkingTransitionTimeSec;
			if (activationTimer < activationToWorkingTransitionTimeSec)
			{
				weapon.shaftAimingWorkActivationState.ActivationTimer += evt.DeltaTime;
				return;
			}
			MuzzleLogicAccessor muzzleLogicAccessor = new MuzzleLogicAccessor(weapon.muzzlePoint, weapon.weaponInstance);
			ShaftAimingWorkingStateComponent shaftAimingWorkingStateComponent = new ShaftAimingWorkingStateComponent();
			shaftAimingWorkingStateComponent.InitialEnergy = weapon.weaponEnergy.Energy;
			shaftAimingWorkingStateComponent.WorkingDirection = muzzleLogicAccessor.GetFireDirectionWorld();
			ShaftAimingWorkingStateComponent component = shaftAimingWorkingStateComponent;
			StateUtils.SwitchEntityState(weapon.Entity, component, weaponStates);
		}

		[OnEventFire]
		public void CheckWorkingState(EarlyUpdateEvent evt, ShaftAimingWorkingWeaponControllerNode weapon)
		{
			if (!CheckHandleWeaponIntersectionStatus(weapon.Entity) && !InputManager.CheckAction(ShotActions.SHOT))
			{
				MakeAimingShot(weapon.Entity, weapon.shaftAimingWorkingState.WorkingDirection);
			}
		}

		[OnEventFire]
		public void CheckWorkFinishState(TimeUpdateEvent evt, ShaftAimingWorkFinishWeaponControllerNode weapon)
		{
			float finishTimer = weapon.shaftAimingWorkFinishState.FinishTimer;
			float finishToIdleTransitionTimeSec = weapon.shaftStateConfig.FinishToIdleTransitionTimeSec;
			if (finishTimer < finishToIdleTransitionTimeSec)
			{
				weapon.shaftAimingWorkFinishState.FinishTimer += evt.DeltaTime;
			}
			else
			{
				StateUtils.SwitchEntityState<ShaftIdleStateComponent>(weapon.Entity, weaponStates);
			}
		}

		[OnEventFire]
		public void CheckWeaponStateOnInactiveTank(NodeRemoveEvent evt, SelfActiveTankNode tank, [JoinByTank] ShaftWeaponNode weapon)
		{
			StateUtils.SwitchEntityState<ShaftIdleStateComponent>(weapon.Entity, weaponStates);
		}

		private void StartWorkActivationStateIfPossible(ShaftWaitingWeaponControllerNode weapon, float dt)
		{
			if (weapon.Entity.HasComponent<WeaponUndergroundComponent>())
			{
				return;
			}
			float waitingTimer = weapon.shaftWaitingState.WaitingTimer;
			float waitingToActivationTransitionTimeSec = weapon.shaftStateConfig.WaitingToActivationTransitionTimeSec;
			if (waitingTimer < waitingToActivationTransitionTimeSec)
			{
				weapon.shaftWaitingState.WaitingTimer += dt;
				return;
			}
			float energy = weapon.weaponEnergy.Energy;
			if (!(energy < 1f))
			{
				StateUtils.SwitchEntityState<ShaftAimingWorkActivationStateComponent>(weapon.Entity, weaponStates);
			}
		}

		private void StartWaitingStateIfPossible(Entity weapon)
		{
			if (InputManager.CheckAction(ShotActions.SHOT))
			{
				StateUtils.SwitchEntityState<ShaftWaitingStateComponent>(weapon, weaponStates);
			}
		}

		private void StartQuickShotIfPossible(ShaftWaitingWeaponControllerNode weapon)
		{
			float unloadEnergyPerQuickShot = weapon.shaftEnergy.UnloadEnergyPerQuickShot;
			float energy = weapon.weaponEnergy.Energy;
			CooldownTimerComponent cooldownTimer = weapon.cooldownTimer;
			if (energy < unloadEnergyPerQuickShot)
			{
				StateUtils.SwitchEntityState<ShaftIdleStateComponent>(weapon.Entity, weaponStates);
			}
			else if (cooldownTimer.CooldownTimerSec > 0f)
			{
				StateUtils.SwitchEntityState<ShaftIdleStateComponent>(weapon.Entity, weaponStates);
			}
			else
			{
				MakeQuickShot(weapon.Entity);
			}
		}

		private bool CheckHandleWeaponIntersectionStatus(Entity weapon)
		{
			bool flag = weapon.HasComponent<WeaponUndergroundComponent>();
			if (flag)
			{
				StateUtils.SwitchEntityState<ShaftIdleStateComponent>(weapon, weaponStates);
			}
			return flag;
		}

		private void MakeQuickShot(Entity weapon)
		{
			StateUtils.SwitchEntityState<ShaftIdleStateComponent>(weapon, weaponStates);
			if (weapon.HasComponent<ShootableComponent>())
			{
				ScheduleEvent<BeforeShotEvent>(weapon);
				ScheduleEvent<ShotPrepareEvent>(weapon);
			}
		}

		private void MakeAimingShot(Entity weapon, Vector3 workingDir)
		{
			StateUtils.SwitchEntityState<ShaftAimingWorkFinishStateComponent>(weapon, weaponStates);
			if (weapon.HasComponent<ShootableComponent>())
			{
				ScheduleEvent<BeforeShotEvent>(weapon);
				ScheduleEvent(new ShaftAimingShotPrepareEvent(workingDir), weapon);
			}
		}
	}
}
