using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class RPMSoundBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float rpm;

		[SerializeField]
		private ActiveRPMSoundModifier activeRPMSound;

		[SerializeField]
		private NormalRPMSoundModifier normalRPMSound;

		[SerializeField]
		private float rangeBeginRPM;

		[SerializeField]
		private float rangeEndRPM;

		[SerializeField]
		private HullSoundEngineController hullSoundEngine;

		public HullSoundEngineController HullSoundEngine
		{
			get
			{
				return hullSoundEngine;
			}
		}

		public float RPM
		{
			get
			{
				return rpm;
			}
		}

		public float RangeBeginRpm
		{
			get
			{
				return rangeBeginRPM;
			}
		}

		public float RangeEndRpm
		{
			get
			{
				return rangeEndRPM;
			}
		}

		public bool NeedToStop
		{
			get
			{
				return activeRPMSound.NeedToStop && normalRPMSound.NeedToStop;
			}
		}

		public void Build(HullSoundEngineController engine, float prevRPM, float nextRPM, float blendRange)
		{
			hullSoundEngine = engine;
			rangeBeginRPM = Mathf.Lerp(rpm, prevRPM, blendRange);
			rangeEndRPM = Mathf.Lerp(rpm, nextRPM, blendRange);
			activeRPMSound.Build(this);
			normalRPMSound.Build(this);
		}

		public void Play(float volume)
		{
			activeRPMSound.Play(volume);
			normalRPMSound.Play(volume);
		}

		public void Stop()
		{
			activeRPMSound.Stop();
			normalRPMSound.Stop();
		}
	}
}
