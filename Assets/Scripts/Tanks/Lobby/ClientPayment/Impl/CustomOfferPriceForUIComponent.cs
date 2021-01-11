using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientPayment.Impl
{
	public class CustomOfferPriceForUIComponent : Component
	{
		public double Price
		{
			get;
			private set;
		}

		public CustomOfferPriceForUIComponent(double price)
		{
			Price = price;
		}
	}
}
