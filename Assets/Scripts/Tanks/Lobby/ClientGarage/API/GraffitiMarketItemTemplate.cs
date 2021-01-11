using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(636100801770520539L)]
	public interface GraffitiMarketItemTemplate : GraffitiItemTemplate, MarketItemTemplate, GarageItemImagedTemplate, GarageItemTemplate, ItemImagedTemplate, Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		MountUpgradeLevelRestrictionComponent mountUpgradeLevelRestriction();

		[AutoAdded]
		[PersistentConfig("", false)]
		PurchaseUpgradeLevelRestrictionComponent purchaseUpgradeLevelRestriction();

		[AutoAdded]
		[PersistentConfig("", false)]
		PurchaseUserRankRestrictionComponent purchaseUserRankRestriction();
	}
}
