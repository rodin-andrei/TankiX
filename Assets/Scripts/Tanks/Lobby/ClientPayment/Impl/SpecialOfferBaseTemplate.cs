using Lobby.ClientPayment.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientPayment.Impl
{
	[SerialVersionUID(657658796589123211L)]
	public interface SpecialOfferBaseTemplate : GoodsTemplate, Template
	{
		[AutoAdded]
		SpecialOfferComponent specialOffer();

		SpecialOfferGroupComponent specialOfferGroup();

		ItemsPackFromConfigComponent itemsPackFromConfig();

		XCrystalsPackComponent xCrystalsPack();

		SpecialOfferDurationComponent specialOfferDuration();

		SpecialOfferEndTimeComponent specialOfferEndTime();

		[AutoAdded]
		[PersistentConfig("order", false)]
		OrderItemComponent orderItem();

		[AutoAdded]
		[PersistentConfig("", false)]
		SpecialOfferContentLocalizationComponent specialOfferContentLocalization();

		[AutoAdded]
		[PersistentConfig("", false)]
		SpecialOfferContentComponent specialOfferContent();

		[AutoAdded]
		[PersistentConfig("", false)]
		ReceiptTextComponent receiptText();

		[AutoAdded]
		[PersistentConfig("", false)]
		SpecialOfferScreenLocalizationComponent specialOfferScreenLocalization();

		CountableItemsPackComponent countableItemsPack();

		CrystalsPackComponent crystalsPack();
	}
}
