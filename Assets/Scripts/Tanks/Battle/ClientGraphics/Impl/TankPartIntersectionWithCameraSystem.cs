using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Battle.ClientGraphics.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TankPartIntersectionWithCameraSystem : ECSSystem
	{
		public class CameraNode : Node
		{
			public BattleCameraComponent battleCamera;

			public CameraRootTransformComponent cameraRootTransform;

			public CameraComponent camera;
		}

		public class TankNode : Node
		{
			public AssembledTankInactiveStateComponent assembledTankInactiveState;

			public TankVisualRootComponent tankVisualRoot;

			public TankGroupComponent tankGroup;
		}

		public class WeaponNode : Node
		{
			public WeaponComponent weapon;

			public WeaponInstanceComponent weaponInstance;

			public WeaponVisualRootComponent weaponVisualRoot;

			public TankGroupComponent tankGroup;
		}

		public class TankPartIntersectionWithCameraMapVisibleNode : Node
		{
			public TankComponent tank;

			public TankPartIntersectionWithCameraMapComponent tankPartIntersectionWithCameraMap;

			public CameraVisibleTriggerComponent cameraVisibleTrigger;
		}

		[OnEventFire]
		public void InitCollidersForChecking(NodeAddedEvent evt, TankNode tank, [Context][JoinByTank] WeaponNode weapon)
		{
			VisualTriggerMarkerComponent visualTriggerMarker = tank.tankVisualRoot.VisualTriggerMarker;
			VisualTriggerMarkerComponent visualTriggerMarker2 = weapon.weaponVisualRoot.VisualTriggerMarker;
			TankPartIntersectionWithCameraData[] array = new TankPartIntersectionWithCameraData[2];
			AttachColliderToIntersectionMap(visualTriggerMarker, tank.Entity, array, 0);
			AttachColliderToIntersectionMap(visualTriggerMarker2, weapon.Entity, array, 1);
			tank.Entity.AddComponent(new TankPartIntersectionWithCameraMapComponent(array));
		}

		private void AttachColliderToIntersectionMap(VisualTriggerMarkerComponent trigger, Entity entity, TankPartIntersectionWithCameraData[] map, int index)
		{
			MeshCollider visualTriggerMeshCollider = trigger.VisualTriggerMeshCollider;
			map[index] = new TankPartIntersectionWithCameraData(visualTriggerMeshCollider, entity);
			entity.AddComponent<TankPartNotIntersectedWithCameraStateComponent>();
		}

		[OnEventFire]
		public void CheckCameraVisualIntersection(EarlyUpdateEvent evt, TankPartIntersectionWithCameraMapVisibleNode tank, [JoinAll] CameraNode camera)
		{
			CheckCameraVisualIntersection(tank, camera);
		}

		[OnEventFire]
		public void ResetState(NodeRemoveEvent evt, TankPartIntersectionWithCameraMapVisibleNode tank)
		{
			TankPartIntersectionWithCameraData[] tankPartIntersectionMap = tank.tankPartIntersectionWithCameraMap.TankPartIntersectionMap;
			int num = tankPartIntersectionMap.Length;
			for (int i = 0; i < num; i++)
			{
				TankPartIntersectionWithCameraData tankPartIntersectionWithCameraData = tankPartIntersectionMap[i];
				Entity entity = tankPartIntersectionWithCameraData.entity;
				UpdateState(entity, false);
			}
		}

		private void CheckCameraVisualIntersection(TankPartIntersectionWithCameraMapVisibleNode tank, CameraNode camera)
		{
			Vector3 position = camera.cameraRootTransform.Root.position;
			TankPartIntersectionWithCameraData[] tankPartIntersectionMap = tank.tankPartIntersectionWithCameraMap.TankPartIntersectionMap;
			int num = tankPartIntersectionMap.Length;
			for (int i = 0; i < num; i++)
			{
				TankPartIntersectionWithCameraData tankPartIntersectionWithCameraData = tankPartIntersectionMap[i];
				Collider collider = tankPartIntersectionWithCameraData.collider;
				Entity entity = tankPartIntersectionWithCameraData.entity;
				bool hasIntersection = CheckPointInsideCollider(position, collider);
				UpdateState(entity, hasIntersection);
			}
		}

		private void UpdateState(Entity tankPart, bool hasIntersection)
		{
			if (!hasIntersection)
			{
				if (tankPart.HasComponent<TankPartIntersectedWithCameraStateComponent>())
				{
					tankPart.RemoveComponent<TankPartIntersectedWithCameraStateComponent>();
					tankPart.AddComponent<TankPartNotIntersectedWithCameraStateComponent>();
				}
			}
			else if (tankPart.HasComponent<TankPartNotIntersectedWithCameraStateComponent>())
			{
				tankPart.RemoveComponent<TankPartNotIntersectedWithCameraStateComponent>();
				tankPart.AddComponent<TankPartIntersectedWithCameraStateComponent>();
			}
		}

		private bool CheckPointInsideCollider(Vector3 cameraPos, Collider collider)
		{
			if (!collider.bounds.Contains(cameraPos))
			{
				return false;
			}
			return MakeDeepIntersectionTest(cameraPos, collider);
		}

		private bool MakeDeepIntersectionTest(Vector3 cameraPos, Collider collider)
		{
			Vector3 center = collider.bounds.center;
			Vector3 vector = center - cameraPos;
			RaycastHit hitInfo;
			return !collider.Raycast(new Ray(cameraPos, vector.normalized), out hitInfo, vector.magnitude);
		}
	}
}
