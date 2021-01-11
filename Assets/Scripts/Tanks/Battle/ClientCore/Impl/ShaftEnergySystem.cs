using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class ShaftEnergySystem : ECSSystem
	{
		public class ShaftEnergyNode : Node
		{
			public ShaftEnergyComponent shaftEnergy;

			public WeaponEnergyComponent weaponEnergy;

			public WeaponEnergyESMComponent weaponEnergyEsm;

			public DiscreteWeaponComponent discreteWeapon;

			public TankGroupComponent tankGroup;
		}

		public class ShaftWorkingEnergyNode : Node
		{
			public ShaftStateControllerComponent shaftStateController;

			public ShaftEnergyComponent shaftEnergy;

			public ShaftAimingWorkingStateComponent shaftAimingWorkingState;
		}

		public class ActiveTankNode : Node
		{
			public TankActiveStateComponent tankActiveState;

			public TankGroupComponent tankGroup;
		}

		[OnEventFire]
		public void UpdateExhaustedWorkingEnergy(TimeUpdateEvent evt, ShaftWorkingEnergyNode weapon)
		{
			weapon.shaftAimingWorkingState.ExhaustedEnergy += weapon.shaftEnergy.UnloadAimingEnergyPerSec * evt.DeltaTime;
			weapon.shaftAimingWorkingState.ExhaustedEnergy = Mathf.Clamp(weapon.shaftAimingWorkingState.ExhaustedEnergy, 0f, weapon.shaftAimingWorkingState.InitialEnergy);
		}

		[OnEventFire]
		public void ReloadEnergy(TimeUpdateEvent evt, ShaftEnergyNode weapon, [JoinByTank] SingleNode<WeaponEnergyReloadingStateComponent> reloading, [JoinByTank] ActiveTankNode tank)
		{
			ReloadEnergy(evt, weapon);
		}

		[OnEventFire]
		public void UnloadEnergy(TimeUpdateEvent evt, ShaftEnergyNode weapon, [JoinByTank] SingleNode<WeaponEnergyUnloadingStateComponent> unloading, [JoinByTank] ActiveTankNode tank)
		{
			UnloadEnergy(evt, weapon);
		}

		[OnEventFire]
		public void StartReloading(NodeAddedEvent evt, ShaftEnergyNode weapon, [Context][JoinByTank] SingleNode<ShaftIdleStateComponent> state, [Context][JoinByTank] ActiveTankNode tank)
		{
			weapon.weaponEnergyEsm.Esm.ChangeState<WeaponEnergyStates.WeaponEnergyReloadingState>();
		}

		[OnEventFire]
		public void StartReloading(NodeAddedEvent evt, ShaftEnergyNode weapon, [Context][JoinByTank] SingleNode<ShaftWaitingStateComponent> state, [Context][JoinByTank] ActiveTankNode tank)
		{
			weapon.weaponEnergyEsm.Esm.ChangeState<WeaponEnergyStates.WeaponEnergyReloadingState>();
		}

		[OnEventFire]
		public void StartReloading(NodeAddedEvent evt, ShaftEnergyNode weapon, [Context][JoinByTank] SingleNode<ShaftAimingWorkFinishStateComponent> state, [Context][JoinByTank] ActiveTankNode tank)
		{
			weapon.weaponEnergyEsm.Esm.ChangeState<WeaponEnergyStates.WeaponEnergyReloadingState>();
		}

		[OnEventFire]
		public void StartUnloading(NodeAddedEvent evt, ShaftEnergyNode weapon, [Context][JoinByTank] SingleNode<ShaftAimingWorkActivationStateComponent> state, [Context][JoinByTank] ActiveTankNode tank)
		{
			weapon.weaponEnergyEsm.Esm.ChangeState<WeaponEnergyStates.WeaponEnergyUnloadingState>();
		}

		[OnEventFire]
		public void StartUnloading(NodeAddedEvent evt, ShaftEnergyNode weapon, [Context][JoinByTank] SingleNode<ShaftAimingWorkingStateComponent> state, [Context][JoinByTank] ActiveTankNode tank)
		{
			weapon.weaponEnergyEsm.Esm.ChangeState<WeaponEnergyStates.WeaponEnergyUnloadingState>();
		}

		[OnEventFire]
		public void UnloadEnergyPerQuickShot(BaseShotEvent evt, ShaftEnergyNode weapon, [JoinByTank] SingleNode<ShaftIdleStateComponent> state)
		{
			UnloadEnergyByQuickShot(weapon);
		}

		[OnEventFire]
		public void UnloadEnergyPerAimingShot(BaseShotEvent evt, ShaftEnergyNode weapon, [JoinByTank] SingleNode<ShaftAimingWorkFinishStateComponent> state)
		{
			UnloadEnergyByAimingShot(weapon);
		}

		private void UnloadEnergyByQuickShot(ShaftEnergyNode weapon)
		{
			float deltaEnergy = 0f - weapon.shaftEnergy.UnloadEnergyPerQuickShot;
			ApplyDeltaEnergy(deltaEnergy, weapon);
		}

		private void UnloadEnergyByAimingShot(ShaftEnergyNode weapon)
		{
			weapon.weaponEnergy.Energy = Mathf.Min(weapon.weaponEnergy.Energy, 1f - weapon.shaftEnergy.PossibleUnloadEnergyPerAimingShot);
			weapon.weaponEnergy.Energy = Mathf.Clamp01(weapon.weaponEnergy.Energy);
		}

		private void ReloadEnergy(TimeUpdateEvent evt, ShaftEnergyNode weapon)
		{
			float num = weapon.shaftEnergy.ReloadEnergyPerSec * evt.DeltaTime;
			weapon.weaponEnergy.Energy += num;
			if (weapon.weaponEnergy.Energy >= 1f)
			{
				weapon.weaponEnergy.Energy = 1f;
				weapon.weaponEnergyEsm.Esm.ChangeState<WeaponEnergyStates.WeaponEnergyFullState>();
			}
		}

		private void UnloadEnergy(TimeUpdateEvent evt, ShaftEnergyNode weapon)
		{
			float deltaEnergy = (0f - weapon.shaftEnergy.UnloadAimingEnergyPerSec) * evt.DeltaTime;
			ApplyDeltaEnergy(deltaEnergy, weapon);
		}

		private void ApplyDeltaEnergy(float deltaEnergy, ShaftEnergyNode weapon)
		{
			weapon.weaponEnergy.Energy += deltaEnergy;
			weapon.weaponEnergy.Energy = Mathf.Clamp01(weapon.weaponEnergy.Energy);
		}
	}
}
