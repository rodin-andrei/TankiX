using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientPayment.API
{
	[SerialVersionUID(1495081806742L)]
	public class ExchangeRateComponent : Component
	{
		private static float rate;

		public static float ExhchageRate
		{
			get
			{
				return rate;
			}
		}

		public float Rate
		{
			get
			{
				return rate;
			}
			set
			{
				rate = value;
			}
		}
	}
}
