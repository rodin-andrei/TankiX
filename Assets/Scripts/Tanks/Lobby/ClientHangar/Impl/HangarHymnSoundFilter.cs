using Tanks.Battle.ClientGraphics.API;
using UnityEngine;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class HangarHymnSoundFilter : SingleFadeSoundFilter
	{
		[SerializeField]
		private GameObject objectToDestroy;

		protected override float FilterVolume
		{
			get
			{
				return HangarHymnSoundBehaviour.FILTER_VOLUME;
			}
			set
			{
				HangarHymnSoundBehaviour.FILTER_VOLUME = value;
			}
		}

		protected override void StopAndDestroy()
		{
			source.Stop();
			ResetFilter();
			Object.DestroyObject(objectToDestroy);
		}

		protected override bool CheckSoundIsPlaying()
		{
			return true;
		}
	}
}
