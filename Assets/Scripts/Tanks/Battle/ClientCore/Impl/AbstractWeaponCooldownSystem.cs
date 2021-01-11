using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public abstract class AbstractWeaponCooldownSystem : ECSSystem
	{
		protected void UpdateCooldownOnShot(CooldownTimerComponent cooldownTimerComponent, WeaponCooldownComponent weaponCooldownComponent)
		{
			float num = (cooldownTimerComponent.CooldownTimerSec = weaponCooldownComponent.CooldownIntervalSec);
		}
	}
}
