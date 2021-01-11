using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class VulcanKickbackSystem : ECSSystem
	{
		public class KickbackNode : Node
		{
			public KickbackComponent kickback;

			public MuzzlePointComponent muzzlePoint;

			public WeaponStreamShootingComponent weaponStreamShooting;

			public WeaponInstanceComponent weaponInstance;

			public TankGroupComponent tankGroup;
		}

		public class TankNode : Node
		{
			public TankGroupComponent tankGroup;

			public RigidbodyComponent rigidbody;

			public TrackComponent track;

			public TankFallingComponent tankFalling;
		}

		[OnEventFire]
		public void ApplyKickback(FixedUpdateEvent evt, KickbackNode weapon, [JoinByTank] TankNode tank)
		{
			KickbackComponent kickback = weapon.kickback;
			MuzzleLogicAccessor muzzleLogicAccessor = new MuzzleLogicAccessor(weapon.muzzlePoint, weapon.weaponInstance);
			float deltaTime = evt.DeltaTime;
			Vector3 force = -muzzleLogicAccessor.GetFireDirectionWorld() * kickback.KickbackForce * WeaponConstants.WEAPON_FORCE_MULTIPLIER * deltaTime;
			Vector3 worldMiddlePosition = muzzleLogicAccessor.GetWorldMiddlePosition();
			Rigidbody rigidbody = tank.rigidbody.Rigidbody;
			TrackComponent track = tank.track;
			TankFallingComponent tankFalling = tank.tankFalling;
			VulcanPhysicsUtils.ApplyVulcanForce(force, rigidbody, worldMiddlePosition, tankFalling, track);
		}
	}
}
