using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientNavigation.API;
using Tanks.Lobby.ClientUserProfile.API;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class EmailConfirmationNotificationSystem : ECSSystem
	{
		public class HomeScreenNode : Node
		{
			public ActiveScreenComponent activeScreen;

			public HomeScreenComponent homeScreen;
		}

		private bool emailIsEmpty(Entity user)
		{
			return !user.HasComponent<UnconfirmedUserEmailComponent>() || string.IsNullOrEmpty(user.GetComponent<UnconfirmedUserEmailComponent>().Email);
		}

		[OnEventFire]
		public void PrepareNotificationText(NodeAddedEvent e, SingleNode<EmailConfirmationNotificationComponent> notification, [JoinAll] HomeScreenNode activeScreen, [JoinAll] SingleNode<SelfUserComponent> selfUser)
		{
			if (emailIsEmpty(selfUser.Entity))
			{
				notification.Entity.AddComponent(new NotificationMessageComponent(notification.component.ChangeEmailMessageTemplate));
			}
			else
			{
				notification.Entity.AddComponent(new NotificationMessageComponent(notification.component.ConfirmationMessageTemplate));
			}
		}
	}
}
