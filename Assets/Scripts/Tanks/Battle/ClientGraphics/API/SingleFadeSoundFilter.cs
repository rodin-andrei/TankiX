using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public abstract class SingleFadeSoundFilter : FadeSoundFilter
	{
		protected const float TIMEOUT_SEC = 0.3f;

		protected override void StopAndDestroy()
		{
			source.Stop();
			Object.DestroyObject(base.gameObject, 0.3f);
			ResetFilter();
		}

		protected override bool CheckSoundIsPlaying()
		{
			return source.isPlaying;
		}
	}
}
