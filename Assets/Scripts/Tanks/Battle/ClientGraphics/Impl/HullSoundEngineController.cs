using System;
using System.Linq;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class HullSoundEngineController : MonoBehaviour
	{
		private const string EMPTY_RPM_DATA_EXCEPTION = "No data for hull sound engine";

		private const float DEFAULT_ENGINE_LOAD = 0.5f;

		private const float HESITATION_LEVEL_MIN = -1f;

		private const float HESITATION_LEVEL_MAX = 1f;

		private const float EPS = 0.001f;

		[SerializeField]
		private RPMSoundBehaviour[] RPMSoundBehaviourArray;

		[SerializeField]
		private bool enableAudioSourceOptimizing = true;

		[SerializeField]
		private bool useAudioFilters = true;

		[SerializeField]
		[Range(0f, 1f)]
		private float blendRange = 0.9f;

		[SerializeField]
		private float extremalRPMStartOffset = 2f;

		[SerializeField]
		private float extremalRPMEndOffset = 100f;

		[SerializeField]
		[HideInInspector]
		private float minRPM;

		[SerializeField]
		[HideInInspector]
		private float maxRPM;

		[SerializeField]
		[HideInInspector]
		private int RPMDataArrayLength;

		[SerializeField]
		[HideInInspector]
		private int lastRPMDataIndex;

		[SerializeField]
		private float acelerationRPMFactor = 1.5f;

		[SerializeField]
		private float decelerationRPMFactor = 1.5f;

		[SerializeField]
		[Range(0f, 1f)]
		private float increasingLoadThreshold = 0.0285714287f;

		[SerializeField]
		[Range(0f, 1f)]
		private float decreasingLoadThreshold = 0.0285714287f;

		[SerializeField]
		private float increasingLoadSpeed = 0.05f;

		[SerializeField]
		private float decreasingLoadSpeed = 0.05f;

		[SerializeField]
		private float increasingRPMSpeed = 10f;

		[SerializeField]
		private float decreasingRPMSpeed = 10f;

		[SerializeField]
		private float hesitationAmplitudeRPM = 30f;

		[SerializeField]
		private float hesitationAmplitudeLoad = 0.2f;

		[SerializeField]
		private float hesitationFrequency = 1f;

		[SerializeField]
		private float hesitationShockMinInterval = 0.5f;

		[SerializeField]
		private float hesitationShockMaxInterval = 2f;

		[SerializeField]
		private float fadeInTimeSec = 2f;

		[SerializeField]
		private float fadeOutTimeSec = 2f;

		[SerializeField]
		[Range(0f, 1f)]
		private float inputRPMFactor;

		private bool selfEngine;

		private int startSoundIndex;

		private int endSoundIndex;

		private float engineLoad;

		private float previousEngineRPM;

		private float engineRPM;

		private float targetEngineRPM;

		private float engineVolume;

		private float engineVolumeSpeed;

		private float fadeInSpeed;

		private float realRPMFadeOutSpeed;

		private float destroyTimer;

		private float hesitationLevel;

		private float hesitationShockIntervalTimer;

		private float timerOfHesitationsInStableWork;

		private bool isStableWork;

		private float realRPMFactor;

		public bool SelfEngine
		{
			get
			{
				return selfEngine;
			}
		}

		private bool IsStableWork
		{
			get
			{
				return isStableWork;
			}
			set
			{
				if (isStableWork != value)
				{
					if (value)
					{
						timerOfHesitationsInStableWork = 0f;
						hesitationShockIntervalTimer = GetHesitationShockInterval();
					}
					isStableWork = value;
				}
			}
		}

		private float RealRPMFactor
		{
			get
			{
				return realRPMFactor;
			}
			set
			{
				if (realRPMFactor < inputRPMFactor)
				{
					realRPMFactor = Mathf.Min(value, inputRPMFactor);
				}
				else
				{
					realRPMFactor = Mathf.Max(value, inputRPMFactor);
				}
				targetEngineRPM = Mathf.Lerp(minRPM, maxRPM, realRPMFactor);
				if (IsStableWork)
				{
					if (hesitationShockIntervalTimer > 0f)
					{
						hesitationLevel = Mathf.Sin(hesitationFrequency * timerOfHesitationsInStableWork);
					}
					else
					{
						hesitationLevel = ((!(hesitationLevel >= 0f)) ? UnityEngine.Random.Range(0.5f, 1f) : UnityEngine.Random.Range(-1f, -0.5f));
						timerOfHesitationsInStableWork = Mathf.Asin(hesitationLevel) / hesitationFrequency;
						hesitationShockIntervalTimer = GetHesitationShockInterval();
					}
				}
				else
				{
					hesitationLevel = 0f;
				}
				float num = hesitationAmplitudeRPM * hesitationLevel;
				targetEngineRPM += num;
			}
		}

		public float InputRpmFactor
		{
			get
			{
				return inputRPMFactor;
			}
			set
			{
				inputRPMFactor = value;
			}
		}

		public float EngineRpm
		{
			get
			{
				return engineRPM;
			}
		}

		public float EngineLoad
		{
			get
			{
				return engineLoad;
			}
		}

		public bool UseAudioFilters
		{
			get
			{
				return useAudioFilters;
			}
		}

		private void Awake()
		{
			base.enabled = false;
		}

		private void Update()
		{
			float deltaTime = Time.deltaTime;
			if (!IsDestroyed(deltaTime))
			{
				IncrementEngineVolume(deltaTime);
				UpdateRealRPMFactor(deltaTime);
				UpdateEngineRPM(deltaTime);
				UpdateEngineLoad(deltaTime);
				UpdateEngineSounds();
			}
		}

		private float GetHesitationShockInterval()
		{
			return UnityEngine.Random.Range(hesitationShockMinInterval, hesitationShockMaxInterval);
		}

		private bool IsDestroyed(float dt)
		{
			if (destroyTimer > 0f)
			{
				destroyTimer -= dt;
				if (destroyTimer <= 0f)
				{
					StopEngineSounds();
					return true;
				}
			}
			return false;
		}

		private void UpdateEngineRPM(float dt)
		{
			previousEngineRPM = engineRPM;
			float num = engineRPM;
			if (targetEngineRPM - engineRPM > 0f)
			{
				num += increasingRPMSpeed * dt;
				num = Mathf.Min(num, targetEngineRPM);
			}
			else
			{
				num -= decreasingRPMSpeed * dt;
				num = Mathf.Max(num, targetEngineRPM);
			}
			engineRPM = Mathf.Clamp(num, minRPM, maxRPM);
		}

		private void UpdateRealRPMFactor(float dt)
		{
			float num = inputRPMFactor - RealRPMFactor;
			IsStableWork = MathUtil.NearlyEqual(num, 0f, 0.001f);
			if (destroyTimer > 0f)
			{
				RealRPMFactor += realRPMFadeOutSpeed * dt;
			}
			else if (IsStableWork)
			{
				RealRPMFactor = inputRPMFactor;
				timerOfHesitationsInStableWork += dt;
				hesitationShockIntervalTimer -= dt;
			}
			else
			{
				float num2 = ((!(num > 0f)) ? decelerationRPMFactor : acelerationRPMFactor);
				RealRPMFactor += num * num2 * dt;
			}
		}

		private void UpdateEngineLoad(float dt)
		{
			float num = engineLoad;
			if (!IsStableWork)
			{
				float num2 = inputRPMFactor - RealRPMFactor;
				num = num2;
				float num3 = Mathf.Abs(num);
				float num4 = Mathf.Sign(num);
				float num5 = ((!(num >= 0f)) ? decreasingLoadThreshold : increasingLoadThreshold);
				num = ((!(num3 > num5)) ? (num / num5) : num4);
				num += 1f;
				num *= 0.5f;
				num = Mathf.Clamp01(num);
			}
			else
			{
				num = 0.5f + hesitationAmplitudeLoad * hesitationLevel;
			}
			if (num != engineLoad)
			{
				float num6 = engineLoad;
				if (num - engineLoad > 0f)
				{
					num6 += increasingLoadSpeed * dt;
					num6 = Mathf.Min(num6, num);
				}
				else
				{
					num6 -= decreasingLoadSpeed * dt;
					num6 = Mathf.Max(num6, num);
				}
				engineLoad = Mathf.Clamp01(num6);
			}
		}

		private void UpdateEngineSoundsStraight()
		{
			int num = startSoundIndex;
			int rPMDataArrayLength = RPMDataArrayLength;
			int num2 = 1;
			RPMSoundBehaviour rPMSoundBehaviour;
			while (true)
			{
				if (num == rPMDataArrayLength)
				{
					return;
				}
				rPMSoundBehaviour = RPMSoundBehaviourArray[num];
				if (!IsRPMBelowEndRange(EngineRpm, rPMSoundBehaviour) && rPMSoundBehaviour.NeedToStop)
				{
					rPMSoundBehaviour.Stop();
					startSoundIndex += num2;
					num += num2;
					continue;
				}
				if (!IsRPMAboveBeginRange(EngineRpm, rPMSoundBehaviour))
				{
					break;
				}
				rPMSoundBehaviour.Play(engineVolume);
				endSoundIndex = num;
				num += num2;
			}
			rPMSoundBehaviour.Stop();
		}

		private void UpdateEngineSoundsReverse()
		{
			int num = endSoundIndex;
			int num2 = -1;
			int num3 = -1;
			RPMSoundBehaviour rPMSoundBehaviour;
			while (true)
			{
				if (num == num2)
				{
					return;
				}
				rPMSoundBehaviour = RPMSoundBehaviourArray[num];
				if (!IsRPMAboveBeginRange(EngineRpm, rPMSoundBehaviour) && rPMSoundBehaviour.NeedToStop)
				{
					rPMSoundBehaviour.Stop();
					endSoundIndex += num3;
					num += num3;
					continue;
				}
				if (!IsRPMBelowEndRange(EngineRpm, rPMSoundBehaviour))
				{
					break;
				}
				rPMSoundBehaviour.Play(engineVolume);
				startSoundIndex = num;
				num += num3;
			}
			rPMSoundBehaviour.Stop();
		}

		private void UpdateEngineSounds()
		{
			float num = EngineRpm - previousEngineRPM;
			if (enableAudioSourceOptimizing)
			{
				if (num == 0f)
				{
					UpdateCurrentEngineSoundList();
					return;
				}
				if (num > 0f)
				{
					UpdateEngineSoundsStraight();
				}
				else
				{
					UpdateEngineSoundsReverse();
				}
			}
			else
			{
				UpdateEngineSoundsVolume();
			}
			ClampEngineVolume();
		}

		private void IncrementEngineVolume(float dt)
		{
			if (engineVolumeSpeed != 0f)
			{
				engineVolume += engineVolumeSpeed * dt;
			}
		}

		private void ClampEngineVolume()
		{
			if (engineVolume > 1f)
			{
				engineVolume = 1f;
				engineVolumeSpeed = 0f;
			}
			if (engineVolume < 0f)
			{
				engineVolume = 0f;
				engineVolumeSpeed = 0f;
			}
		}

		private void UpdateCurrentEngineSoundList()
		{
			int num = startSoundIndex;
			int num2 = endSoundIndex;
			bool flag = true;
			for (int i = startSoundIndex; i <= endSoundIndex; i++)
			{
				RPMSoundBehaviour rPMSoundBehaviour = RPMSoundBehaviourArray[i];
				if (rPMSoundBehaviour.NeedToStop)
				{
					rPMSoundBehaviour.Stop();
					continue;
				}
				rPMSoundBehaviour.Play(engineVolume);
				num2 = i;
				if (flag)
				{
					flag = false;
					num = i;
				}
			}
			endSoundIndex = num2;
			startSoundIndex = num;
		}

		private void UpdateEngineSoundsVolume()
		{
			if (engineVolumeSpeed != 0f)
			{
				for (int i = startSoundIndex; i <= endSoundIndex; i++)
				{
					RPMSoundBehaviour rPMSoundBehaviour = RPMSoundBehaviourArray[i];
					rPMSoundBehaviour.Play(engineVolume);
				}
			}
		}

		private void StopEngineSounds()
		{
			for (int i = startSoundIndex; i <= endSoundIndex; i++)
			{
				RPMSoundBehaviour rPMSoundBehaviour = RPMSoundBehaviourArray[i];
				rPMSoundBehaviour.Stop();
			}
			base.enabled = false;
		}

		private void PlayAllEngineSounds()
		{
			startSoundIndex = 0;
			endSoundIndex = lastRPMDataIndex;
			for (int i = startSoundIndex; i <= endSoundIndex; i++)
			{
				RPMSoundBehaviour rPMSoundBehaviour = RPMSoundBehaviourArray[i];
				rPMSoundBehaviour.Play(engineVolume);
			}
		}

		private void PlayAppropriateEngineSounds()
		{
			bool flag = false;
			for (int i = 0; i < RPMDataArrayLength; i++)
			{
				RPMSoundBehaviour rPMSoundBehaviour = RPMSoundBehaviourArray[i];
				if (!IsRPMWithinRange(rPMSoundBehaviour, EngineRpm))
				{
					rPMSoundBehaviour.Stop();
					continue;
				}
				if (!flag)
				{
					flag = true;
					startSoundIndex = i;
				}
				rPMSoundBehaviour.Play(engineVolume);
				endSoundIndex = i;
			}
		}

		private float SortByRPMProperty(RPMSoundBehaviour currentRPMSoundBehaviour)
		{
			return currentRPMSoundBehaviour.RPM;
		}

		private bool IsRPMAboveBeginRange(float rpm, RPMSoundBehaviour rpmSoundBehaviour)
		{
			return rpm >= rpmSoundBehaviour.RangeBeginRpm;
		}

		private bool IsRPMBelowEndRange(float rpm, RPMSoundBehaviour rpmSoundBehaviour)
		{
			return rpm < rpmSoundBehaviour.RangeEndRpm;
		}

		public void Build()
		{
			RPMDataArrayLength = RPMSoundBehaviourArray.Length;
			if (RPMDataArrayLength == 0)
			{
				base.enabled = false;
				throw new Exception("No data for hull sound engine");
			}
			RPMSoundBehaviourArray = RPMSoundBehaviourArray.ToList().OrderBy(SortByRPMProperty).ToArray();
			lastRPMDataIndex = RPMDataArrayLength - 1;
			RPMSoundBehaviour rPMSoundBehaviour = RPMSoundBehaviourArray[0];
			RPMSoundBehaviour rPMSoundBehaviour2 = RPMSoundBehaviourArray[lastRPMDataIndex];
			minRPM = rPMSoundBehaviour.RPM;
			maxRPM = rPMSoundBehaviour2.RPM;
			for (int i = 0; i < RPMDataArrayLength; i++)
			{
				float prevRPM = ((i != 0) ? RPMSoundBehaviourArray[i - 1].RPM : (minRPM - (extremalRPMStartOffset + hesitationAmplitudeRPM) / blendRange));
				float nextRPM = ((i != lastRPMDataIndex) ? RPMSoundBehaviourArray[i + 1].RPM : (maxRPM + (extremalRPMEndOffset + hesitationAmplitudeRPM) / blendRange));
				RPMSoundBehaviour rPMSoundBehaviour3 = RPMSoundBehaviourArray[i];
				rPMSoundBehaviour3.Build(this, prevRPM, nextRPM, blendRange);
			}
		}

		public void Init(bool self)
		{
			RealRPMFactor = InputRpmFactor;
			fadeInSpeed = 1f / fadeInTimeSec;
			engineVolumeSpeed = 0f;
			selfEngine = self;
			base.gameObject.SetActive(true);
		}

		public void Play()
		{
			engineVolume = 0f;
			engineVolumeSpeed = fadeInSpeed;
			engineLoad = 0.5f;
			InputRpmFactor = 0f;
			RealRPMFactor = InputRpmFactor;
			engineRPM = minRPM;
			previousEngineRPM = EngineRpm;
			realRPMFadeOutSpeed = 0f;
			destroyTimer = -1f;
			if (enableAudioSourceOptimizing)
			{
				PlayAppropriateEngineSounds();
			}
			else
			{
				PlayAllEngineSounds();
			}
			base.enabled = true;
		}

		public void Stop()
		{
			engineVolumeSpeed = ((engineVolume != 0f) ? ((0f - engineVolume) / fadeOutTimeSec) : (-1f));
			realRPMFadeOutSpeed = ((RealRPMFactor != 0f) ? ((0f - RealRPMFactor) / fadeOutTimeSec) : (-1f));
			destroyTimer = fadeOutTimeSec;
		}

		public bool IsRPMWithinRange(RPMSoundBehaviour rpmSoundBehaviour, float rpm)
		{
			return IsRPMAboveBeginRange(rpm, rpmSoundBehaviour) && IsRPMBelowEndRange(rpm, rpmSoundBehaviour);
		}
	}
}
