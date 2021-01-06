using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class SoundListenerBattleMixerSnapshotsComponent : BehaviourComponent
	{
		[SerializeField]
		private int loudSnapshotIndex;
		[SerializeField]
		private int silentSnapshotIndex;
		[SerializeField]
		private int selfUserSnapshotIndex;
		[SerializeField]
		private int melodySilentSnapshotIndex;
	}
}
