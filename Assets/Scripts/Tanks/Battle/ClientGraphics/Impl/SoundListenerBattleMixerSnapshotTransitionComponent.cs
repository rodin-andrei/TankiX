using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class SoundListenerBattleMixerSnapshotTransitionComponent : BehaviourComponent
	{
		[SerializeField]
		private float transitionTimeToSilentAfterRoundFinish;
		[SerializeField]
		private float transitionTimeToSilentAfterExitBattle;
		[SerializeField]
		private float transitionTimeToMelodySilent;
		[SerializeField]
		private float transitionToLoudTimeInBattle;
		[SerializeField]
		private float transitionToLoudTimeInSelfUserMode;
	}
}
