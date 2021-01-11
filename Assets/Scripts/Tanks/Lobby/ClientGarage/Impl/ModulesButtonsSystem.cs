using System.Collections.Generic;
using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientProfile.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModulesButtonsSystem : ECSSystem
	{
		public class EquipButtonNode : Node
		{
			public MountModuleButtonComponent mountModuleButton;
		}

		public class UpgradeButtonNode : Node
		{
			public UpgradeModuleButtonComponent upgradeModuleButton;
		}

		public class SelectedSlotNode : Node
		{
			public ToggleListItemComponent toggleListItem;

			public SlotUserItemInfoComponent slotUserItemInfo;

			public ToggleListSelectedItemComponent toggleListSelectedItem;
		}

		public class ModuleNode : Node
		{
			public ModuleItemComponent moduleItem;

			public ModuleCardsCompositionComponent moduleCardsComposition;
		}

		public class SelectedModuleNode : ModuleNode
		{
			public ToggleListSelectedItemComponent toggleListSelectedItem;

			public ModuleCardItemUIComponent moduleCardItemUi;

			public ModuleBehaviourTypeComponent moduleBehaviourType;
		}

		public class SelectedSlotWithModuleNode : SelectedSlotNode
		{
			public ModuleGroupComponent moduleGroup;
		}

		public class SelfUserMoneyNode : Node
		{
			public SelfUserComponent selfUser;

			public UserGroupComponent userGroup;

			public UserMoneyComponent userMoney;

			public UserXCrystalsComponent userXCrystals;
		}

		[OnEventFire]
		public void SelectedSlotWithModules(NodeAddedEvent e, SelectedSlotNode selectedSlot, SelectedModuleNode selectedModule, [JoinAll][Context] EquipButtonNode equipButton, [JoinAll] SelfUserMoneyNode selfUserMoney, [JoinAll] SingleNode<ModulesScreenUIComponent> screen)
		{
			UpdateButtons(screen.component, selectedSlot, selectedModule, equipButton, selfUserMoney);
		}

		[OnEventFire]
		public void OnModuleWasCrafted(ModuleAssembledEvent e, SelectedModuleNode module, [JoinAll] SelectedSlotNode selectedSlot, [JoinAll] EquipButtonNode equipButton, [JoinAll] SelfUserMoneyNode selfUserMoney, [JoinAll] SingleNode<ModulesScreenUIComponent> screen)
		{
			UpdateButtons(screen.component, selectedSlot, module, equipButton, selfUserMoney);
		}

		[OnEventFire]
		public void OnModuleWasUpgraded(ModuleUpgradedEvent e, SelectedModuleNode module, [JoinAll] SelectedSlotNode selectedSlot, [JoinAll] EquipButtonNode equipButton, [JoinAll] SelfUserMoneyNode selfUserMoney, [JoinAll] SingleNode<ModulesScreenUIComponent> screen)
		{
			UpdateButtons(screen.component, selectedSlot, module, equipButton, selfUserMoney);
		}

		private void UpdateButtons(ModulesScreenUIComponent screen, SelectedSlotNode selectedSlot, SelectedModuleNode selectedModule, EquipButtonNode equipButton, SelfUserMoneyNode selfUserMoney)
		{
			int slot = (int)selectedSlot.slotUserItemInfo.Slot;
			bool selectedModuleMounted = selectedSlot.Entity.HasComponent<ModuleGroupComponent>() && selectedModule.Entity.HasComponent<ModuleGroupComponent>() && selectedSlot.Entity.GetComponent<ModuleGroupComponent>().Key == selectedModule.Entity.GetComponent<ModuleGroupComponent>().Key;
			equipButton.mountModuleButton.SetEquipButtonState(slot, selectedModuleMounted);
			int level = selectedModule.moduleCardItemUi.Level;
			int cardsCount = selectedModule.moduleCardItemUi.CardsCount;
			int maxCardsCount = selectedModule.moduleCardItemUi.MaxCardsCount;
			List<ModulePrice> upgradePrices = selectedModule.moduleCardsComposition.UpgradePrices;
			int price = 0;
			int priceXCry = 0;
			if (level > -1 && level - 1 < upgradePrices.Count)
			{
				price = upgradePrices[level - 1].Crystals;
				priceXCry = upgradePrices[level - 1].XCrystals;
			}
			int userCryCount = (int)selfUserMoney.userMoney.Money;
			int userXCryCount = (int)selfUserMoney.userXCrystals.Money;
			equipButton.mountModuleButton.mountButtonActive = level != -1 && selectedSlot.slotUserItemInfo.ModuleBehaviourType == selectedModule.moduleBehaviourType.Type;
			UpgradeModuleBaseButtonComponent[] componentsInChildren = screen.GetComponentsInChildren<UpgradeModuleBaseButtonComponent>(true);
			foreach (UpgradeModuleBaseButtonComponent upgradeModuleBaseButtonComponent in componentsInChildren)
			{
				upgradeModuleBaseButtonComponent.Setup(level, cardsCount, maxCardsCount, price, priceXCry, userCryCount, userXCryCount);
			}
		}

		[OnEventFire]
		public void ModuleMounted(NodeAddedEvent e, SelectedSlotWithModuleNode selectedSlotWithModule, [JoinAll] SelectedModuleNode selectedModule, [JoinAll] EquipButtonNode equipButton)
		{
			int slot = (int)selectedSlotWithModule.slotUserItemInfo.Slot;
			equipButton.mountModuleButton.SetEquipButtonState(slot, true);
		}

		[OnEventFire]
		public void ModuleUnmounted(NodeRemoveEvent e, SelectedSlotWithModuleNode selectedSlotWithModule, [JoinAll] SelectedModuleNode selectedModule, [JoinAll] EquipButtonNode equipButton)
		{
			int slot = (int)selectedSlotWithModule.slotUserItemInfo.Slot;
			equipButton.mountModuleButton.SetEquipButtonState(slot, false);
		}
	}
}
