namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class TeamListUserData
	{
		public TeamListUserData(string userId)
		{
		}

		public long userEntityId;
		public string userUid;
		public string hullName;
		public string hullIconId;
		public string turretName;
		public string turretIconId;
		public bool ready;
	}
}
