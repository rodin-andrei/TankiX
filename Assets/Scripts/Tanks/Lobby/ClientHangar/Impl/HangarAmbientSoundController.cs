using Tanks.Battle.ClientGraphics.API;
using UnityEngine;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class HangarAmbientSoundController : MonoBehaviour
	{
		[SerializeField]
		private AmbientSoundFilter background;

		[SerializeField]
		private HangarHymnSoundBehaviour hymn;

		public void Play(bool playWithNitro)
		{
			background.Play();
			hymn.Play(playWithNitro);
		}

		public void Stop()
		{
			background.Stop();
			hymn.Stop();
		}

		private void Update()
		{
			if (background == null && hymn == null)
			{
				Object.DestroyObject(base.gameObject);
			}
		}
	}
}
