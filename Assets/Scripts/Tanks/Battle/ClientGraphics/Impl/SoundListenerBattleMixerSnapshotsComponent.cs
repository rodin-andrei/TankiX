using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class SoundListenerBattleMixerSnapshotsComponent : BehaviourComponent
	{
		[SerializeField]
		private int loudSnapshotIndex;

		[SerializeField]
		private int silentSnapshotIndex = 1;

		[SerializeField]
		private int selfUserSnapshotIndex = 2;

		[SerializeField]
		private int melodySilentSnapshotIndex = 3;

		public int LoudSnapshotIndex
		{
			get
			{
				return loudSnapshotIndex;
			}
		}

		public int SilentSnapshotIndex
		{
			get
			{
				return silentSnapshotIndex;
			}
		}

		public int SelfUserSnapshotIndex
		{
			get
			{
				return selfUserSnapshotIndex;
			}
		}

		public int MelodySilentSnapshotIndex
		{
			get
			{
				return melodySilentSnapshotIndex;
			}
		}
	}
}
