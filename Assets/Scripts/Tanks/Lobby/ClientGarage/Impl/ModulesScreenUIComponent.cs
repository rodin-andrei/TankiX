using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModulesScreenUIComponent : BehaviourComponent
	{
		[SerializeField]
		private SlotUIComponent[] slots;

		[SerializeField]
		private CanvasGroup turretSlots;

		[SerializeField]
		private CanvasGroup hullSlots;

		[SerializeField]
		private ModuleCardItemUIComponent moduleCardItemUiComponentPrefab;

		[SerializeField]
		private ModuleCardsTierUI[] tiersUi;

		[SerializeField]
		private TextMeshProUGUI moduleName;

		[SerializeField]
		private TextMeshProUGUI moduleDesc;

		[SerializeField]
		private TextMeshProUGUI moduleFlavorText;

		[SerializeField]
		private ImageSkin moduleIcon;

		[SerializeField]
		private TextMeshProUGUI tankPartItemName;

		[SerializeField]
		private TextMeshProUGUI moduleTypeName;

		[SerializeField]
		private TextMeshProUGUI currentUpgradeLevel;

		[SerializeField]
		private TextMeshProUGUI nextUpgradeLevel;

		[SerializeField]
		private TextMeshProUGUI upgradeTitle;

		[SerializeField]
		private LocalizedField activeType;

		[SerializeField]
		private LocalizedField passiveType;

		[SerializeField]
		private LocalizedField upgradeLevel;

		[SerializeField]
		private LocalizedField hullHealth;

		[SerializeField]
		private LocalizedField turretDamage;

		[SerializeField]
		private ModulesPropertiesUIComponent modulesProperties;

		[SerializeField]
		private TankPartItemPropertiesUIComponent tankPartItemPropertiesUI;

		[SerializeField]
		private TutorialShowTriggerComponent upgradeModuleTrigger;

		private TankPartItem currentTankPartItem;

		public Action onEanble;

		public string HullHealth
		{
			get
			{
				return hullHealth.Value;
			}
		}

		public string TurretDamage
		{
			get
			{
				return turretDamage.Value;
			}
		}

		public TankPartItem CurrentTankPartItem
		{
			get
			{
				return currentTankPartItem;
			}
		}

		public ModulesPropertiesUIComponent ModulesProperties
		{
			get
			{
				return modulesProperties;
			}
		}

		public string ModuleName
		{
			set
			{
				moduleName.text = value;
			}
		}

		public string ModuleDesc
		{
			set
			{
				moduleDesc.text = value;
			}
		}

		public string ModuleFlavorText
		{
			set
			{
				moduleFlavorText.text = value;
			}
		}

		public bool ModuleActive
		{
			set
			{
				moduleTypeName.text = ((!value) ? passiveType.Value : activeType.Value);
			}
		}

		public string ModuleIconUID
		{
			set
			{
				moduleIcon.SpriteUid = value;
			}
		}

		public int CurrentUpgradeLevel
		{
			set
			{
				currentUpgradeLevel.text = upgradeLevel.Value + " " + value;
				currentUpgradeLevel.gameObject.SetActive(value >= 0);
				upgradeTitle.text = ((value >= 0) ? (upgradeLevel.Value + " " + value) : string.Empty);
			}
		}

		public int NextUpgradeLevel
		{
			set
			{
				nextUpgradeLevel.text = upgradeLevel.Value + " " + value;
				nextUpgradeLevel.gameObject.SetActive(value >= 0);
			}
		}

		public SlotUIComponent GetSlot(Slot slot)
		{
			return slots[(uint)slot];
		}

		private void Reset()
		{
			tiersUi = GetComponentsInChildren<ModuleCardsTierUI>();
		}

		public void SetItem(TankPartItem item)
		{
			currentTankPartItem = item;
			tankPartItemName.text = item.Name;
			FilterSlots();
		}

		public void FilterSlots()
		{
			SwitchSlots(turretSlots, currentTankPartItem.Type == TankPartItem.TankPartItemType.Turret);
			SwitchSlots(hullSlots, currentTankPartItem.Type == TankPartItem.TankPartItemType.Hull);
			int num = ((currentTankPartItem.Type != 0) ? 3 : 0);
			ToggleListItemComponent component = slots[num].GetComponent<ToggleListItemComponent>();
			component.Toggle.isOn = true;
		}

		private void SwitchSlots(CanvasGroup slots, bool isOn)
		{
			slots.interactable = isOn;
			slots.alpha = ((!isOn) ? 0f : 1f);
			slots.blocksRaycasts = isOn;
		}

		public void AddCard(Entity entity)
		{
			int tierNumber = entity.GetComponent<ModuleTierComponent>().TierNumber;
			tierNumber = Mathf.Min(tierNumber, tiersUi.Length - 1);
			ModuleCardItemUIComponent moduleCardItemUIComponent = UnityEngine.Object.Instantiate(moduleCardItemUiComponentPrefab);
			tiersUi[tierNumber].AddCard(moduleCardItemUIComponent);
			if (entity.HasComponent<ModuleCardItemUIComponent>())
			{
				entity.RemoveComponent<ModuleCardItemUIComponent>();
			}
			if (entity.HasComponent<ToggleListItemComponent>())
			{
				entity.RemoveComponent<ToggleListItemComponent>();
			}
			entity.AddComponent(moduleCardItemUIComponent);
			entity.AddComponent(moduleCardItemUIComponent.GetComponent<ToggleListItemComponent>());
		}

		public ModuleCardItemUIComponent GetCard(long marketItemGroupId)
		{
			ModuleCardsTierUI[] array = tiersUi;
			foreach (ModuleCardsTierUI moduleCardsTierUI in array)
			{
				ModuleCardItemUIComponent card = moduleCardsTierUI.GetCard(marketItemGroupId);
				if (card != null)
				{
					return card;
				}
			}
			return null;
		}

		public void FilterCards(Entity mountedModule, ModuleBehaviourType slotType)
		{
			if (currentTankPartItem == null)
			{
				return;
			}
			ModuleCardItemUIComponent[] componentsInChildren = GetComponentsInChildren<ModuleCardItemUIComponent>(true);
			bool flag = false;
			ModuleCardItemUIComponent[] array = componentsInChildren;
			foreach (ModuleCardItemUIComponent moduleCardItemUIComponent in array)
			{
				if (moduleCardItemUIComponent.gameObject.activeSelf && moduleCardItemUIComponent.GetComponent<ToggleListItemComponent>().Toggle.isOn)
				{
					flag = moduleCardItemUIComponent.Type == slotType && ((moduleCardItemUIComponent.TankPart == TankPartModuleType.WEAPON && currentTankPartItem.Type == TankPartItem.TankPartItemType.Turret) || (moduleCardItemUIComponent.TankPart == TankPartModuleType.TANK && currentTankPartItem.Type == TankPartItem.TankPartItemType.Hull));
					break;
				}
			}
			ModuleCardItemUIComponent[] array2 = componentsInChildren;
			foreach (ModuleCardItemUIComponent moduleCardItemUIComponent2 in array2)
			{
				bool flag2 = (moduleCardItemUIComponent2.TankPart == TankPartModuleType.WEAPON && currentTankPartItem.Type == TankPartItem.TankPartItemType.Turret) || (moduleCardItemUIComponent2.TankPart == TankPartModuleType.TANK && currentTankPartItem.Type == TankPartItem.TankPartItemType.Hull);
				moduleCardItemUIComponent2.gameObject.SetActive(flag2);
				if (flag2 && ((mountedModule != null && moduleCardItemUIComponent2.ModuleEntity == mountedModule) || (mountedModule == null && !flag && moduleCardItemUIComponent2.Type == slotType)))
				{
					moduleCardItemUIComponent2.GetComponent<ToggleListItemComponent>().Toggle.isOn = true;
					flag = true;
				}
			}
			upgradeModuleTrigger.Triggered();
		}

		private void OnEnable()
		{
			if (onEanble != null)
			{
				onEanble();
			}
		}

		public void Clear()
		{
			ModuleCardsTierUI[] array = tiersUi;
			foreach (ModuleCardsTierUI moduleCardsTierUI in array)
			{
				moduleCardsTierUI.Clear();
			}
		}

		public void ShowTankItemStat(float tankCoef, float weaponCoef, float tankCoefWithSelected, float weaponCoefWithSelected)
		{
			if (currentTankPartItem.Type == TankPartItem.TankPartItemType.Hull)
			{
				tankPartItemPropertiesUI.Show(currentTankPartItem, tankCoef, tankCoefWithSelected);
			}
			else
			{
				tankPartItemPropertiesUI.Show(currentTankPartItem, weaponCoef, weaponCoefWithSelected);
			}
		}
	}
}
