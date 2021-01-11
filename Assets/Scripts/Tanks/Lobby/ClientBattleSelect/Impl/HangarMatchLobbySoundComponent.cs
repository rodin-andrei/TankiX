using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class HangarMatchLobbySoundComponent : BehaviourComponent
	{
		[SerializeField]
		private AudioSource[] sources;

		private AudioSource lastSource;

		public void Play()
		{
			if (lastSource != null)
			{
				lastSource.Stop();
			}
			int num = Random.Range(0, sources.Length);
			lastSource = sources[num];
			lastSource.Play();
		}
	}
}
