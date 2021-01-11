using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	[Shared]
	[SerialVersionUID(1458203345903L)]
	public class BuyMarketItemEvent : Event
	{
		private int amount = 1;

		public int Price
		{
			get;
			set;
		}

		public int Amount
		{
			get
			{
				return amount;
			}
			set
			{
				amount = value;
			}
		}
	}
}
