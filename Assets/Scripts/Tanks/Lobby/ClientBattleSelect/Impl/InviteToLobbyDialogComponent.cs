using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	[RequireComponent(typeof(InviteDialogComponent))]
	public class InviteToLobbyDialogComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public long lobbyId;

		public long engineId;

		public LocalizedField messageForSingleUser;

		public LocalizedField messageForSquadLeader;

		public LocalizedField messageForSquadMember;
	}
}
