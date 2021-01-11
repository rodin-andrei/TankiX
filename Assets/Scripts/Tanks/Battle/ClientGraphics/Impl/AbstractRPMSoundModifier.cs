using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public abstract class AbstractRPMSoundModifier : MonoBehaviour
	{
		private const float SELF_LOAD_MODIFIER_COEFF_B = 0f;

		private const float REMOTE_LOAD_MODIFIER_COEFF_B = 0.98f;

		private const float SELF_LOAD_MODIFIER_COEFF_K = 1f;

		private const float REMOTE_LOAD_MODIFIER_COEFF_K = 2f;

		private const int SELF_SOUND_PRIORITY = 128;

		private const int REMOTE_SOUND_PRIORITY = 128;

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

		private float loadModifierB;

		private float loadModifierK;

		public AudioSource Source
		{
			get
			{
				return source;
			}
		}

		public float RpmSoundVolume
		{
			get
			{
				return Mathf.Min(rpmSoundVolume, 1f);
			}
		}

		public bool NeedToStop
		{
			get
			{
				return needToStop;
			}
			set
			{
				needToStop = value;
			}
		}

		public RPMSoundBehaviour RpmSoundBehaviour
		{
			get
			{
				return rpmSoundBehaviour;
			}
		}

		protected virtual void Awake()
		{
			source.Stop();
			needToStop = false;
			rpmSoundVolume = 1f;
			if (rpmSoundBehaviour.HullSoundEngine.SelfEngine)
			{
				loadModifierK = 1f;
				loadModifierB = 0f;
				source.priority = 128;
			}
			else
			{
				loadModifierK = 2f;
				loadModifierB = 0.98f;
				source.priority = 128;
			}
		}

		private float CalculateRPMRangeFactor(float currentRPM)
		{
			float rangeBeginRpm = rpmSoundBehaviour.RangeBeginRpm;
			float rangeEndRpm = rpmSoundBehaviour.RangeEndRpm;
			return (currentRPM - rangeBeginRpm) / (rangeEndRpm - rangeBeginRpm);
		}

		private void InitChildUpdater<TAdd, TRemove>() where TAdd : AbstractRPMSoundUpdater where TRemove : AbstractRPMSoundUpdater
		{
			TRemove component = base.gameObject.GetComponent<TRemove>();
			if ((Object)component != (Object)null)
			{
				Object.DestroyImmediate(component);
			}
			childUpdater = base.gameObject.GetComponent<TAdd>();
			if (childUpdater == null)
			{
				childUpdater = base.gameObject.AddComponent<TAdd>();
			}
		}

		public float CalculateModifier(float smoothedRPM, float smoothedLoad)
		{
			bool flag = smoothedRPM >= targetRPM;
			float num = CalculateRPMRangeFactor(smoothedRPM);
			float num2 = CalculateLoadPartForModifier(smoothedLoad);
			float num3 = ((!flag) ? Mathf.Sqrt(num) : Mathf.Sqrt(1f - num));
			return num3 * num2;
		}

		public void Build(RPMSoundBehaviour rpmSoundBehaviour)
		{
			this.rpmSoundBehaviour = rpmSoundBehaviour;
			targetRPM = rpmSoundBehaviour.RPM;
			HullSoundEngineController hullSoundEngine = rpmSoundBehaviour.HullSoundEngine;
			if (hullSoundEngine.UseAudioFilters)
			{
				InitChildUpdater<RPMAudioFilter, RPMVolumeUpdater>();
			}
			else
			{
				InitChildUpdater<RPMVolumeUpdater, RPMAudioFilter>();
			}
			childUpdater.Build(hullSoundEngine, this, rpmSoundBehaviour);
		}

		public void Play(float volume)
		{
			rpmSoundVolume = volume;
			needToStop = false;
			childUpdater.Play();
		}

		public void Stop()
		{
			needToStop = false;
			childUpdater.Stop();
		}

		protected float CalculateLinearLoadModifier(float smoothedLoad)
		{
			return Mathf.Sqrt(Mathf.Clamp01(Mathf.SmoothStep(0f - loadModifierB, loadModifierK - loadModifierB, smoothedLoad)));
		}

		public abstract bool CheckLoad(float smoothedLoad);

		public abstract float CalculateLoadPartForModifier(float smoothedLoad);
	}
}
