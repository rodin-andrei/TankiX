using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class DoubleDamageSoundEffectComponent : BaseEffectSoundComponent<SoundController>
	{
		[SerializeField]
		private float startSoundDelaySec;

		[SerializeField]
		private float stopSoundDelaySec;

		[SerializeField]
		private float startSoundOffsetSec;

		[SerializeField]
		private float stopSoundOffsetSec;

		public float StartSoundDelaySec
		{
			get
			{
				return startSoundDelaySec;
			}
			set
			{
				startSoundDelaySec = value;
			}
		}

		public float StopSoundDelaySec
		{
			get
			{
				return stopSoundDelaySec;
			}
			set
			{
				stopSoundDelaySec = value;
			}
		}

		public float StartSoundOffsetSec
		{
			get
			{
				return startSoundOffsetSec;
			}
			set
			{
				startSoundOffsetSec = value;
			}
		}

		public float StopSoundOffsetSec
		{
			get
			{
				return stopSoundOffsetSec;
			}
			set
			{
				stopSoundOffsetSec = value;
			}
		}

		public override void BeginEffect()
		{
			base.StopSound.StopImmediately();
			base.StartSound.SetSoundActive();
		}

		public override void StopEffect()
		{
			base.StartSound.StopImmediately();
			base.StopSound.SetSoundActive();
		}

		public void RecalculatePlayingParameters()
		{
			SoundController startSound = base.StartSound;
			SoundController stopSound = base.StopSound;
			startSound.PlayingDelaySec = StartSoundDelaySec;
			stopSound.PlayingDelaySec = StopSoundDelaySec;
			startSound.PlayingOffsetSec = StartSoundOffsetSec;
			stopSound.PlayingOffsetSec = StopSoundOffsetSec;
		}
	}
}
