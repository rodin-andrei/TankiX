using UnityEngine;
using UnityEngine.Audio;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ActiveRPMSoundModifier : AbstractRPMSoundModifier
	{
		[SerializeField]
		private AudioMixerGroup selfActiveGroup;

		[SerializeField]
		private AudioMixerGroup remoteActiveGroup;

		protected override void Awake()
		{
			base.Awake();
			base.Source.outputAudioMixerGroup = ((!base.RpmSoundBehaviour.HullSoundEngine.SelfEngine) ? remoteActiveGroup : selfActiveGroup);
		}

		public override bool CheckLoad(float smoothedLoad)
		{
			return smoothedLoad > 0f;
		}

		public override float CalculateLoadPartForModifier(float smoothedLoad)
		{
			return Mathf.Sqrt(CalculateLinearLoadModifier(smoothedLoad));
		}
	}
}
