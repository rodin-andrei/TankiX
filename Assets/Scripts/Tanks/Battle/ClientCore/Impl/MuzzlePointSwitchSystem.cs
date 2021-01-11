using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class MuzzlePointSwitchSystem : ECSSystem
	{
		public class WeaponMultyMuzzleNode : Node
		{
			public TwinsComponent twins;

			public MuzzlePointComponent muzzlePoint;
		}

		[OnEventFire]
		public void SelfSwitchMuzzlePoint(PostShotEvent e, WeaponMultyMuzzleNode weaponNode)
		{
			MuzzlePointComponent muzzlePoint = weaponNode.muzzlePoint;
			muzzlePoint.CurrentIndex = (muzzlePoint.CurrentIndex + 1) % muzzlePoint.Points.Length;
			ScheduleEvent(new MuzzlePointSwitchEvent(muzzlePoint.CurrentIndex), weaponNode);
		}

		[OnEventComplete]
		public void RemoteSwitchMuzzlePoint(RemoteMuzzlePointSwitchEvent e, WeaponMultyMuzzleNode weaponNode)
		{
			MuzzlePointComponent muzzlePoint = weaponNode.muzzlePoint;
			muzzlePoint.CurrentIndex = e.Index % muzzlePoint.Points.Length;
		}
	}
}
