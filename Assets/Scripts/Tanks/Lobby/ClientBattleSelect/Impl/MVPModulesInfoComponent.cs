using System.Collections;
using System.Collections.Generic;
using Platform.Kernel.OSGi.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Lobby.ClientGarage.API;
using tanks.modules.lobby.ClientGarage.Scripts.API.UI.Items;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class MVPModulesInfoComponent : MonoBehaviour
	{
		private class ModuleComparer : IComparer<ModuleInfo>
		{
			public int Compare(ModuleInfo x, ModuleInfo y)
			{
				ModuleItem item = GarageItemsRegistry.GetItem<ModuleItem>(x.ModuleId);
				ModuleItem item2 = GarageItemsRegistry.GetItem<ModuleItem>(y.ModuleId);
				if (item.TankPartModuleType == item2.TankPartModuleType)
				{
					return 0;
				}
				if (item.TankPartModuleType == TankPartModuleType.WEAPON)
				{
					return -1;
				}
				return 1;
			}
		}

		[SerializeField]
		private MVPModuleContainer moduleContainerPrefab;

		[SerializeField]
		private float moduleAnimationDelay = 0.2f;

		private float moduleSize = 160f;

		private bool animated;

		[Inject]
		public static GarageItemsRegistry GarageItemsRegistry
		{
			get;
			set;
		}

		[ContextMenu("Animate cards")]
		public void AnimateCards()
		{
			StartCoroutine(AnimateCards(GetComponentsInChildren<MVPModuleContainer>()));
		}

		private IEnumerator AnimateCards(MVPModuleContainer[] cards)
		{
			foreach (MVPModuleContainer module in cards)
			{
				if (module == null)
				{
					yield break;
				}
				module.GetComponent<Animator>().SetBool("active", true);
				yield return new WaitForSeconds(moduleAnimationDelay);
			}
			yield return null;
		}

		public void Set(List<ModuleInfo> modules)
		{
			animated = false;
			for (int i = 0; i < base.transform.childCount; i++)
			{
				Object.Destroy(base.transform.GetChild(i).gameObject);
			}
			List<ModuleInfo> modulesByBehaviourType = GetModulesByBehaviourType(modules, ModuleBehaviourType.ACTIVE);
			List<ModuleInfo> modulesByBehaviourType2 = GetModulesByBehaviourType(modules, ModuleBehaviourType.PASSIVE);
			modulesByBehaviourType.ForEach(delegate(ModuleInfo m)
			{
				addModule(m);
			});
			modulesByBehaviourType2.ForEach(delegate(ModuleInfo m)
			{
				addModule(m);
			});
		}

		private void addModule(ModuleInfo m)
		{
			ModuleItem item = GarageItemsRegistry.GetItem<ModuleItem>(m.ModuleId);
			if (item.IsMutable())
			{
				MVPModuleContainer mVPModuleContainer = Object.Instantiate(moduleContainerPrefab, base.transform);
				mVPModuleContainer.SetupModuleCard(m, moduleSize);
			}
		}

		private List<ModuleInfo> GetModulesByBehaviourType(List<ModuleInfo> modules, ModuleBehaviourType type)
		{
			List<ModuleInfo> res = new List<ModuleInfo>();
			modules.ForEach(delegate(ModuleInfo m)
			{
				ModuleItem item = GarageItemsRegistry.GetItem<ModuleItem>(m.ModuleId);
				if (item.ModuleBehaviourType == type)
				{
					res.Add(m);
				}
			});
			res.Sort(new ModuleComparer());
			return res;
		}
	}
}
