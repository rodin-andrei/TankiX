using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientSettings.API;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientProfile.Impl
{
	public class VolumeChangedNotifierComponent : BehaviourComponent, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
	{
		[SerializeField]
		private Slider slider;

		[SerializeField]
		private AudioSource audioSource;

		public Slider Slider
		{
			get
			{
				return slider;
			}
			set
			{
				slider = value;
			}
		}

		public AudioSource AudioSource
		{
			get
			{
				return audioSource;
			}
			set
			{
				audioSource = value;
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (!slider.minValue.Equals(slider.value))
			{
				audioSource.outputAudioMixerGroup.audioMixer.SetFloat(SoundSettingsUtils.VOLUME_PARAM_KEY, slider.value);
				audioSource.Play();
			}
		}
	}
}
