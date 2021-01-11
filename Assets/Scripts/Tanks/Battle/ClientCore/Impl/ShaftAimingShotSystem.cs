using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class ShaftAimingShotSystem : ECSSystem
	{
		public class ShaftNode : Node
		{
			public WeaponShotComponent weaponShot;

			public MuzzlePointComponent muzzlePoint;

			public ShaftComponent shaft;

			public WeaponInstanceComponent weaponInstance;
		}

		public class BlockedShaftNode : ShaftNode
		{
			public WeaponBlockedComponent weaponBlocked;
		}

		public class UndergroundShaftNode : ShaftNode
		{
			public WeaponUndergroundComponent weaponUnderground;
		}

		[OnEventFire]
		public void SendShot(ShaftAimingShotPrepareEvent evt, BlockedShaftNode weapon)
		{
			ScheduleEvent(new SelfShotEvent(new MuzzleLogicAccessor(weapon.muzzlePoint, weapon.weaponInstance).GetFireDirectionWorld()), weapon);
		}

		[OnEventFire]
		public void SendShot(ShaftAimingShotPrepareEvent evt, UndergroundShaftNode weapon)
		{
			ScheduleEvent(new SelfShotEvent(new MuzzleLogicAccessor(weapon.muzzlePoint, weapon.weaponInstance).GetFireDirectionWorld()), weapon);
		}
	}
}
