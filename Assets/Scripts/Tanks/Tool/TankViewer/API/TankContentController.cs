using Tanks.Battle.ClientGraphics.Impl;
using UnityEngine;

namespace Tanks.Tool.TankViewer.API
{
	public class TankContentController : MonoBehaviour
	{
		private int weaponIndex;

		private int hullIndex;

		private int coloringIndex;

		public TankContentLibrary tankContentLibrary;

		public TankConstructor tankConstructor;

		public string CurrentHullName
		{
			get
			{
				return tankContentLibrary.hullList[hullIndex].name;
			}
		}

		public string CurrentWeaponName
		{
			get
			{
				return tankContentLibrary.weaponList[weaponIndex].name;
			}
		}

		public void Init()
		{
			GameObject hull = tankContentLibrary.hullList[hullIndex];
			GameObject weapon = tankContentLibrary.weaponList[weaponIndex];
			ColoringComponent coloring = tankContentLibrary.coloringList[coloringIndex];
			tankConstructor.BuildTank(hull, weapon, coloring);
		}

		public void SetNextWeapon()
		{
			weaponIndex = getNextIndex(weaponIndex, tankContentLibrary.weaponList.Count);
			tankConstructor.ChangeWeapon(tankContentLibrary.weaponList[weaponIndex]);
		}

		public void SetPrevWeapon()
		{
			weaponIndex = getPrevIndex(weaponIndex, tankContentLibrary.weaponList.Count);
			tankConstructor.ChangeWeapon(tankContentLibrary.weaponList[weaponIndex]);
		}

		public void SetNextColoring()
		{
			coloringIndex = getNextIndex(coloringIndex, tankContentLibrary.coloringList.Count);
			tankConstructor.ChangeColoring(tankContentLibrary.coloringList[coloringIndex]);
		}

		public void SetPrevColoring()
		{
			coloringIndex = getPrevIndex(coloringIndex, tankContentLibrary.coloringList.Count);
			tankConstructor.ChangeColoring(tankContentLibrary.coloringList[coloringIndex]);
		}

		public void SetNextHull()
		{
			hullIndex = getNextIndex(hullIndex, tankContentLibrary.hullList.Count);
			tankConstructor.ChangeHull(tankContentLibrary.hullList[hullIndex]);
		}

		public void SetPrevHull()
		{
			hullIndex = getPrevIndex(hullIndex, tankContentLibrary.hullList.Count);
			tankConstructor.ChangeHull(tankContentLibrary.hullList[hullIndex]);
		}

		private int getNextIndex(int currentIndex, int length)
		{
			return (currentIndex < length - 1) ? (currentIndex + 1) : 0;
		}

		private int getPrevIndex(int currentIndex, int length)
		{
			return (currentIndex <= 0) ? (length - 1) : (currentIndex - 1);
		}

		public void ChangeVisibleParts()
		{
			GameObject hullInstance = tankConstructor.HullInstance;
			GameObject weaponInstance = tankConstructor.WeaponInstance;
			if (hullInstance.activeSelf && weaponInstance.activeSelf)
			{
				hullInstance.SetActive(false);
			}
			else if (weaponInstance.activeSelf)
			{
				hullInstance.SetActive(true);
				weaponInstance.SetActive(false);
			}
			else if (hullInstance.activeSelf)
			{
				hullInstance.SetActive(true);
				weaponInstance.SetActive(true);
			}
		}

		public void SetVisible(bool visible)
		{
			tankConstructor.HullInstance.SetActive(visible);
			tankConstructor.WeaponInstance.SetActive(visible);
		}

		public bool IsHullVisible()
		{
			return tankConstructor.HullInstance.activeSelf;
		}

		public bool IsWeaponVisible()
		{
			return tankConstructor.WeaponInstance.activeSelf;
		}

		public ColoringComponent getCurrentColoring()
		{
			return tankContentLibrary.coloringList[coloringIndex];
		}
	}
}
