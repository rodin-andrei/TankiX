using Tanks.Lobby.ClientNavigation.API;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class GoodsSelectionScreenComponent : LocalizedScreenComponent, PaymentScreen
	{
		private XCrystalsDataProvider xCrystalsDataProvider;

		private SpecialOfferDataProvider specialOfferDataProvider;

		public string SpecialOfferOneShotMessage
		{
			get;
			set;
		}

		public string SpecialOfferEmptyRewardMessage
		{
			get;
			set;
		}

		public XCrystalsDataProvider XCrystalsDataProvider
		{
			get
			{
				return xCrystalsDataProvider;
			}
		}

		public SpecialOfferDataProvider SpecialOfferDataProvider
		{
			get
			{
				return specialOfferDataProvider;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			xCrystalsDataProvider = GetComponentInChildren<XCrystalsDataProvider>();
			specialOfferDataProvider = GetComponentInChildren<SpecialOfferDataProvider>();
		}
	}
}
