using Tanks.Lobby.ClientGarage.Impl;
using UnityEngine;
using UnityEngine.Audio;

namespace Tanks.Lobby.ClientSettings.API
{
	public class SoundListenerResourcesBehaviour : MonoBehaviour
	{
		[SerializeField]
		private AudioMixer sfxMixer;

		[SerializeField]
		private AudioMixer musicMixer;

		[SerializeField]
		private AudioMixer uiMixer;

		[SerializeField]
		private AudioMixerSnapshot[] sfxMixerSnapshots;

		[SerializeField]
		private AudioMixerSnapshot[] musicMixerSnapshots;

		[SerializeField]
		private AudioSource sfxSourcePreview;

		[SerializeField]
		private GameObject moduleActivation;

		[SerializeField]
		private GameObject moduleUpgrade;

		[SerializeField]
		private DailyBonusSoundsBehaviour dailyBonusSounds;

		public AudioMixer SfxMixer
		{
			get
			{
				return sfxMixer;
			}
		}

		public AudioMixer MusicMixer
		{
			get
			{
				return musicMixer;
			}
		}

		public AudioMixer UIMixer
		{
			get
			{
				return uiMixer;
			}
		}

		public AudioMixerSnapshot[] SfxMixerSnapshots
		{
			get
			{
				return sfxMixerSnapshots;
			}
		}

		public AudioSource SfxSourcePreview
		{
			get
			{
				return sfxSourcePreview;
			}
		}

		public AudioMixerSnapshot[] MusicMixerSnapshots
		{
			get
			{
				return musicMixerSnapshots;
			}
		}

		public GameObject ModuleActivation
		{
			get
			{
				return moduleActivation;
			}
		}

		public GameObject ModuleUpgrade
		{
			get
			{
				return moduleUpgrade;
			}
		}

		public DailyBonusSoundsBehaviour DailyBonusSounds
		{
			get
			{
				return dailyBonusSounds;
			}
		}
	}
}
