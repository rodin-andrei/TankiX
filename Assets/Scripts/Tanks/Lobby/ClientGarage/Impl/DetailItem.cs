using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Tanks.Lobby.ClientGarage.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class DetailItem : GarageItem
	{
		[Inject]
		public static GarageItemsRegistry GarageItemsRegistry
		{
			get;
			set;
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

		public long RequiredCount
		{
			get
			{
				return MarketItem.GetComponent<DetailItemComponent>().RequiredCount;
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
				base.Preview = value.GetComponent<ImageItemComponent>().SpriteUid;
			}
		}

		public GarageItem TargetMarketItem
		{
			get
			{
				return GarageItemsRegistry.GetItem<GarageItem>(MarketItem.GetComponent<DetailItemComponent>().TargetMarketItemId);
			}
		}

		public override string ToString()
		{
			return string.Format("Detail item: marketItem = {0}, TargetMarketItem = {1}, Name = {2}, Preview = {3}, Count = {4}, RequiredCount = {5}", MarketItem, TargetMarketItem.MarketItem, base.Name, base.Preview, Count, RequiredCount);
		}
	}
}
