using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(716181447780635764L)]
	public interface ShellMarketItemTemplate : ShellItemTemplate, MarketItemTemplate, GarageItemImagedTemplate, GarageItemTemplate, ItemImagedTemplate, Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		PurchaseUpgradeLevelRestrictionComponent purchaseUpgradeLevelRestriction();

		[AutoAdded]
		[PersistentConfig("", false)]
		PurchaseUserRankRestrictionComponent purchaseUserRankRestriction();

		[AutoAdded]
		[PersistentConfig("", false)]
		MountUpgradeLevelRestrictionComponent mountUpgradeLevelRestriction();

		[AutoAdded]
		[PersistentConfig("", false)]
		MountUserRankRestrictionComponent mountUserRankRestriction();
	}
}
