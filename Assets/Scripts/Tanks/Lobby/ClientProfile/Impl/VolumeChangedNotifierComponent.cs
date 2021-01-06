using Platform.Library.ClientUnityIntegration.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientProfile.Impl
{
	public class VolumeChangedNotifierComponent : BehaviourComponent
	{
		[SerializeField]
		private Slider slider;
		[SerializeField]
		private AudioSource audioSource;
	}
}
