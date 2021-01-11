namespace Tanks.Lobby.ClientUserProfile.API
{
	public class WaitingForInviteToLobbyAnswerUIComponent : WaitingAnswerUIComponent
	{
		public bool AlreadyInLobby
		{
			set
			{
				base.Waiting = false;
				if (value)
				{
					inviteButton.SetActive(false);
				}
				alreadyInLabel.SetActive(value);
			}
		}
	}
}
