using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class TankAutopilotWeaponControllerSystem : ECSSystem
	{
		public class AutopilotTankNode : Node
		{
			public TankSyncComponent tankSync;

			public TankAutopilotComponent tankAutopilot;

			public TankActiveStateComponent tankActiveState;

			public AutopilotWeaponControllerComponent autopilotWeaponController;
		}

		public class DiscreteWeaponControllerNode : Node
		{
			public DiscreteWeaponControllerComponent discreteWeaponController;

			public DiscreteWeaponEnergyComponent discreteWeaponEnergy;

			public WeaponEnergyComponent weaponEnergy;

			public CooldownTimerComponent cooldownTimer;

			public DiscreteWeaponComponent discreteWeapon;
		}

		public class DiscreteWeaponMagazineControllerNode : Node
		{
			public DiscreteWeaponControllerComponent discreteWeaponController;

			public MagazineStorageComponent magazineStorage;

			public MagazineReadyStateComponent magazineReadyState;

			public CooldownTimerComponent cooldownTimer;

			public DiscreteWeaponComponent discreteWeapon;
		}

		[Inject]
		public static InputManager InputManager
		{
			get;
			set;
		}

		[OnEventComplete]
		public void StartShotIfPossible(EarlyUpdateEvent evt, DiscreteWeaponControllerNode discreteWeaponEnergyController, [JoinByTank] AutopilotTankNode autopilotTank)
		{
			float unloadEnergyPerShot = discreteWeaponEnergyController.discreteWeaponEnergy.UnloadEnergyPerShot;
			float energy = discreteWeaponEnergyController.weaponEnergy.Energy;
			CooldownTimerComponent cooldownTimer = discreteWeaponEnergyController.cooldownTimer;
			if (autopilotTank.autopilotWeaponController.Fire && !(energy < unloadEnergyPerShot) && !(cooldownTimer.CooldownTimerSec > 0f))
			{
				ScheduleEvent<BeforeShotEvent>(discreteWeaponEnergyController);
				ScheduleEvent<ShotPrepareEvent>(discreteWeaponEnergyController);
				ScheduleEvent<PostShotEvent>(discreteWeaponEnergyController);
			}
		}

		[OnEventFire]
		public void StartShotIfPossible(EarlyUpdateEvent evt, DiscreteWeaponMagazineControllerNode discreteWeaponMagazineController, [JoinByTank] AutopilotTankNode autopilotTank)
		{
			if (autopilotTank.autopilotWeaponController.Fire)
			{
				CooldownTimerComponent cooldownTimer = discreteWeaponMagazineController.cooldownTimer;
				if (!(cooldownTimer.CooldownTimerSec > 0f))
				{
					ScheduleEvent<BeforeShotEvent>(discreteWeaponMagazineController);
					ScheduleEvent<ShotPrepareEvent>(discreteWeaponMagazineController);
				}
			}
		}
	}
}
