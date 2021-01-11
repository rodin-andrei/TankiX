using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModuleTooltipContent : MonoBehaviour, ITooltipContent
	{
		[SerializeField]
		private TextMeshProUGUI title;

		[SerializeField]
		private TextMeshProUGUI description;

		[SerializeField]
		private TextMeshProUGUI upgradeLevel;

		[SerializeField]
		private LocalizedField upgradeLevelLocalization;

		[SerializeField]
		private TextMeshProUGUI currentLevel;

		[SerializeField]
		private TextMeshProUGUI nextLevel;

		private int UpgradeLevel
		{
			set
			{
				upgradeLevel.gameObject.SetActive(value > 0);
				upgradeLevel.text = upgradeLevelLocalization.Value + " " + value;
			}
		}

		private int CurrentLevel
		{
			set
			{
				currentLevel.gameObject.SetActive(value != -1);
				currentLevel.text = upgradeLevelLocalization.Value + " " + value;
			}
		}

		private int NextLevel
		{
			set
			{
				nextLevel.gameObject.SetActive(value != -1);
				nextLevel.text = upgradeLevelLocalization.Value + " " + value;
			}
		}

		public void Init(object data)
		{
			ModuleTooltipData moduleTooltipData = data as ModuleTooltipData;
			title.text = moduleTooltipData.name;
			description.text = moduleTooltipData.desc;
			UpgradeLevel = moduleTooltipData.upgradeLevel + 1;
			ModulesPropertiesUIComponent component = GetComponent<ModulesPropertiesUIComponent>();
			if (moduleTooltipData.upgradeLevel == -1 || moduleTooltipData.upgradeLevel == moduleTooltipData.maxLevel)
			{
				int num3 = (CurrentLevel = (NextLevel = -1));
			}
			else
			{
				CurrentLevel = moduleTooltipData.upgradeLevel + 1;
				NextLevel = moduleTooltipData.upgradeLevel + 2;
			}
			for (int i = 0; i < moduleTooltipData.properties.Count; i++)
			{
				ModuleVisualProperty moduleVisualProperty = moduleTooltipData.properties[i];
				if (moduleVisualProperty.Upgradable && moduleTooltipData.upgradeLevel != moduleTooltipData.maxLevel && moduleTooltipData.upgradeLevel != -1)
				{
					float minValue = 0f;
					float maxValue = moduleVisualProperty.CalculateModuleEffectPropertyValue(moduleTooltipData.maxLevel, moduleTooltipData.maxLevel);
					float currentValue = ((moduleTooltipData.upgradeLevel == -1) ? 0f : moduleVisualProperty.CalculateModuleEffectPropertyValue(moduleTooltipData.upgradeLevel, moduleTooltipData.maxLevel));
					float nextValue = moduleVisualProperty.CalculateModuleEffectPropertyValue(moduleTooltipData.upgradeLevel + 1, moduleTooltipData.maxLevel);
					component.AddProperty(moduleVisualProperty.Name, moduleVisualProperty.Unit, minValue, maxValue, currentValue, nextValue, moduleVisualProperty.Format);
				}
				else if (moduleTooltipData.upgradeLevel == -1)
				{
					float currentValue2 = moduleVisualProperty.CalculateModuleEffectPropertyValue(0, moduleTooltipData.maxLevel);
					component.AddProperty(moduleVisualProperty.Name, moduleVisualProperty.Unit, currentValue2, moduleVisualProperty.Format);
				}
				else
				{
					float currentValue3 = moduleVisualProperty.CalculateModuleEffectPropertyValue(moduleTooltipData.upgradeLevel, moduleTooltipData.maxLevel);
					component.AddProperty(moduleVisualProperty.Name, moduleVisualProperty.Unit, currentValue3, moduleVisualProperty.Format);
				}
			}
		}
	}
}
