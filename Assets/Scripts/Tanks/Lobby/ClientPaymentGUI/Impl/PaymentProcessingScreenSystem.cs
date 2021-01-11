using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientNavigation.API;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class PaymentProcessingScreenSystem : ECSSystem
	{
		public class ScreenNode : Node
		{
			public PaymentProcessingScreenComponent paymentProcessingScreen;
		}

		[OnEventFire]
		public void InitScreen(NodeAddedEvent e, ScreenNode screen)
		{
			screen.Entity.AddComponent<LockedScreenComponent>();
		}
	}
}
