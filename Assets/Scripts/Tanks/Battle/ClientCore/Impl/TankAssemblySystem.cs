using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class TankAssemblySystem : ECSSystem
	{
		public class TankNode : Node
		{
			public TankGroupComponent tankGroup;

			public TankCommonInstanceComponent tankCommonInstance;

			public HullInstanceComponent hullInstance;

			public MountPointComponent mountPoint;

			public TankPartPaintInstanceComponent tankPartPaintInstance;
		}

		public class WeaponNode : Node
		{
			public TankGroupComponent tankGroup;

			public WeaponInstanceComponent weaponInstance;

			public TankPartPaintInstanceComponent tankPartPaintInstance;
		}

		public class AssembledActivationTankNode : Node
		{
			public TankGroupComponent tankGroup;

			public BattleGroupComponent battleGroup;

			public UserGroupComponent userGroup;

			public AssembledTankComponent assembledTank;

			public TankCommonInstanceComponent tankCommonInstance;

			public HullInstanceComponent hullInstance;

			public MountPointComponent mountPoint;

			public TankPartPaintInstanceComponent tankPartPaintInstance;

			public AssembledTankInactiveStateComponent assembledTankInactiveState;
		}

		public class AssembledTankNode : Node
		{
			public TankGroupComponent tankGroup;

			public AssembledTankComponent assembledTank;

			public HullInstanceComponent hullInstance;
		}

		public class ActivatedAssembledTankNode : Node
		{
			public AssembledTankActivatedStateComponent assembledTankActivatedState;

			public AssembledTankComponent assembledTank;

			public TankGroupComponent tankGroup;

			public RigidbodyComponent rigidbody;

			public TankVisualRootComponent tankVisualRoot;
		}

		public class TankIncarnationNode : Node
		{
			public TankClientIncarnationComponent tankClientIncarnation;

			public TankGroupComponent tankGroup;
		}

		public class WeaponTankPartNode : Node
		{
			public WeaponInstanceComponent weaponInstance;

			public TankPartComponent tankPart;
		}

		[OnEventComplete]
		public void AssembleTank(NodeAddedEvent e, TankNode tank, [Context][JoinByTank] WeaponNode weapon)
		{
			GameObject gameObject = new GameObject("Tank " + tank.hullInstance.HullInstance.name + "/" + weapon.weaponInstance.WeaponInstance.name);
			Transform transform = weapon.weaponInstance.WeaponInstance.transform;
			Transform mountPoint = tank.mountPoint.MountPoint;
			Transform transform3 = (transform.parent = tank.hullInstance.HullInstance.transform);
			UnityUtil.InheritAndEmplace(tank.tankCommonInstance.TankCommonInstance.transform, transform3);
			tank.tankPartPaintInstance.PaintInstance.transform.parent = transform3;
			transform3.parent = gameObject.transform;
			transform.SetParent(mountPoint, false);
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			gameObject.SetActive(false);
			tank.Entity.AddComponent(new AssembledTankComponent(gameObject));
		}

		[OnEventComplete]
		public void ActivateAssembledTank(NodeAddedEvent e, AssembledActivationTankNode tank, [JoinByTank] WeaponNode weapon)
		{
			tank.assembledTank.AssemblyRoot.SetActive(true);
			tank.hullInstance.HullInstance.SetActive(true);
			weapon.weaponInstance.WeaponInstance.SetActive(true);
			tank.Entity.RemoveComponent<AssembledTankInactiveStateComponent>();
			tank.Entity.AddComponent<AssembledTankActivatedStateComponent>();
		}

		[OnEventFire]
		public void AddTargetBehaviour(NodeAddedEvent e, ActivatedAssembledTankNode activatedTank)
		{
			activatedTank.tankVisualRoot.gameObject.AddComponent<TargetBehaviour>();
			activatedTank.rigidbody.Rigidbody.gameObject.AddComponent<TargetBehaviour>();
		}

		[OnEventComplete]
		public void ConfigureTargetBehaviour(NodeAddedEvent e, TankIncarnationNode tankIncarnation, [JoinByTank][Context] ActivatedAssembledTankNode activatedTank)
		{
			activatedTank.tankVisualRoot.gameObject.GetComponent<TargetBehaviour>().Init(activatedTank.Entity, tankIncarnation.Entity);
			activatedTank.rigidbody.Rigidbody.gameObject.GetComponent<TargetBehaviour>().Init(activatedTank.Entity, tankIncarnation.Entity);
		}

		[OnEventComplete]
		public void DestroyTank(NodeRemoveEvent e, AssembledTankNode tank)
		{
			UnityUtil.Destroy(tank.hullInstance.HullInstance);
			UnityUtil.Destroy(tank.assembledTank.AssemblyRoot);
		}

		[OnEventComplete]
		public void DestroyTankHullIfTankNotAssembled(NodeRemoveEvent e, SingleNode<HullInstanceComponent> tank)
		{
			if (!tank.Entity.HasComponent<AssembledTankComponent>())
			{
				GameObject hullInstance = tank.component.HullInstance;
				UnityUtil.Destroy(hullInstance);
			}
		}

		[OnEventComplete]
		public void DestroyTankWeaponIfTankNotAssembled(NodeRemoveEvent e, SingleNode<HullInstanceComponent> tank, [JoinByUser] WeaponTankPartNode weapon)
		{
			if (!tank.Entity.HasComponent<AssembledTankComponent>())
			{
				GameObject weaponInstance = weapon.weaponInstance.WeaponInstance;
				if ((bool)weaponInstance)
				{
					Object.Destroy(weaponInstance);
				}
			}
		}
	}
}
