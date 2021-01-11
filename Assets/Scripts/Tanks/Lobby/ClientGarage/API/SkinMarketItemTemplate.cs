using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(1467632386864L)]
	public interface SkinMarketItemTemplate : SkinItemTemplate, MarketItemTemplate, GarageItemImagedTemplate, GarageItemTemplate, ItemImagedTemplate, Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		MountUpgradeLevelRestrictionComponent mountUpgradeLevelRestriction();

		[AutoAdded]
		[PersistentConfig("", false)]
		MountUserRankRestrictionComponent mountUserRankRestriction();

		[AutoAdded]
		[PersistentConfig("", false)]
		PurchaseUpgradeLevelRestrictionComponent purchaseUpgradeLevelRestriction();

		[AutoAdded]
		[PersistentConfig("", false)]
		PurchaseUserRankRestrictionComponent purchaseUserRankRestriction();
	}
}
