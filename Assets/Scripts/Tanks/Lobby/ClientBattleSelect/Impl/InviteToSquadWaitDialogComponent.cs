using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	[RequireComponent(typeof(WaitDialogComponent))]
	public class InviteToSquadWaitDialogComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
	}
}
