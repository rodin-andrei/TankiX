namespace Tanks.Lobby.ClientUserProfile.API
{
	public class WaitingForInviteToSquadAnswerUIComponent : WaitingAnswerUIComponent
	{
		public bool AlreadyInSquad
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
