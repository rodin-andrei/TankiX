using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientLogger.API;
using Platform.Library.ClientProtocol.Impl;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class TankMovementSenderSystem : ECSSystem
	{
		public class TankInitNode : Node
		{
			public TankGroupComponent tankGroup;

			public TankSyncComponent tankSync;

			public TankMovableComponent tankMovable;
		}

		public class TankNode : Node
		{
			public TankGroupComponent tankGroup;

			public TankSyncComponent tankSync;

			public TankMovableComponent tankMovable;

			public TankMovementSenderComponent tankMovementSender;

			public ChassisComponent chassis;

			public RigidbodyComponent rigidbody;

			public TankCollisionComponent tankCollision;

			public TankCollidersUnityComponent tankCollidersUnity;

			public ChassisSmootherComponent chassisSmoother;
		}

		public class AnyStateTankNode : Node
		{
			public TankGroupComponent tankGroup;

			public TankSyncComponent tankSync;

			public TankMovementSenderComponent tankMovementSender;

			public ChassisComponent chassis;

			public RigidbodyComponent rigidbody;

			public TankCollisionComponent tankCollision;

			public TankCollidersUnityComponent tankCollidersUnity;
		}

		public class WeaponNode : Node
		{
			public TankGroupComponent tankGroup;

			public WeaponRotationControlComponent weaponRotationControl;
		}

		public class TankIncarnationNode : Node
		{
			public TankIncarnationComponent tankIncarnation;

			public TankGroupComponent tankGroup;
		}

		private const float SEND_MAX_TIME = 2f;

		private const float MAX_DISTANCE = 5f;

		private const float MAX_DISTANCE_Y = 1.5f;

		private const float MAX_ACCELERATION_Y = 20f;

		private const float MAX_DISTANCE_SQUARED = 25f;

		[Inject]
		public static UnityTime UnityTime
		{
			get;
			set;
		}

		[OnEventFire]
		public void AddComponent(NodeAddedEvent e, SingleNode<SelfTankComponent> selfTank)
		{
			selfTank.Entity.AddComponent<TankSyncComponent>();
		}

		[OnEventFire]
		public void AddComponent(NodeAddedEvent e, TankInitNode tank)
		{
			tank.Entity.AddComponent<TankMovementSenderComponent>();
		}

		[OnEventFire]
		public void RemoveComponent(NodeRemoveEvent e, TankInitNode tank)
		{
			tank.Entity.RemoveComponent<TankMovementSenderComponent>();
		}

		[OnEventFire]
		public void OnReset(NodeAddedEvent e, TankIncarnationNode incarnation, [JoinByTank] TankNode tankNode)
		{
			tankNode.tankMovementSender.LastSentMovementTime = 0.0;
		}

		[OnEventFire]
		public void OnUpdate(UpdateEvent e, TankNode tankNode, [JoinByTank] WeaponNode weaponNode)
		{
			if (NeedRegularCorrection(tankNode) || NeedMandatoryCorrection(tankNode))
			{
				CollectCommandsAndSend(tankNode, weaponNode, MoveCommandType.FULL);
			}
			if (FloatCodec.DECODE_NAN_ERRORS != 0 || FloatCodec.ENCODE_NAN_ERRORS != 0)
			{
				long num = ((!tankNode.Entity.HasComponent<BattleGroupComponent>()) ? 0 : tankNode.Entity.GetComponent<BattleGroupComponent>().Key);
				base.Log.ErrorFormat("NaN detected: battle={0} DECODE_NAN_ERRORS={1} ENCODE_NAN_ERRORS={2} encodeErrorStack={3}", num, FloatCodec.DECODE_NAN_ERRORS, FloatCodec.ENCODE_NAN_ERRORS, (FloatCodec.encodeErrorStack == null) ? "null" : FloatCodec.encodeErrorStack.StackTrace);
				FloatCodec.DECODE_NAN_ERRORS = 0;
				FloatCodec.ENCODE_NAN_ERRORS = 0;
			}
		}

		[OnEventFire]
		public void InitializeClientTime(NodeAddedEvent e, TankInitNode tankNode, [JoinByTank][Context] WeaponNode weaponNode)
		{
			ScheduleEvent<InitializeTimeCheckerEvent>(tankNode);
		}

		[OnEventFire]
		public void InitializeClientTime(NodeAddedEvent e, TankNode tankNode, [JoinByTank] WeaponNode weaponNode)
		{
			ScheduleEvent<InitializeTimeCheckerEvent>(tankNode);
			CollectCommandsAndSend(tankNode, weaponNode, MoveCommandType.FULL);
		}

		[OnEventComplete]
		public void UpdateLastPosition(FixedUpdateEvent e, TankNode tank)
		{
			tank.tankMovementSender.LastPhysicsMovement = GetMovement(tank);
		}

		[OnEventComplete]
		public void OnAfterFixedUpdate(AfterFixedUpdateEvent e, TankNode tankNode, [JoinByTank] WeaponNode weaponNode)
		{
			TankMovementSenderComponent tankMovementSender = tankNode.tankMovementSender;
			Rigidbody rigidbody = tankNode.rigidbody.Rigidbody;
			Vector3 velocity = rigidbody.velocity;
			float num = SqrMagnitudeXZ(velocity);
			Vector3 velocity2 = tankMovementSender.LastPhysicsMovement.Velocity;
			if (!tankMovementSender.LastSentMovement.HasValue || (Mathf.Clamp(velocity.y, 0f, float.MaxValue) - Mathf.Clamp(velocity2.y, 0f, float.MaxValue)) / Time.fixedDeltaTime > 20f || ((double)SqrMagnitudeXZ(velocity2) > (double)num + 0.01 && (double)SqrMagnitudeXZ(tankMovementSender.LastSentMovement.Value.Velocity) + 0.01 < (double)SqrMagnitudeXZ(velocity2)) || IsXZDistanceTooLarge(tankMovementSender.LastSentMovement.Value.Position, rigidbody.position) || IsYDistanceTooLarge(tankMovementSender.LastSentMovement.Value.Position, rigidbody.position))
			{
				CollectCommandsAndSend(tankNode, weaponNode, MoveCommandType.TANK);
			}
		}

		private bool IsYDistanceTooLarge(Vector3 lastPosition, Vector3 position)
		{
			return Mathf.Abs(position.y - lastPosition.y) > 1.5f;
		}

		private bool IsXZDistanceTooLarge(Vector3 lastPosition, Vector3 position)
		{
			float num = position.x - lastPosition.x;
			float num2 = position.z - lastPosition.z;
			return num * num + num2 * num2 > 25f;
		}

		[OnEventFire]
		public void SendTankMovement(SendTankMovementEvent e, TankNode tankNode, [JoinByTank] WeaponNode weaponNode)
		{
			CollectCommandsAndSend(tankNode, weaponNode, MoveCommandType.TANK);
		}

		private bool NeedRegularCorrection(TankNode tankNode)
		{
			TankMovementSenderComponent tankMovementSender = tankNode.tankMovementSender;
			return PreciseTime.Time >= tankMovementSender.LastSentMovementTime + 2.0;
		}

		private bool NeedMandatoryCorrection(TankNode tankNode)
		{
			TankMovementSenderComponent tankMovementSender = tankNode.tankMovementSender;
			if (!tankMovementSender.LastSentMovement.HasValue)
			{
				return true;
			}
			if (tankNode.tankCollision.HasCollision != tankMovementSender.LastHasCollision)
			{
				tankMovementSender.LastHasCollision = tankNode.tankCollision.HasCollision;
				return true;
			}
			return false;
		}

		[OnEventFire]
		public void OnChassisControlChanged(ChassisControlChangedEvent e, TankNode tankNode, [JoinByTank] WeaponNode weaponNode)
		{
			CollectCommandsAndSend(tankNode, weaponNode, MoveCommandType.TANK);
		}

		[OnEventFire]
		public void OnEMPEffectTargetsCollection(SynchronizeSelfTankPositionBeforeEffectEvent e, TankNode tankNode, [JoinByTank] WeaponNode weaponNode)
		{
			CollectCommandsAndSend(tankNode, weaponNode, MoveCommandType.TANK);
		}

		[OnEventFire]
		public void OnWeaponRotationControlChanged(WeaponRotationControlChangedEvent e, WeaponNode weaponNode, [JoinByTank] TankNode tankNode)
		{
			CollectCommandsAndSend(tankNode, weaponNode, MoveCommandType.WEAPON);
		}

		private void CollectCommandsAndSend(TankNode tankNode, WeaponNode weaponNode, MoveCommandType commandType)
		{
			TankMovementSenderComponent tankMovementSender = tankNode.tankMovementSender;
			if ((commandType & MoveCommandType.TANK) != 0 && !(tankMovementSender.LastSentMovementTime < PreciseTime.Time))
			{
				commandType ^= MoveCommandType.TANK;
			}
			if ((commandType & MoveCommandType.WEAPON) != 0 && !(tankMovementSender.LastSentWeaponRotationTime < PreciseTime.Time))
			{
				commandType ^= MoveCommandType.WEAPON;
			}
			Movement? movement = null;
			float? weaponRotation = null;
			if ((commandType & MoveCommandType.TANK) != 0)
			{
				movement = GetMovement(tankNode);
			}
			if ((commandType & MoveCommandType.WEAPON) != 0)
			{
				weaponRotation = weaponNode.weaponRotationControl.Rotation;
			}
			MoveCommand moveCommand = default(MoveCommand);
			moveCommand.Movement = movement;
			moveCommand.WeaponRotation = weaponRotation;
			moveCommand.TankControlVertical = GetMoveAxis(tankNode);
			moveCommand.TankControlHorizontal = GetTurnAxis(tankNode);
			moveCommand.WeaponRotationControl = GetWeaponControl(weaponNode);
			moveCommand.ClientTime = (int)(PreciseTime.Time * 1000.0);
			MoveCommand moveCommand2 = moveCommand;
			SendCommand(tankNode, moveCommand2);
		}

		private float GetMoveAxis(TankNode tankNode)
		{
			return tankNode.chassis.EffectiveMoveAxis;
		}

		private float GetTurnAxis(TankNode tankNode)
		{
			return tankNode.chassis.EffectiveTurnAxis;
		}

		private float GetWeaponControl(WeaponNode weaponNode)
		{
			return weaponNode.weaponRotationControl.EffectiveControl;
		}

		private DiscreteTankControl GetControl(TankNode tankNode, WeaponNode weaponNode)
		{
			DiscreteTankControl result = default(DiscreteTankControl);
			ChassisComponent chassis = tankNode.chassis;
			MoveControl moveControl = default(MoveControl);
			moveControl.MoveAxis = chassis.EffectiveMoveAxis;
			moveControl.TurnAxis = chassis.EffectiveTurnAxis;
			result.TurnAxis = Mathf.RoundToInt(moveControl.TurnAxis);
			result.MoveAxis = Mathf.RoundToInt(moveControl.MoveAxis);
			result.WeaponControl = Mathf.RoundToInt(weaponNode.weaponRotationControl.EffectiveControl);
			return result;
		}

		private Movement GetMovement(TankNode tankNode)
		{
			if (PreciseTime.TimeType == TimeType.LAST_FIXED)
			{
				return tankNode.tankMovementSender.LastPhysicsMovement;
			}
			Rigidbody rigidbody = tankNode.rigidbody.Rigidbody;
			Transform rigidbodyTransform = tankNode.rigidbody.RigidbodyTransform;
			TankCollidersUnityComponent tankCollidersUnity = tankNode.tankCollidersUnity;
			Movement result = default(Movement);
			result.Position = TankPositionConverter.ConvertedSentToServer(tankCollidersUnity);
			result.Orientation = rigidbodyTransform.rotation;
			result.Velocity = GetVelocity(tankNode);
			result.AngularVelocity = rigidbody.angularVelocity;
			return result;
		}

		private Vector3 GetVelocity(TankNode tankNode)
		{
			Vector3 velocity = tankNode.rigidbody.Rigidbody.velocity;
			float num = SqrMagnitudeXZ(velocity);
			float currentValue = tankNode.chassisSmoother.maxSpeedSmoother.CurrentValue;
			if (num > currentValue * currentValue)
			{
				Vector3 vector = velocity;
				vector.y = 0f;
				velocity += (currentValue - Mathf.Sqrt(num)) * vector.normalized;
			}
			return velocity;
		}

		private void SendCommand(TankNode tankNode, MoveCommand moveCommand)
		{
			TankMovementSenderComponent tankMovementSender = tankNode.tankMovementSender;
			Movement? movement = moveCommand.Movement;
			if (movement.HasValue)
			{
				if (!PhysicsUtil.ValidateMovement(movement.Value))
				{
					return;
				}
				tankMovementSender.LastSentMovement = movement;
				tankMovementSender.LastSentMovementTime = PreciseTime.Time;
				base.Log.Debug("SEND MOVEMENT");
			}
			if (moveCommand.WeaponRotation.HasValue)
			{
				if (!PhysicsUtil.IsValidFloat(moveCommand.WeaponRotation.Value))
				{
					LoggerProvider.GetLogger(typeof(PhysicsUtil)).ErrorFormat("Invalid WeaponRotation. StackTrace:[{0}]", Environment.StackTrace);
					return;
				}
				tankMovementSender.LastSentWeaponRotationTime = PreciseTime.Time;
				base.Log.Debug("SEND WEAPON_ROTATION");
			}
			ScheduleEvent(new MoveCommandEvent(moveCommand), tankNode.Entity);
			base.Log.Debug("SEND DISCRETE");
		}

		[OnEventFire]
		public void SendShotToServerEvent(BeforeShotEvent e, WeaponNode weaponNode, [JoinByTank] TankNode tank)
		{
			CollectCommandsAndSend(tank, weaponNode, MoveCommandType.FULL);
		}

		private float SqrMagnitudeXZ(Vector3 vector)
		{
			return vector.x * vector.x + vector.z * vector.z;
		}
	}
}
