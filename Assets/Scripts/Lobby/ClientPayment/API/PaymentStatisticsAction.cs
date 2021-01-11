namespace Lobby.ClientPayment.API
{
	public enum PaymentStatisticsAction : byte
	{
		OPEN_PAYMENT,
		COUNTRY_SELECT,
		ITEM_SELECT,
		MODE_SELECT,
		PROCEED,
		CLOSE_PAYMENT,
		OPEN_EXCHANGE,
		PAYMENT_ERROR,
		CONFIRMED_ONE_TIME_OFFER
	}
}
