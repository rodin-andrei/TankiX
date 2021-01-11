using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class SoundListenerBattleMixerSnapshotTransitionComponent : BehaviourComponent
	{
		[SerializeField]
		private float transitionTimeToSilentAfterRoundFinish = 0.25f;

		[SerializeField]
		private float transitionTimeToSilentAfterExitBattle = 0.5f;

		[SerializeField]
		private float transitionTimeToMelodySilent = 0.5f;

		[SerializeField]
		private float transitionToLoudTimeInBattle = 0.5f;

		[SerializeField]
		private float transitionToLoudTimeInSelfUserMode = 0.5f;

		public float TransitionTimeToSilentAfterRoundFinish
		{
			get
			{
				return transitionTimeToSilentAfterRoundFinish;
			}
		}

		public float TransitionTimeToSilentAfterExitBattle
		{
			get
			{
				return transitionTimeToSilentAfterExitBattle;
			}
		}

		public float TransitionToLoudTimeInBattle
		{
			get
			{
				return transitionToLoudTimeInBattle;
			}
		}

		public float TransitionToLoudTimeInSelfUserMode
		{
			get
			{
				return transitionToLoudTimeInSelfUserMode;
			}
		}

		public float TransitionTimeToMelodySilent
		{
			get
			{
				return transitionTimeToMelodySilent;
			}
		}
	}
}
