using UnityEngine.EventSystems;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class InviteToSquadDialogComponent : UIBehaviour
	{
		public long FromUserId;
		public long SquadId;
		public long EngineId;
		public bool invite;
		[SerializeField]
		private LocalizedField inviteMessageLocalizedField;
		[SerializeField]
		private LocalizedField requestMessageLocalizedField;
	}
}
