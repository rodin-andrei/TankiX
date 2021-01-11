using System;
using System.Collections.Generic;
using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientProfile.Impl;
using tanks.modules.lobby.ClientGarage.Scripts.API.UI.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class NewModulesScreenUIComponent : BehaviourComponent
	{
		public static float OVER_SCREEN_Z_OFFSET = -0.054f;

		[SerializeField]
		private LocalizedField hullHealth;

		[SerializeField]
		private LocalizedField turretDamage;

		[SerializeField]
		private LocalizedField level;

		[SerializeField]
		private PresetsDropDownList presetsDropDownList;

		public List<List<int>> level2PowerByTier;

		public XCrystalsIndicatorComponent xCrystalButton;

		public CrystalsIndicatorComponent crystalButton;

		public TankPartCollectionView turretCollectionView;

		public TankPartCollectionView hullCollectionView;

		public CollectionView collectionView;

		public Button backButton;

		public SelectedModuleView selectedModuleView;

		public GameObject background;

		public DragAndDropController dragAndDropController;

		public GameObject slotItemPrefab;

		public static Dictionary<ModuleItem, SlotItemView> slotItems = new Dictionary<ModuleItem, SlotItemView>();

		public static ModuleScreenSelection selection;

		public TankPartModeController tankPartModeController;

		public Action OnShowAnimationFinishedAction;

		public bool showAnimationFinished;

		private ModuleItem selectedModule;

		private bool needUpdate;

		[Inject]
		public static GarageItemsRegistry GarageItemsRegistry
		{
			get;
			set;
		}

		public TankPartItem Weapon
		{
			get;
			set;
		}

		public TankPartItem Tank
		{
			get;
			set;
		}

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

		public string Level
		{
			get
			{
				return level.Value;
			}
		}

		public ModuleItem SelectedModule
		{
			get
			{
				return selectedModule;
			}
		}

		public void Awake()
		{
			ModuleScreenSelection moduleScreenSelection = new ModuleScreenSelection();
			moduleScreenSelection.onSelectionChange = OnSelectionChange;
			selection = moduleScreenSelection;
			tankPartModeController = new TankPartModeController(turretCollectionView, hullCollectionView, collectionView);
			tankPartModeController.onModeChange = OnTankPartModeChange;
			if (CollectionView.slots != null)
			{
				CollectionView.slots.Clear();
				CollectionView.slots = null;
			}
			if (slotItems != null)
			{
				slotItems.Clear();
			}
			collectionView.UpdateView();
			Dictionary<ModuleItem, CollectionSlotView>.ValueCollection values = CollectionView.slots.Values;
			foreach (CollectionSlotView item in values)
			{
				item.onDoubleClick = (Action<CollectionSlotView>)Delegate.Combine(item.onDoubleClick, new Action<CollectionSlotView>(OnCollectionSlotDoubleClick));
			}
			backButton.onClick.AddListener(Hide);
			selectedModule = null;
		}

		private void OnTankPartModeChange()
		{
			selection.Clear();
		}

		public void Show(TankPartModuleType tankPartModuleType)
		{
			MainScreenComponent.Instance.OverrideOnBack(Hide);
			showAnimationFinished = false;
			base.gameObject.SetActive(true);
			tankPartModeController.SetMode(tankPartModuleType);
		}

		public void Hide()
		{
			MainScreenComponent.Instance.ClearOnBackOverride();
			GetComponent<Animator>().SetBool("hide", true);
		}

		public void OnHideAnimationFinished()
		{
			base.gameObject.SetActive(false);
		}

		public void OnShowAnimationFinished()
		{
			showAnimationFinished = true;
			if (OnShowAnimationFinishedAction != null)
			{
				OnShowAnimationFinishedAction();
			}
		}

		private void OnSelectionChange(ModuleItem item)
		{
			selectedModule = item;
			selectedModuleView.UpdateView(item, level2PowerByTier, Tank, Weapon);
		}

		public void UpdateView()
		{
			hullCollectionView.UpdateView(Tank);
			turretCollectionView.UpdateView(Weapon);
			collectionView.UpdateView();
			CreateSlotItems();
			PlaceSlotItems();
			UpdateSlotItems();
			tankPartModeController.UpdateView();
			UpdateLineCollectionView();
			selection.Update(CollectionView.slots, slotItems);
			selectedModule = selection.GetSelectedModuleItem();
			if (selectedModule != null)
			{
				selectedModuleView.UpdateView(selectedModule, level2PowerByTier, Tank, Weapon);
			}
		}

		public void UpdateLineCollectionView()
		{
			hullCollectionView.lineCollectionView.slot1.SetActive(hullCollectionView.activeSlot.HasItem());
			hullCollectionView.lineCollectionView.slot2.SetActive(hullCollectionView.activeSlot2.HasItem());
			hullCollectionView.lineCollectionView.slot3.SetActive(hullCollectionView.passiveSlot.HasItem());
			turretCollectionView.lineCollectionView.slot1.SetActive(turretCollectionView.activeSlot.HasItem());
			turretCollectionView.lineCollectionView.slot2.SetActive(turretCollectionView.activeSlot2.HasItem());
			turretCollectionView.lineCollectionView.slot3.SetActive(turretCollectionView.passiveSlot.HasItem());
		}

		public void UpdateViewInNextFrame()
		{
			needUpdate = true;
		}

		private void Update()
		{
			if (needUpdate)
			{
				UpdateView();
				needUpdate = false;
			}
		}

		public void InitSlots(ICollection<NewModulesScreenSystem.SlotNode> slotNodes)
		{
			List<TankSlotView> list = new List<TankSlotView>();
			list.Add(turretCollectionView.activeSlot);
			list.Add(turretCollectionView.activeSlot2);
			list.Add(turretCollectionView.passiveSlot);
			list.Add(hullCollectionView.activeSlot);
			list.Add(hullCollectionView.activeSlot2);
			list.Add(hullCollectionView.passiveSlot);
			List<TankSlotView> list2 = list;
			if (slotNodes.Count != list2.Count)
			{
				throw new ArgumentException("Incorrect module slot entity count " + slotNodes.Count);
			}
			foreach (NewModulesScreenSystem.SlotNode slotNode in slotNodes)
			{
				TankSlotView tankSlotView = list2[(int)slotNode.slotUserItemInfo.Slot];
				tankSlotView.SlotNode = slotNode;
			}
		}

		private void PlaceSlotItems()
		{
			List<ModuleItem> list = slotItems.Keys.ToList();
			list.Sort();
			for (int i = 0; i < list.Count; i++)
			{
				ModuleItem moduleItem = list[i];
				SlotItemView slotItemView = slotItems[moduleItem];
				if (moduleItem.Slot != null)
				{
					AddItemToTankCollection(moduleItem, slotItemView);
				}
				else
				{
					collectionView.AddSlotItem(moduleItem, slotItemView);
				}
				slotItemView.gameObject.SetActive(true);
			}
		}

		private void AddItemToTankCollection(ModuleItem moduleItem, SlotItemView slotItemView)
		{
			TankPartCollectionView tankPartCollection = GetTankPartCollection(moduleItem);
			if (moduleItem.ModuleBehaviourType == ModuleBehaviourType.PASSIVE)
			{
				tankPartCollection.passiveSlot.SetItem(slotItemView);
			}
			else if (tankPartCollection.activeSlot.SlotNode.Entity.Equals(moduleItem.Slot))
			{
				tankPartCollection.activeSlot.SetItem(slotItemView);
			}
			else
			{
				tankPartCollection.activeSlot2.SetItem(slotItemView);
			}
		}

		private TankPartCollectionView GetTankPartCollection(ModuleItem moduleItem)
		{
			return (moduleItem.TankPartModuleType != 0) ? turretCollectionView : hullCollectionView;
		}

		private void CreateSlotItems()
		{
			List<ModuleItem> list = GarageItemsRegistry.Modules.Where((ModuleItem mi) => mi.IsMutable()).ToList();
			foreach (ModuleItem item in list)
			{
				if (item.UserItem != null && !slotItems.ContainsKey(item))
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(slotItemPrefab);
					gameObject.SetActive(false);
					SlotItemView component = gameObject.GetComponent<SlotItemView>();
					component.UpdateView(item);
					component.onDoubleClick = OnSlotItemDoubleClick;
					slotItems.Add(item, component);
				}
			}
		}

		private void UpdateSlotItems()
		{
			foreach (KeyValuePair<ModuleItem, SlotItemView> slotItem in slotItems)
			{
				SlotItemView value = slotItem.Value;
				value.UpdateView(slotItem.Key);
			}
		}

		private void OnSlotItemDoubleClick(SlotItemView view)
		{
			ModuleItem moduleItem = view.ModuleItem;
			DragAndDropItem component = view.GetComponent<DragAndDropItem>();
			TankPartCollectionView tankPartCollection = GetTankPartCollection(moduleItem);
			DragAndDropCell component2 = CollectionView.slots[moduleItem].GetComponent<DragAndDropCell>();
			if (moduleItem.IsMounted)
			{
				TankSlotView slotBySlotEntity = tankPartCollection.GetSlotBySlotEntity(moduleItem.Slot);
				if (slotBySlotEntity == null)
				{
					throw new Exception("Modules screen: couln't find tank slot for moduleItem slot entity " + moduleItem.Slot.Id);
				}
				dragAndDropController.OnDrop(slotBySlotEntity.GetComponent<DragAndDropCell>(), component2, component);
			}
			else
			{
				TankSlotView slotForDrop = tankPartCollection.GetSlotForDrop(moduleItem.ModuleBehaviourType);
				if (slotForDrop != null)
				{
					dragAndDropController.OnDrop(component2, slotForDrop.GetComponent<DragAndDropCell>(), component);
				}
			}
		}

		private void OnCollectionSlotDoubleClick(CollectionSlotView collectionSlotView)
		{
			ModuleItem moduleItem = collectionSlotView.ModuleItem;
			if (moduleItem.Slot != null)
			{
				TankPartCollectionView tankPartCollection = GetTankPartCollection(moduleItem);
				TankSlotView slotBySlotEntity = tankPartCollection.GetSlotBySlotEntity(moduleItem.Slot);
				if (slotBySlotEntity == null)
				{
					throw new Exception("Modules screen: couldn't find tank slot");
				}
				DragAndDropItem component = slotBySlotEntity.GetItem().GetComponent<DragAndDropItem>();
				dragAndDropController.OnDrop(slotBySlotEntity.GetComponent<DragAndDropCell>(), collectionSlotView.GetComponent<DragAndDropCell>(), component);
			}
		}

		private void OnEnable()
		{
			PresetsDropDownList obj = presetsDropDownList;
			obj.onDropDownListItemSelected = (OnDropDownListItemSelected)Delegate.Combine(obj.onDropDownListItemSelected, new OnDropDownListItemSelected(OnPresetSelected));
		}

		private void OnDisable()
		{
			PresetsDropDownList obj = presetsDropDownList;
			obj.onDropDownListItemSelected = (OnDropDownListItemSelected)Delegate.Remove(obj.onDropDownListItemSelected, new OnDropDownListItemSelected(OnPresetSelected));
		}

		public void InitPresetsDropDown(List<PresetItem> items)
		{
			presetsDropDownList.UpdateList(items);
		}

		public void OnPresetSelected(ListItem item)
		{
			PresetItem presetItem = (PresetItem)item.Data;
			Mount(presetItem.presetEntity);
		}

		public void OnVisualItemSelected(ListItem item)
		{
			VisualItem visualItem = (VisualItem)item.Data;
			Mount(visualItem.UserItem);
		}

		private void Mount(Entity entity)
		{
			ECSBehaviour.EngineService.Engine.ScheduleEvent<MountItemEvent>(entity);
		}

		public void InitMoney(NewModulesScreenSystem.SelfUserMoneyNode money)
		{
			selectedModuleView.InitMoney(money);
			crystalButton.SetValueWithoutAnimation(money.userMoney.Money);
			xCrystalButton.SetValueWithoutAnimation(money.userXCrystals.Money);
		}
	}
}
