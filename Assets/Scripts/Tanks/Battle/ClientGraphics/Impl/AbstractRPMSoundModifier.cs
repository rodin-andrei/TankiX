using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class AbstractRPMSoundModifier : MonoBehaviour
	{
		[SerializeField]
		private AudioSource source;
		[SerializeField]
		private RPMSoundBehaviour rpmSoundBehaviour;
		[SerializeField]
		private AbstractRPMSoundUpdater childUpdater;
		[SerializeField]
		private float targetRPM;
		[SerializeField]
		private bool needToStop;
		[SerializeField]
		private float rpmSoundVolume;
	}
}
