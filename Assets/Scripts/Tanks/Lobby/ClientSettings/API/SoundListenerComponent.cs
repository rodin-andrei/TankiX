using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientSettings.API
{
	public class SoundListenerComponent : BehaviourComponent
	{
		[SerializeField]
		private float delayForLobbyState;
		[SerializeField]
		private float delayForBattleEnterState;
		[SerializeField]
		private float delayForBattleState;
	}
}
