using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class HullSoundEngineController : MonoBehaviour
	{
		[SerializeField]
		private RPMSoundBehaviour[] RPMSoundBehaviourArray;
		[SerializeField]
		private bool enableAudioSourceOptimizing;
		[SerializeField]
		private bool useAudioFilters;
		[SerializeField]
		private float blendRange;
		[SerializeField]
		private float extremalRPMStartOffset;
		[SerializeField]
		private float extremalRPMEndOffset;
		[SerializeField]
		private float minRPM;
		[SerializeField]
		private float maxRPM;
		[SerializeField]
		private int RPMDataArrayLength;
		[SerializeField]
		private int lastRPMDataIndex;
		[SerializeField]
		private float acelerationRPMFactor;
		[SerializeField]
		private float decelerationRPMFactor;
		[SerializeField]
		private float increasingLoadThreshold;
		[SerializeField]
		private float decreasingLoadThreshold;
		[SerializeField]
		private float increasingLoadSpeed;
		[SerializeField]
		private float decreasingLoadSpeed;
		[SerializeField]
		private float increasingRPMSpeed;
		[SerializeField]
		private float decreasingRPMSpeed;
		[SerializeField]
		private float hesitationAmplitudeRPM;
		[SerializeField]
		private float hesitationAmplitudeLoad;
		[SerializeField]
		private float hesitationFrequency;
		[SerializeField]
		private float hesitationShockMinInterval;
		[SerializeField]
		private float hesitationShockMaxInterval;
		[SerializeField]
		private float fadeInTimeSec;
		[SerializeField]
		private float fadeOutTimeSec;
		[SerializeField]
		private float inputRPMFactor;
	}
}
