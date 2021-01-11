using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(1544694405895L)]
	public interface AvatarMarketItemTemplate : AvatarItemTemplate, MarketItemTemplate, GarageItemImagedTemplate, GarageItemTemplate, ItemImagedTemplate, Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		PurchaseUpgradeLevelRestrictionComponent purchaseUpgradeLevelRestriction();

		[AutoAdded]
		[PersistentConfig("", false)]
		PurchaseUserRankRestrictionComponent purchaseUserRankRestriction();
	}
}
