using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class BattleScreenCoverComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Animator battleCoverAnimator;
	}
}
