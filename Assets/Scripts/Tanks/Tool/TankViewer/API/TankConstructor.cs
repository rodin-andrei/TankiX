using Tanks.Battle.ClientCore.Impl;
using Tanks.Battle.ClientGraphics.API;
using Tanks.Battle.ClientGraphics.Impl;
using UnityEngine;

namespace Tanks.Tool.TankViewer.API
{
	public class TankConstructor : MonoBehaviour
	{
		private GameObject hullInstance;

		private GameObject weaponInstance;

		private ColoringComponent coloring;

		public GameObject HullInstance
		{
			get
			{
				return hullInstance;
			}
		}

		public GameObject WeaponInstance
		{
			get
			{
				return weaponInstance;
			}
		}

		public void BuildTank(GameObject hull, GameObject weapon, ColoringComponent coloring)
		{
			CreateHull(hull);
			CreateWeapon(weapon);
			SetWeaponPosition();
			SetColoring(coloring);
		}

		private void CreateWeapon(GameObject weapon)
		{
			weaponInstance = Object.Instantiate(weapon);
			weaponInstance.transform.SetParent(base.transform, false);
			weapon.transform.localPosition = Vector3.zero;
			weapon.transform.localRotation = Quaternion.identity;
		}

		public void ChangeWeapon(GameObject weapon)
		{
			Object.Destroy(weaponInstance);
			CreateWeapon(weapon);
			SetWeaponPosition();
			SetColoring(coloring);
		}

		public void ChangeColoring(ColoringComponent coloring)
		{
			SetColoring(coloring);
		}

		public void ChangeHull(GameObject hull)
		{
			Object.Destroy(hullInstance);
			CreateHull(hull);
			SetWeaponPosition();
			SetColoring(coloring);
		}

		private void CreateHull(GameObject hull)
		{
			hullInstance = Object.Instantiate(hull);
			hullInstance.transform.SetParent(base.transform, false);
			hullInstance.transform.localPosition = Vector3.zero;
			hullInstance.transform.localRotation = Quaternion.identity;
		}

		private void SetWeaponPosition()
		{
			MountPointComponent component = hullInstance.GetComponent<MountPointComponent>();
			weaponInstance.transform.position = component.MountPoint.position;
		}

		private void SetColoring(ColoringComponent coloring)
		{
			this.coloring = coloring;
			TankMaterialsUtil.ApplyColoring(TankBuilderUtil.GetHullRenderer(hullInstance), coloring);
			TankMaterialsUtil.ApplyColoring(TankBuilderUtil.GetWeaponRenderer(weaponInstance), coloring);
		}
	}
}
