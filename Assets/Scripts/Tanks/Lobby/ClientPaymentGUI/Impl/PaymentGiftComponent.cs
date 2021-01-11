using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class PaymentGiftComponent : Component
	{
		public long Gift
		{
			get;
			private set;
		}

		public PaymentGiftComponent(long gift)
		{
			Gift = gift;
		}
	}
}
