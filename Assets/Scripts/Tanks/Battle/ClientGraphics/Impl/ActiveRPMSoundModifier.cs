using UnityEngine.Audio;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ActiveRPMSoundModifier : AbstractRPMSoundModifier
	{
		[SerializeField]
		private AudioMixerGroup selfActiveGroup;
		[SerializeField]
		private AudioMixerGroup remoteActiveGroup;
	}
}
