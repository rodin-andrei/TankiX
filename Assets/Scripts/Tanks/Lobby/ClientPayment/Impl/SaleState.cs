namespace Tanks.Lobby.ClientPayment.Impl
{
	public class SaleState
	{
		public double PriceMultiplier
		{
			get;
			set;
		}

		public double AmountMultiplier
		{
			get;
			set;
		}

		public SaleState()
		{
			Reset();
		}

		public void Reset()
		{
			PriceMultiplier = 1.0;
			AmountMultiplier = 1.0;
		}
	}
}
