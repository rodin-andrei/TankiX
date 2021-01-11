using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Tanks.Lobby.ClientGarage.Impl;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(1493972656490L)]
	public interface PresetMarketItemTemplate : PresetItemTemplate, MarketItemTemplate, GarageItemTemplate, Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		FirstBuySaleComponent firstBuySale();

		[AutoAdded]
		[PersistentConfig("", false)]
		CreateByRankConfigComponent createByRankConfig();

		[AutoAdded]
		[PersistentConfig("", false)]
		ItemsBuyCountLimitComponent itemsBuyCountLimit();

		[AutoAdded]
		[PersistentConfig("", false)]
		ItemAutoIncreasePriceComponent itemsAutoIncreasePrice();
	}
}
