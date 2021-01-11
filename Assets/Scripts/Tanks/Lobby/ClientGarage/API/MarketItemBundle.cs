namespace Tanks.Lobby.ClientGarage.API
{
	public class MarketItemBundle
	{
		private int amount = 1;

		public long MarketItem
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

		public int Max
		{
			get;
			set;
		}
	}
}
