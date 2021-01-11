using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientResources.API;
using Tanks.Lobby.ClientUserProfile.API;

namespace Tanks.Lobby.ClientPayment.Impl
{
	public class PaymentNotificationSystem : ECSSystem
	{
		public class PaymentNotificationNode : Node
		{
			public PaymentNotificationComponent paymentNotification;

			public PaymentNotificationTextComponent paymentNotificationText;

			public ResourceDataComponent resourceData;
		}

		public class SpecialOfferNotificationNode : Node
		{
			public SpecialOfferNotificationComponent specialOfferNotification;

			public PaymentNotificationTextComponent paymentNotificationText;

			public ResourceDataComponent resourceData;
		}

		public class SaleEndNotificationNode : Node
		{
			public SaleEndNotificationTextComponent saleEndNotificationText;

			public ResourceDataComponent resourceData;
		}

		[OnEventFire]
		public void CreateNotification(NodeAddedEvent e, PaymentNotificationNode notification)
		{
			notification.Entity.AddComponent(new NotificationMessageComponent
			{
				Message = string.Format(notification.paymentNotificationText.MessageTemplate, notification.paymentNotification.Amount)
			});
		}

		[OnEventFire]
		public void CreateNotification(NodeAddedEvent e, SpecialOfferNotificationNode notification)
		{
			notification.Entity.AddComponent(new NotificationMessageComponent
			{
				Message = string.Format(notification.paymentNotificationText.MessageTemplate, notification.specialOfferNotification.OfferName)
			});
		}

		[OnEventFire]
		public void CreateNotification(NodeAddedEvent e, SaleEndNotificationNode notification)
		{
			notification.Entity.AddComponent(new NotificationMessageComponent
			{
				Message = string.Format(notification.saleEndNotificationText.Message)
			});
		}
	}
}
