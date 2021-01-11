using System.Collections.Generic;
using Platform.Kernel.OSGi.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientGarage.Impl;
using tanks.modules.lobby.ClientGarage.Scripts.API.UI.Items;
using TMPro;
using UnityEngine;

namespace Tanks.Battle.ClientBattleSelect.Impl
{
	public class TankPartInfoComponent : MonoBehaviour
	{
		[SerializeField]
		private UpgradeStars stars;

		[SerializeField]
		private TextMeshProUGUI title;

		[SerializeField]
		private TextMeshProUGUI icon;

		[SerializeField]
		private TextMeshProUGUI mainValue;

		[SerializeField]
		private TextMeshProUGUI additionalValue;

		[SerializeField]
		private TankPartModuleType tankPartType;

		[Inject]
		public static GarageItemsRegistry GarageItemsRegistry
		{
			get;
			set;
		}

		public void Set(long id, List<ModuleInfo> modules, ModuleUpgradablePowerConfigComponent moduleConfig)
		{
			List<int[]> modulesParams = PrepareModules(modules);
			int slotCount = 3;
			float num = TankUpgradeUtils.CalculateUpgradeCoeff(modulesParams, slotCount, moduleConfig);
			stars.SetPower(num);
			TankPartItem item = GarageItemsRegistry.GetItem<TankPartItem>(id);
			icon.text = "<sprite name=\"" + id + "\">";
			title.text = item.Name;
			VisualProperty visualProperty = item.Properties[0];
			mainValue.text = visualProperty.InitialValue.ToString();
			if (num > 0f)
			{
				additionalValue.text = "+ " + (visualProperty.GetValue(num) - visualProperty.InitialValue).ToString("0");
			}
			else
			{
				additionalValue.text = string.Empty;
			}
		}

		private List<int[]> PrepareModules(List<ModuleInfo> modules)
		{
			List<int[]> res = new List<int[]>();
			modules.ForEach(delegate(ModuleInfo m)
			{
				ModuleItem item = GarageItemsRegistry.GetItem<ModuleItem>(m.ModuleId);
				if (item.TankPartModuleType == tankPartType)
				{
					int[] item2 = new int[2]
					{
						item.TierNumber,
						(int)m.UpgradeLevel
					};
					res.Add(item2);
				}
			});
			return res;
		}
	}
}
