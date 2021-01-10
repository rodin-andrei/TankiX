using UnityEngine;
using UnityEngine.Audio;
using Tanks.Lobby.ClientGarage.Impl;

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
	}
}
