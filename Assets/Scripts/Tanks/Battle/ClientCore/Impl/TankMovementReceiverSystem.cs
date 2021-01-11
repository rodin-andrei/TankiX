using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class TankMovementReceiverSystem : ECSSystem
	{
		public class TankNode : Node
		{
			public TankGroupComponent tankGroup;

			public TankComponent tank;

			public TankMovementComponent tankMovement;

			public RigidbodyComponent rigidbody;

			public ChassisComponent chassis;

			public AssembledTankComponent assembledTank;

			public TankCollidersUnityComponent tankCollidersUnity;
		}

		public class WeaponNode : Node
		{
			public TankGroupComponent tankGroup;

			public WeaponRotationControlComponent weaponRotationControl;

			public WeaponInstanceComponent weaponInstance;
		}

		private static readonly float PATH_SMALL_DISTANCE = 5f;

		private static readonly float BIG_ROTATION_DEGREES = 60f;

		private static readonly Vector3 PATH_OFFSET = Vector3.up * 0.2f;

		[OnEventFire]
		public void OnTankAdded(NodeAddedEvent e, TankNode tank, [Context][JoinByTank] WeaponNode weapon)
		{
			base.Log.DebugFormat("INIT {0}", tank);
			TankMovementComponent tankMovement = tank.tankMovement;
			Movement? movement = tankMovement.Movement;
			ApplyMovement(tank, ref movement, true);
			ApplyMoveControl(tank, new MoveControl
			{
				MoveAxis = tankMovement.MoveControl.MoveAxis,
				TurnAxis = tankMovement.MoveControl.TurnAxis
			});
			ApplyWeaponRotation(weapon, tankMovement.WeaponRotation);
			ApplyWeaponControl(weapon, tankMovement.WeaponControl);
			ScheduleEvent<TankMovementInitEvent>(tank);
		}

		[OnEventFire]
		public void OnMoveCommandDiscrete(MoveCommandServerEvent e, TankNode tank, [JoinByTank] WeaponNode weapon)
		{
			base.Log.Debug("RECEIVE DISCRETE");
			MoveCommand moveCommand = e.MoveCommand;
			Movement? movement = e.MoveCommand.Movement;
			ApplyMovement(tank, ref movement, false);
			ApplyMoveControl(tank, new MoveControl
			{
				MoveAxis = moveCommand.TankControlVertical,
				TurnAxis = moveCommand.TankControlHorizontal
			});
			ApplyWeaponRotation(weapon, e.MoveCommand.WeaponRotation);
			ApplyWeaponControl(weapon, moveCommand.WeaponRotationControl);
		}

		[OnEventFire]
		public void OnMoveCommandAnalog(AnalogMoveCommandServerEvent e, TankNode tank, [JoinByTank] WeaponNode weapon)
		{
			base.Log.Debug("RECEIVE ANALOG");
			Movement? movement = e.Movement;
			ApplyMovement(tank, ref movement, false);
			ApplyMoveControl(tank, e.MoveControl);
			ApplyWeaponRotation(weapon, e.WeaponRotation);
			ApplyWeaponControl(weapon, e.WeaponControl);
		}

		private void ApplyMovement(TankNode tank, ref Movement? movement, bool init)
		{
			if (movement.HasValue)
			{
				Movement movement2 = movement.Value;
				if (PhysicsUtil.ValidateMovement(movement2))
				{
					bool flag = HalveMoveCommandIfNeed(tank, init, ref movement2);
					base.Log.Debug((!flag) ? "APPLY MOVEMENT" : "APPLY HALVED MOVEMENT");
					Transform rigidbodyTransform = tank.rigidbody.RigidbodyTransform;
					Rigidbody rigidbody = tank.rigidbody.Rigidbody;
					rigidbodyTransform.SetRotationSafe(movement2.Orientation);
					rigidbodyTransform.SetPositionSafe(TankPositionConverter.ConvertedReceptionFromServer(movement2.Position, tank.tankCollidersUnity, rigidbodyTransform.position));
					rigidbody.SetVelocitySafe(movement2.Velocity);
					rigidbody.SetAngularVelocitySafe(movement2.AngularVelocity);
				}
			}
		}

		private static bool IsTankDead(TankNode tank)
		{
			return tank.Entity.HasComponent<TankDeadStateComponent>();
		}

		private bool HalveMoveCommandIfNeed(TankNode tank, bool init, ref Movement movement)
		{
			if (init || tank.Entity.HasComponent<TankDeadStateComponent>())
			{
				return false;
			}
			Transform rigidbodyTransform = tank.rigidbody.RigidbodyTransform;
			Rigidbody rigidbody = tank.rigidbody.Rigidbody;
			Movement currentMoveDump = DumpMovement(rigidbodyTransform, rigidbody, tank.tankCollidersUnity);
			if (!IsMovePathClean(ref currentMoveDump, ref movement))
			{
				return false;
			}
			if (IsBigRotation(ref movement, ref currentMoveDump))
			{
				return false;
			}
			movement = InterpolateMoveCommand(ref currentMoveDump, ref movement, 0.5f);
			return true;
		}

		private bool IsMovePathClean(ref Movement currentMoveDump, ref Movement movement)
		{
			Vector3 vector = movement.Position - currentMoveDump.Position;
			float num = Vector3.SqrMagnitude(vector);
			if (num < PATH_SMALL_DISTANCE * PATH_SMALL_DISTANCE)
			{
				return true;
			}
			return !Physics.Raycast(currentMoveDump.Position + PATH_OFFSET, vector, Mathf.Sqrt(num), LayerMasks.STATIC);
		}

		private bool IsBigRotation(ref Movement movement, ref Movement currentMovement)
		{
			return Quaternion.Angle(currentMovement.Orientation, movement.Orientation) > BIG_ROTATION_DEGREES;
		}

		private Movement DumpMovement(Transform transform, Rigidbody rigidbody, TankCollidersUnityComponent tankCollidersUnity)
		{
			Movement result = default(Movement);
			result.Position = TankPositionConverter.ConvertedSentToServer(tankCollidersUnity);
			result.Orientation = transform.rotation;
			result.Velocity = rigidbody.velocity;
			result.AngularVelocity = rigidbody.angularVelocity;
			return result;
		}

		private Movement InterpolateMoveCommand(ref Movement moveCommand1, ref Movement moveCommand2, float interpolationCoeff)
		{
			Movement result = default(Movement);
			result.Position = Vector3.Lerp(moveCommand1.Position, moveCommand2.Position, interpolationCoeff);
			result.Orientation = Quaternion.Slerp(moveCommand1.Orientation, moveCommand2.Orientation, interpolationCoeff);
			result.Velocity = Vector3.Lerp(moveCommand1.Velocity, moveCommand2.Velocity, interpolationCoeff);
			result.AngularVelocity = Vector3.Slerp(moveCommand1.AngularVelocity, moveCommand2.AngularVelocity, interpolationCoeff);
			return result;
		}

		private void ApplyMoveControl(TankNode tank, MoveControl? moveControl)
		{
			if (moveControl.HasValue)
			{
				ApplyMoveControl(tank.chassis, moveControl.Value.MoveAxis, moveControl.Value.TurnAxis);
			}
		}

		private void ApplyMoveControl(ChassisComponent chassis, float moveAxis, float turnAxis)
		{
			base.Log.Debug("APPLY MOVE_CONTROL");
			chassis.MoveAxis = moveAxis;
			chassis.TurnAxis = turnAxis;
		}

		private void ApplyWeaponRotation(WeaponNode weapon, float? weaponRotation)
		{
			if (weaponRotation.HasValue)
			{
				ApplyWeaponRotation(weapon.weaponInstance, weaponRotation.Value);
				weapon.weaponRotationControl.Rotation = weaponRotation.Value;
			}
		}

		private void ApplyWeaponRotation(WeaponInstanceComponent weaponInstanceComponent, float weaponRotation)
		{
			base.Log.Debug("APPLY WEAPON_ROTATION");
			Transform transform = weaponInstanceComponent.WeaponInstance.transform;
			transform.SetLocalRotationSafe(Quaternion.AngleAxis(weaponRotation, Vector3.up));
			transform.localPosition = Vector3.zero;
		}

		private void ApplyWeaponControl(WeaponNode weapon, float? weaponControl)
		{
			ApplyWeaponControl(weapon.weaponRotationControl, weaponControl);
		}

		private void ApplyWeaponControl(WeaponRotationControlComponent weaponRotationComponent, float? weaponControl)
		{
			if (weaponControl.HasValue)
			{
				base.Log.Debug("APPLY WEAPON_CONTROL");
				weaponRotationComponent.Control = weaponControl.Value;
			}
		}
	}
}
