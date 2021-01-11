using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class StreamWeaponCooldownSystem : ECSSystem
	{
		public class StreamWeaponCooldownNode : Node
		{
			public CooldownTimerComponent cooldownTimer;

			public WeaponCooldownComponent weaponCooldown;

			public StreamWeaponWorkingComponent streamWeaponWorking;

			public StreamWeaponComponent streamWeapon;
		}

		[OnEventFire]
		public void DefineCooldownTimerForTheFirstTickInWorkingState(NodeAddedEvent evt, StreamWeaponCooldownNode weapon)
		{
			weapon.cooldownTimer.CooldownTimerSec = weapon.weaponCooldown.CooldownIntervalSec;
		}
	}
}
