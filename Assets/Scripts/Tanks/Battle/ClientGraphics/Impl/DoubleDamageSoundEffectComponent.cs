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
	}
}
