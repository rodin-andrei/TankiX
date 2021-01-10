using UnityEngine.EventSystems;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class InviteToLobbyDialogComponent : UIBehaviour
	{
		public long lobbyId;
		public long engineId;
		public LocalizedField messageForSingleUser;
		public LocalizedField messageForSquadLeader;
		public LocalizedField messageForSquadMember;
	}
}
