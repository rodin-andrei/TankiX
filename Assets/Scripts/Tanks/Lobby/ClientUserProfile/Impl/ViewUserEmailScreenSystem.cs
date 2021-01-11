using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientEntrance.API;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class ViewUserEmailScreenSystem : ECSSystem
	{
		public class SelfUserWithConfirmedEmailNode : Node
		{
			public ConfirmedUserEmailComponent confirmedUserEmail;

			public SelfUserComponent selfUser;
		}

		[OnEventFire]
		public void ViewEmail(NodeAddedEvent e, SingleNode<ViewUserEmailScreenComponent> screen, SelfUserWithConfirmedEmailNode user)
		{
			SetEmail(user.confirmedUserEmail, screen.component);
		}

		private void SetEmail(ConfirmedUserEmailComponent userEmail, ViewUserEmailScreenComponent screen)
		{
			screen.YourEmailReplaced = screen.YourEmail.Replace("%EMAIL%", string.Format("<color=#{1}>{0}</color>", userEmail.Email, screen.EmailColor.ToHexString()));
		}

		[OnEventFire]
		public void EmailChanged(ConfirmedUserEmailChangedEvent e, SelfUserWithConfirmedEmailNode user, [JoinAll] SingleNode<ViewUserEmailScreenComponent> screen)
		{
			SetEmail(user.confirmedUserEmail, screen.component);
		}
	}
}
