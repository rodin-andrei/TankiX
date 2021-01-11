using System;
using System.Collections.Generic;
using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class VisualUI : ECSBehaviour
	{
		[SerializeField]
		private RectTransform buttonsRoot;

		[SerializeField]
		private GameObject ammoButton;

		[SerializeField]
		private GameObject paintButton;

		[SerializeField]
		private GameObject coverButton;

		[SerializeField]
		private GameObject graffitiRoot;

		[SerializeField]
		private VisualUIListSwitch visualUIListSwitch;

		[SerializeField]
		private DefaultListDataProvider dataProvider;

		[SerializeField]
		private GameObject buyButton;

		[SerializeField]
		private GameObject xBuyButton;

		[SerializeField]
		private GameObject containersButton;

		[SerializeField]
		private GameObject equipButton;

		[SerializeField]
		private GaragePrice price;

		[SerializeField]
		private GaragePrice xPrice;

		[SerializeField]
		private TextMeshProUGUI itemName;

		[SerializeField]
		private float cameraOffset = -0.2f;

		private TankPartItem target;

		private List<VisualItem> skins;

		private List<VisualItem> paints;

		private List<VisualItem> graffities;

		private List<VisualItem> ammo;

		private List<VisualItem> nextList;

		private VisualItem selected;

		private int tab;

		public Action onEanble;

		[Inject]
		public static GarageItemsRegistry GarageItemsRegistry
		{
			get;
			set;
		}

		public void Clear()
		{
			target = null;
			skins = null;
			paints = null;
			graffities = null;
			ammo = null;
			nextList = null;
			selected = null;
		}

		private void OnEnable()
		{
			if (onEanble != null)
			{
				onEanble();
			}
			CameraOffsetBehaviour cameraOffsetBehaviour = UnityEngine.Object.FindObjectOfType<CameraOffsetBehaviour>();
			cameraOffsetBehaviour.AnimateOffset(cameraOffset);
		}

		public void Set(TankPartItem item, int tab)
		{
			if (target == null || target.MarketItem != item)
			{
				target = item;
				itemName.text = target.Name.ToUpper();
				skins = GetActiveItemList(target.Skins);
				skins.Sort();
				paints = ((item.Type != TankPartItem.TankPartItemType.Hull) ? GetActiveItemList(GarageItemsRegistry.Coatings) : GetActiveItemList(GarageItemsRegistry.Paints));
				paints.Sort();
				graffities = GetActiveItemList(GetItemsList<GetAllGraffitiesEvent>());
				graffities.Sort();
				bool flag = target.Type == TankPartItem.TankPartItemType.Turret;
				ammoButton.SetActive(flag);
				coverButton.SetActive(flag);
				paintButton.SetActive(!flag);
				if (flag)
				{
					ammo = GetActiveItemList(GetItemsList<GetAllShellsEvent>(target.MarketItem));
					ammo.Sort();
				}
				selected = null;
				this.tab = tab;
				ToVisual(true);
			}
		}

		private List<VisualItem> GetItemsList<T>(Entity context = null) where T : GetAllItemsEvent<VisualItem>, new()
		{
			T val = this.SendEvent<T>(context);
			return val.Items;
		}

		private List<VisualItem> GetActiveItemList(ICollection<VisualItem> list)
		{
			return list.Where((VisualItem target) => target.IsBuyable || target.UserItem != null || target.IsContainerItem).ToList();
		}

		public void ToSkins(bool immediate = false)
		{
			SwitchToList(skins, immediate);
			tab = 0;
			ValidateButtons();
			switch (target.Type)
			{
			case TankPartItem.TankPartItemType.Hull:
				MainScreenComponent.Instance.SendShowScreenStat(LogScreen.HullSkins);
				break;
			case TankPartItem.TankPartItemType.Turret:
				MainScreenComponent.Instance.SendShowScreenStat(LogScreen.TurretSkins);
				break;
			}
		}

		public void ToPaints(bool immediate = false)
		{
			SwitchToList(paints, immediate);
			tab = 1;
			ValidateButtons();
			MainScreenComponent.Instance.SendShowScreenStat(LogScreen.HullPaints);
		}

		public void ToCover(bool immediate = false)
		{
			SwitchToList(paints, immediate);
			tab = 2;
			ValidateButtons();
			MainScreenComponent.Instance.SendShowScreenStat(LogScreen.TurretPaints);
		}

		public void ToGraffities(bool immediate = false)
		{
			SwitchToList(graffities, immediate);
			tab = 3;
			ValidateButtons();
			MainScreenComponent.Instance.SendShowScreenStat(LogScreen.Graffities);
		}

		public void ToShells(bool immediate = false)
		{
			SwitchToList(ammo, immediate);
			tab = 4;
			ValidateButtons();
			MainScreenComponent.Instance.SendShowScreenStat(LogScreen.TurretShells);
		}

		private void ValidateButtons()
		{
			for (int i = 0; i < buttonsRoot.childCount; i++)
			{
				SetSelectionButton(buttonsRoot.GetChild(i).gameObject, i == tab);
			}
			GetComponentInParent<CustomizationUIComponent>().SetVisualTab(tab);
		}

		private void SetSelectionButton(GameObject button, bool selection)
		{
			Button component = button.GetComponent<Button>();
			component.interactable = !selection;
			if (component.interactable)
			{
				component.OnPointerExit(null);
			}
		}

		public void ToVisual(bool immediate = false)
		{
			switch (tab)
			{
			case 0:
				ToSkins(immediate);
				break;
			case 1:
				if (target.Type == TankPartItem.TankPartItemType.Turret)
				{
					ToCover(immediate);
				}
				else
				{
					ToPaints(immediate);
				}
				break;
			case 2:
				if (target.Type == TankPartItem.TankPartItemType.Turret)
				{
					ToCover(immediate);
				}
				else
				{
					ToPaints(immediate);
				}
				break;
			case 3:
				ToGraffities(immediate);
				break;
			case 4:
				if (target.Type == TankPartItem.TankPartItemType.Turret)
				{
					ToShells(immediate);
				}
				else
				{
					ToSkins(immediate);
				}
				break;
			}
		}

		private void SwitchToList(List<VisualItem> items, bool immediate)
		{
			if (nextList != items)
			{
				if (immediate)
				{
					UpdateList(items);
				}
				visualUIListSwitch.Animate();
				nextList = items;
			}
		}

		public void Switch()
		{
			UpdateList(nextList);
		}

		private void UpdateList(ICollection<VisualItem> items)
		{
			graffitiRoot.SetActive(items == graffities);
			dataProvider.ClearItems();
			selected = null;
			VisualItem visualItem = null;
			foreach (VisualItem item in items)
			{
				if (item.IsSelected)
				{
					selected = item;
					OnItemChanged(item);
				}
				if (item.IsMounted)
				{
					visualItem = item;
				}
			}
			if (selected == null && visualItem != null)
			{
				selected = visualItem;
			}
			dataProvider.Init(items, selected);
		}

		private void OnItemSelect(ListItem item)
		{
			selected = (VisualItem)item.Data;
			OnItemChanged(selected);
		}

		private void OnDoubleClick(ListItem item)
		{
			OnItemSelect(item);
			VisualItem visualItem = (VisualItem)item.Data;
			if (visualItem.UserItem != null)
			{
				visualItem.Mount();
			}
		}

		private void OnItemChanged(VisualItem item)
		{
			if (item.UserItem == null)
			{
				int num = item.Price;
				int num2 = item.XPrice;
				buyButton.SetActive(num > 0);
				xBuyButton.SetActive(num2 > 0);
				equipButton.SetActive(false);
				price.SetPrice(item.OldPrice, num);
				xPrice.SetPrice(item.OldXPrice, num2);
				containersButton.SetActive(!buyButton.activeSelf && !xBuyButton.activeSelf && item.MarketItem.HasComponent<ContainerContentItemGroupComponent>());
			}
			else
			{
				buyButton.SetActive(false);
				xBuyButton.SetActive(false);
				containersButton.SetActive(false);
				equipButton.SetActive(!item.IsMounted && !item.IsRestricted);
			}
		}

		public void OnBuy()
		{
			UnityEngine.Object.FindObjectOfType<Dialogs60Component>().Get<BuyConfirmationDialog>().Show(selected, delegate
			{
			});
		}

		public void OnEquip()
		{
			this.SendEvent<MountItemEvent>(selected.UserItem);
		}

		public void OnXBuy()
		{
			UnityEngine.Object.FindObjectOfType<Dialogs60Component>().Get<BuyConfirmationDialog>().XShow(selected, delegate
			{
			}, selected.XPrice);
		}

		public void OnUpgrade()
		{
			CustomizationUIComponent componentInParent = GetComponentInParent<CustomizationUIComponent>();
			this.SendEvent<ListItemSelectedEvent>(selected.ParentItem.UserItem);
			if (selected.ParentItem.Type == TankPartItem.TankPartItemType.Hull)
			{
				componentInParent.HullModules();
			}
			else
			{
				componentInParent.TurretModules();
			}
		}

		public void OnContainer()
		{
			Entity entity = null;
			try
			{
				entity = Select<SingleNode<ContainerMarkerComponent>>(Select<SingleNode<ContainerContentItemComponent>>(selected.MarketItem, typeof(ContainerContentItemGroupComponent)).First().Entity, typeof(ContainerGroupComponent)).First().Entity;
			}
			catch (Exception)
			{
				Debug.Log("No such container");
			}
			if (entity != null)
			{
				this.SendEvent(new ShowGarageCategoryEvent
				{
					Category = GarageCategory.CONTAINERS,
					SelectedItem = entity
				});
			}
		}

		private void OnDisable()
		{
			Clear();
			graffitiRoot.SetActive(false);
		}

		public void ReturnCameraOffset()
		{
			CameraOffsetBehaviour cameraOffsetBehaviour = UnityEngine.Object.FindObjectOfType<CameraOffsetBehaviour>();
			if (cameraOffsetBehaviour != null)
			{
				cameraOffsetBehaviour.AnimateOffset(0f);
			}
		}
	}
}
