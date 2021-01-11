using System;
using System.Collections.Generic;
using System.Linq;
using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ItemSelectUI : MonoBehaviour
	{
		private Carousel carousel;

		[SerializeField]
		private TextMeshProUGUI itemName;

		[SerializeField]
		private TextMeshProUGUI feature;

		[SerializeField]
		private TextMeshProUGUI description;

		[SerializeField]
		private MainVisualPropertyUI[] props;

		[SerializeField]
		private AnimatedNumber mastery;

		[SerializeField]
		private Animator buttonsAnimator;

		[SerializeField]
		private BuyItemButton buyButton;

		[SerializeField]
		private BuyItemButton xBuyButton;

		[SerializeField]
		private TextMeshProUGUI crystalsRestrictionMismatch;

		[SerializeField]
		private TextMeshProUGUI crystalsRestrictionMatch;

		[SerializeField]
		private LocalizedField crystalsRestrictionMismatchField;

		[SerializeField]
		private LocalizedField crystalsRestrictionMatchField;

		[SerializeField]
		private Button changeSkinButton;

		[SerializeField]
		private Button changePaintButton;

		[SerializeField]
		private Button changeAmmoButton;

		[SerializeField]
		private Button changeCoverButton;

		[SerializeField]
		private CustomizationUIComponent customizationUI;

		private Entity savedSelection;

		private GarageItemUI currentGarageItemUi;

		private Action onEnable;

		private Carousel Carousel
		{
			get
			{
				if (carousel == null)
				{
					carousel = GetComponentInChildren<Carousel>();
				}
				return carousel;
			}
		}

		private TankPartItem SelectedItem
		{
			get
			{
				return Carousel.Selected.Item as TankPartItem;
			}
		}

		public bool IsSelected
		{
			get;
			private set;
		}

		public void RefreshSelection()
		{
			if (base.gameObject.activeSelf && (bool)currentGarageItemUi)
			{
				OnItemSelect(currentGarageItemUi);
			}
		}

		private void OnItemSelect(GarageItemUI item)
		{
			TankPartItem tankPartItem = item.Item as TankPartItem;
			bool flag = tankPartItem.Type == TankPartItem.TankPartItemType.Turret;
			changeAmmoButton.gameObject.SetActive(flag);
			changeCoverButton.gameObject.SetActive(flag);
			changePaintButton.gameObject.SetActive(!flag);
			Entity marketItem = item.Item.MarketItem;
			GetComponentInParent<MainScreenComponent>().SetOnBackCallback(delegate
			{
				savedSelection = marketItem;
			});
			Entity userItem = item.Item.UserItem;
			bool flag2 = userItem != null;
			DescriptionItemComponent component = marketItem.GetComponent<DescriptionItemComponent>();
			VisualPropertiesComponent component2 = marketItem.GetComponent<VisualPropertiesComponent>();
			itemName.text = component.Name.ToUpper();
			feature.text = component2.Feature;
			description.text = component.Description;
			description.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
			buttonsAnimator.SetBool("Bought", flag2);
			for (int i = 0; i < component2.MainProperties.Count; i++)
			{
				props[i].gameObject.SetActive(true);
				props[i].Set(component2.MainProperties[i].Name, component2.MainProperties[i].NormalizedValue);
			}
			for (int j = component2.MainProperties.Count; j < props.Length; j++)
			{
				props[j].gameObject.SetActive(false);
			}
			mastery.transform.parent.gameObject.SetActive(flag2);
			if (flag2)
			{
				mastery.Value = tankPartItem.UpgradeLevel;
				return;
			}
			Entity selfUser = SelfUserComponent.SelfUser;
			int rank = selfUser.GetComponent<UserRankComponent>().Rank;
			bool flag3 = item.Item.MarketItem.HasComponent<CrystalsPurchaseUserRankRestrictionComponent>();
			int num = (flag3 ? item.Item.MarketItem.GetComponent<CrystalsPurchaseUserRankRestrictionComponent>().RestrictionValue : 0);
			bool flag4 = num <= rank;
			int price = item.Item.Price;
			if (price > 0)
			{
				buyButton.gameObject.SetActive(true);
				buyButton.SetPrice(item.Item.OldPrice, price);
				buyButton.Button.interactable = flag4;
				crystalsRestrictionMatch.gameObject.SetActive(false);
				crystalsRestrictionMismatch.gameObject.SetActive(flag3 && !flag4);
				crystalsRestrictionMismatch.SetText(string.Format(crystalsRestrictionMismatchField.Value, num));
				crystalsRestrictionMatch.SetText(string.Format(crystalsRestrictionMatchField.Value, num));
			}
			else
			{
				buyButton.gameObject.SetActive(false);
			}
			int xPrice = item.Item.XPrice;
			if (xPrice > 0)
			{
				xBuyButton.gameObject.SetActive(flag3 && !flag4);
				xBuyButton.SetPrice(item.Item.OldXPrice, xPrice);
				xBuyButton.Button.interactable = !flag4;
			}
			else
			{
				xBuyButton.gameObject.SetActive(false);
			}
		}

		private void Awake()
		{
			changeSkinButton.onClick.AddListener(ChangeSkin);
			changePaintButton.onClick.AddListener(ChangePaint);
			changeCoverButton.onClick.AddListener(ChangeCover);
			changeAmmoButton.onClick.AddListener(ChangeAmmo);
		}

		private void ChangeSkin()
		{
			if (SelectedItem.Type == TankPartItem.TankPartItemType.Turret)
			{
				customizationUI.TurretVisualNoSwitch(0);
			}
			else
			{
				customizationUI.HullVisualNoSwitch(0);
			}
		}

		private void ChangePaint()
		{
			customizationUI.HullVisualNoSwitch(1);
		}

		private void ChangeCover()
		{
			customizationUI.TurretVisualNoSwitch(2);
		}

		private void ChangeAmmo()
		{
			customizationUI.TurretVisualNoSwitch(4);
		}

		public void OnBuy()
		{
			TankPartItem item = Carousel.Selected.Item as TankPartItem;
			UnityEngine.Object.FindObjectOfType<Dialogs60Component>().Get<BuyConfirmationDialog>().Show(item, delegate
			{
				OnAnyBuyCallback(item);
			});
		}

		private void OnAnyBuyCallback(TankPartItem item)
		{
			if (Carousel.gameObject.activeInHierarchy && item == Carousel.Selected.Item)
			{
				buttonsAnimator.SetBool("Bought", true);
				item.WaitForBuy = false;
			}
		}

		public void OnXBuy()
		{
			TankPartItem item = Carousel.Selected.Item as TankPartItem;
			UnityEngine.Object.FindObjectOfType<Dialogs60Component>().Get<BuyConfirmationDialog>().XShow(item, delegate
			{
				OnAnyBuyCallback(item);
			}, item.XPrice);
		}

		private void OnEnable()
		{
			if (onEnable != null)
			{
				onEnable();
			}
		}

		private void OnDisable()
		{
			currentGarageItemUi = null;
		}

		public void SetItems(ICollection<TankPartItem> items, TankPartItem mountedItem)
		{
			onEnable = delegate
			{
				List<TankPartItem> list = items.ToList();
				list.Sort();
				IsSelected = false;
				Carousel.AddItems(list);
				Carousel.onItemSelected = OnItemSelect;
				bool flag = false;
				foreach (TankPartItem item in list)
				{
					if (savedSelection == null && item == mountedItem)
					{
						flag = true;
						Carousel.Select(item, true);
						break;
					}
					if (savedSelection != null && item.MarketItem == savedSelection)
					{
						flag = true;
						Carousel.Select(item, true);
						break;
					}
				}
				savedSelection = null;
				if (!flag)
				{
					Carousel.Select(list.First(), true);
				}
			};
		}

		public void SubmitSelection()
		{
			IsSelected = true;
			MainScreenComponent componentInParent = GetComponentInParent<MainScreenComponent>();
			componentInParent.DisableReset();
			if (SelectedItem.Type == TankPartItem.TankPartItemType.Hull)
			{
				componentInParent.MountedHull = SelectedItem;
			}
			else
			{
				componentInParent.MountedTurret = SelectedItem;
			}
			SelectedItem.Mount();
		}
	}
}
