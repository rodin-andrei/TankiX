using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Battle.ClientGraphics.API;
using Tanks.Lobby.ClientSettings.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ChassisAnimationSystem : ECSSystem
	{
		public class ChassisAnimationNode : Node
		{
			public TankVisualRootComponent tankVisualRoot;

			public CameraVisibleTriggerComponent cameraVisibleTrigger;

			public ChassisAnimationComponent chassisAnimation;

			public ChassisTrackControllerComponent chassisTrackController;

			public SpeedComponent speed;
		}

		public class AliveChassisAnimationNode : Node
		{
			public ChassisComponent chassis;

			public CameraVisibleTriggerComponent cameraVisibleTrigger;

			public ChassisAnimationComponent chassisAnimation;

			public ChassisTrackControllerComponent chassisTrackController;

			public TrackComponent track;

			public EffectiveSpeedComponent effectiveSpeed;

			public SpeedComponent speed;

			public RigidbodyComponent rigidbody;

			public TankMovableComponent tankMovable;
		}

		private const float MAX_WORK_DISTANCE = 50f;

		private const float MIN_TRACK_SPEED = 0.05f;

		private const float TRACK_SPEED_COEFF = 0.5f;

		[OnEventFire]
		public void AnimateWheelsAndTracksPosition(TimeUpdateEvent evt, ChassisAnimationNode node)
		{
			if ((GraphicsSettings.INSTANCE.CurrentQualityLevel <= 1 && node.Entity.HasComponent<SelfTankComponent>()) || (GraphicsSettings.INSTANCE.CurrentQualityLevel > 1 && node.cameraVisibleTrigger.IsVisibleAtRange(50f)))
			{
				ChassisAnimationComponent chassisAnimation = node.chassisAnimation;
				TrackController leftTrack = node.chassisTrackController.LeftTrack;
				TrackController rightTrack = node.chassisTrackController.RightTrack;
				leftTrack.highDistance = chassisAnimation.highDistance;
				leftTrack.lowDistance = chassisAnimation.lowDistance;
				rightTrack.highDistance = chassisAnimation.highDistance;
				rightTrack.lowDistance = chassisAnimation.lowDistance;
				Transform transform = node.tankVisualRoot.transform;
				if (chassisAnimation.additionalRaycastsEnabled)
				{
					leftTrack.AnimateWithAdditionalRays(transform, chassisAnimation.smoothSpeed, chassisAnimation.maxStretchingCoeff);
					rightTrack.AnimateWithAdditionalRays(transform, chassisAnimation.smoothSpeed, chassisAnimation.maxStretchingCoeff);
				}
				else
				{
					leftTrack.Animate(transform, chassisAnimation.smoothSpeed, chassisAnimation.maxStretchingCoeff);
					rightTrack.Animate(transform, chassisAnimation.smoothSpeed, chassisAnimation.maxStretchingCoeff);
				}
			}
		}

		[OnEventComplete]
		public void AnimateWheelsAndTracksRotation(TimeUpdateEvent evt, AliveChassisAnimationNode node)
		{
			if (node.cameraVisibleTrigger.IsVisibleAtRange(50f))
			{
				ChassisAnimationComponent chassisAnimation = node.chassisAnimation;
				TrackComponent track = node.track;
				TrackController leftTrack = node.chassisTrackController.LeftTrack;
				TrackController rightTrack = node.chassisTrackController.RightTrack;
				float maxSpeed = node.effectiveSpeed.MaxSpeed;
				float deltaTime = evt.DeltaTime;
				CalculateTrackAnimationSpeed(track.LeftTrack, node, maxSpeed, deltaTime);
				chassisAnimation.LeftTrackPosition += track.LeftTrack.animationSpeed * deltaTime * 0.5f;
				leftTrack.UpdateWheelsRotation(chassisAnimation.LeftTrackPosition);
				CalculateTrackAnimationSpeed(track.RightTrack, node, maxSpeed, deltaTime);
				chassisAnimation.RightTrackPosition += track.RightTrack.animationSpeed * deltaTime * 0.5f;
				rightTrack.UpdateWheelsRotation(chassisAnimation.RightTrackPosition);
				if (chassisAnimation.TracksMaterial != null)
				{
					float num = (0f - chassisAnimation.LeftTrackPosition) * chassisAnimation.tracksMaterialSpeedMultiplyer;
					float num2 = (0f - chassisAnimation.RightTrackPosition) * chassisAnimation.tracksMaterialSpeedMultiplyer;
					Vector2 vector = new Vector2(num % 1f, num2 % 1f);
					chassisAnimation.TracksMaterial.SetVector(TankMaterialPropertyNames.TRACKS_OFFSET, vector);
				}
			}
		}

		private void CalculateTrackAnimationSpeed(Track track, AliveChassisAnimationNode node, float maxSpeed, float dt)
		{
			if (HasCorrectContacts(track, node.rigidbody.Rigidbody))
			{
				AnimateTrackWithContacts(track, node, dt);
			}
			else
			{
				AnimateTrackWithoutContacts(track, node, maxSpeed, dt);
			}
		}

		private bool HasCorrectContacts(Track track, Rigidbody rigidbody)
		{
			if (track != null)
			{
				return rigidbody.transform.up.y > 0f && track.numContacts > 0;
			}
			return false;
		}

		private void AnimateTrackWithContacts(Track track, AliveChassisAnimationNode node, float dt)
		{
			ChassisComponent chassis = node.chassis;
			float forwardTrackSpeed = GetForwardTrackSpeed(track, node.rigidbody.Rigidbody);
			if (RequiresSynchronizedAnimation(track, chassis, forwardTrackSpeed))
			{
				track.animationSpeed = forwardTrackSpeed;
				return;
			}
			float targetValue = GetDesiredSpeedCoeff(track, chassis) * 0.05f;
			track.SetAnimationSpeed(targetValue, node.speed.Acceleration * dt);
		}

		private void AnimateTrackWithoutContacts(Track track, AliveChassisAnimationNode node, float maxSpeed, float dt)
		{
			float num = maxSpeed * node.chassis.EffectiveMoveAxis;
			float num2 = (0f - node.chassis.EffectiveTurnAxis) * maxSpeed / 2f * (float)track.side;
			float targetValue = Mathf.Clamp(num + num2, 0f - maxSpeed, maxSpeed);
			track.SetAnimationSpeed(targetValue, node.speed.Acceleration * dt);
		}

		private float GetForwardTrackSpeed(Track track, Rigidbody rigidbody)
		{
			Vector3 lhs = track.averageVelocity - track.averageSurfaceVelocity;
			return Vector3.Dot(lhs, rigidbody.transform.forward);
		}

		private bool RequiresSynchronizedAnimation(Track track, ChassisComponent chassis, float trackSpeed)
		{
			float desiredSpeedCoeff = GetDesiredSpeedCoeff(track, chassis);
			return Mathf.Abs(trackSpeed) > 0.0400000028f || desiredSpeedCoeff == 0f || MathUtil.SignEpsilon(trackSpeed, 0.01f) * MathUtil.Sign(desiredSpeedCoeff) == -1f;
		}

		private float GetDesiredSpeedCoeff(Track track, ChassisComponent chassis)
		{
			float effectiveMoveAxis = chassis.EffectiveMoveAxis;
			float effectiveTurnAxis = chassis.EffectiveTurnAxis;
			float num = 0f;
			if (effectiveMoveAxis == 0f)
			{
				return (float)track.side * effectiveTurnAxis * 0.5f;
			}
			if (effectiveTurnAxis == 0f)
			{
				return effectiveMoveAxis;
			}
			return effectiveMoveAxis * (3f + (float)track.side * effectiveTurnAxis) / 4f;
		}
	}
}
