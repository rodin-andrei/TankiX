using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientSettings.API
{
	public class SoundListenerComponent : BehaviourComponent
	{
		[SerializeField]
		private float delayForLobbyState = 0.33f;

		[SerializeField]
		private float delayForBattleEnterState = 0.05f;

		[SerializeField]
		private float delayForBattleState = 1.5f;

		public float DelayForLobbyState
		{
			get
			{
				return delayForLobbyState;
			}
		}

		public float DelayForBattleEnterState
		{
			get
			{
				return delayForBattleEnterState;
			}
		}

		public float DelayForBattleState
		{
			get
			{
				return delayForBattleState;
			}
		}

		private void Awake()
		{
			AudioListener.pause = false;
		}

		private void OnDestroy()
		{
			AudioListener.pause = true;
		}

		private void OnApplicationQuit()
		{
			AudioListener.pause = true;
		}
	}
}
