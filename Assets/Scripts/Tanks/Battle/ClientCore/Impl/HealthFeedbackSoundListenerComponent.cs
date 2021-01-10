using Platform.Library.ClientUnityIntegration.API;
using System;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class HealthFeedbackSoundListenerComponent : BehaviourComponent
	{
		[Serializable]
		private class HealthFeedbackListenerPreset
		{
			[SerializeField]
			private float dryLevel;
			[SerializeField]
			private float room;
			[SerializeField]
			private float roomHF;
			[SerializeField]
			private float roomLF;
			[SerializeField]
			private float decayTime;
			[SerializeField]
			private float decayHFRatio;
			[SerializeField]
			private float reflectionsLevel;
			[SerializeField]
			private float reflectionsDelay;
			[SerializeField]
			private float reverbLevel;
			[SerializeField]
			private float reverbDelay;
			[SerializeField]
			private float hfReference;
			[SerializeField]
			private float lfReference;
			[SerializeField]
			private float diffusion;
			[SerializeField]
			private float density;
		}

		[SerializeField]
		private AudioReverbFilter filter;
		[SerializeField]
		private HealthFeedbackListenerPreset normalHealthPreset;
		[SerializeField]
		private HealthFeedbackListenerPreset lowHealthPreset;
		[SerializeField]
		private float maxHealthPercentForSound;
		[SerializeField]
		private float enterTimeSec;
		[SerializeField]
		private float exitTimeSec;
		[SerializeField]
		private AnimationCurve toLowHealthStateCurve;
		[SerializeField]
		private AnimationCurve toNormalHealthStateCurve;
	}
}
