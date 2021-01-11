using System;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Tanks.Lobby.ClientGarage.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ContainerBoxItem : GarageItem
	{
		private readonly List<GarageItem> content = new List<GarageItem>();

		private readonly Dictionary<long, string> marketItemToName = new Dictionary<long, string>();

		private readonly Dictionary<long, string> entityToDescription = new Dictionary<long, string>();

		private Action onOpen;

		[Inject]
		public static GarageItemsRegistry GarageItemsRegistry
		{
			get;
			set;
		}

		public ICollection<GarageItem> Content
		{
			get
			{
				return content;
			}
		}

		public int Count
		{
			get
			{
				if (base.UserItem == null)
				{
					return 0;
				}
				if (!base.UserItem.HasComponent<UserItemCounterComponent>())
				{
					return 0;
				}
				return (int)base.UserItem.GetComponent<UserItemCounterComponent>().Count;
			}
		}

		public Dictionary<int, int> PackXPrices
		{
			get
			{
				return (!MarketItem.HasComponent<PackPriceComponent>()) ? null : MarketItem.GetComponent<PackPriceComponent>().PackXPrice;
			}
		}

		public override Entity MarketItem
		{
			get
			{
				return base.MarketItem;
			}
			set
			{
				base.MarketItem = value;
				IsBlueprint = value.HasComponent<GameplayChestItemComponent>();
				base.Preview = value.GetComponent<ImageItemComponent>().SpriteUid;
				if (value.HasComponent<DescriptionItemComponent>())
				{
					DescriptionItemComponent component = value.GetComponent<DescriptionItemComponent>();
					entityToDescription.Add(value.Id, component.Description);
				}
				if (IsBlueprint)
				{
					return;
				}
				ItemsContainerItemComponent component2 = value.GetComponent<ItemsContainerItemComponent>();
				DescriptionBundleItemComponent component3 = value.GetComponent<DescriptionBundleItemComponent>();
				foreach (ContainerItem item in component2.Items)
				{
					foreach (MarketItemBundle itemBundle in item.ItemBundles)
					{
						if (item.NameLocalizationKey != null && component3.Names != null && component3.Names.ContainsKey(item.NameLocalizationKey))
						{
							marketItemToName.Add(itemBundle.MarketItem, component3.Names[item.NameLocalizationKey]);
						}
						content.Add(GarageItemsRegistry.GetItem<VisualItem>(itemBundle.MarketItem));
					}
				}
				if (component2.RareItems == null)
				{
					return;
				}
				foreach (ContainerItem rareItem in component2.RareItems)
				{
					foreach (MarketItemBundle itemBundle2 in rareItem.ItemBundles)
					{
						if (rareItem.NameLocalizationKey != null && component3.Names != null && component3.Names.ContainsKey(rareItem.NameLocalizationKey))
						{
							marketItemToName.Add(itemBundle2.MarketItem, component3.Names[rareItem.NameLocalizationKey]);
						}
						content.Add(GarageItemsRegistry.GetItem<VisualItem>(itemBundle2.MarketItem));
					}
				}
			}
		}

		public bool IsBlueprint
		{
			get;
			set;
		}

		public string GetLocalizedContentItemName(long marketItemId)
		{
			if (!marketItemToName.ContainsKey(marketItemId))
			{
				return string.Empty;
			}
			return marketItemToName[marketItemId];
		}

		public string GetLocalizedDescription(long entityId)
		{
			return (!entityToDescription.ContainsKey(entityId)) ? string.Empty : entityToDescription[entityId];
		}

		public void Open(Action onOpen)
		{
			this.onOpen = onOpen;
			GarageItem.EngineService.Engine.ScheduleEvent<OpenVisualContainerEvent>(base.UserItem);
		}

		public void Opend()
		{
			if (onOpen != null)
			{
				onOpen();
				onOpen = null;
			}
		}
	}
}
