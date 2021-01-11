using UnityEngine;
using UnityEngine.Audio;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class MagazineShotEffectAudioGroupBehaviour : MonoBehaviour
	{
		[SerializeField]
		private AudioMixerGroup selfShotGroup;

		[SerializeField]
		private AudioMixerGroup remoteShotGroup;

		public AudioMixerGroup SelfShotGroup
		{
			get
			{
				return selfShotGroup;
			}
		}

		public AudioMixerGroup RemoteShotGroup
		{
			get
			{
				return remoteShotGroup;
			}
		}
	}
}
