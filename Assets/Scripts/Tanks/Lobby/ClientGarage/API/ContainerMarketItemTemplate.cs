using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(1479807523359L)]
	public interface ContainerMarketItemTemplate : ContainerItemTemplate, MarketItemTemplate, GarageItemImagedTemplate, GarageItemTemplate, ItemImagedTemplate, Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		ItemsContainerItemComponent itemsContainerItem();

		[AutoAdded]
		[PersistentConfig("", false)]
		ItemPacksComponent itemPacks();
	}
}
