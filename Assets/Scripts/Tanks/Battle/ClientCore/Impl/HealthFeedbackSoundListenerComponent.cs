using System;
using Platform.Library.ClientUnityIntegration.API;
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

			public float DryLevel
			{
				get
				{
					return dryLevel;
				}
			}

			public float Room
			{
				get
				{
					return room;
				}
			}

			public float RoomHf
			{
				get
				{
					return roomHF;
				}
			}

			public float DecayTime
			{
				get
				{
					return decayTime;
				}
			}

			public float DecayHfRatio
			{
				get
				{
					return decayHFRatio;
				}
			}

			public float RoomLf
			{
				get
				{
					return roomLF;
				}
			}

			public float ReflectionsLevel
			{
				get
				{
					return reflectionsLevel;
				}
			}

			public float ReflectionsDelay
			{
				get
				{
					return reflectionsDelay;
				}
			}

			public float ReverbLevel
			{
				get
				{
					return reverbLevel;
				}
			}

			public float ReverbDelay
			{
				get
				{
					return reverbDelay;
				}
			}

			public float HfReference
			{
				get
				{
					return hfReference;
				}
			}

			public float LfReference
			{
				get
				{
					return lfReference;
				}
			}

			public float Diffusion
			{
				get
				{
					return diffusion;
				}
			}

			public float Density
			{
				get
				{
					return density;
				}
			}
		}

		[SerializeField]
		private AudioReverbFilter filter;

		[SerializeField]
		private HealthFeedbackListenerPreset normalHealthPreset;

		[SerializeField]
		private HealthFeedbackListenerPreset lowHealthPreset;

		[SerializeField]
		private float maxHealthPercentForSound = 0.3f;

		[SerializeField]
		private float enterTimeSec = 0.5f;

		[SerializeField]
		private float exitTimeSec = 0.5f;

		[SerializeField]
		private AnimationCurve toLowHealthStateCurve;

		[SerializeField]
		private AnimationCurve toNormalHealthStateCurve;

		private float presetInterpolator;

		private float speed;

		private AnimationCurve curve;

		public float MaxHealthPercentForSound
		{
			get
			{
				return maxHealthPercentForSound;
			}
		}

		private void OnEnable()
		{
			filter.enabled = true;
		}

		private void OnDisable()
		{
			presetInterpolator = 0f;
			if ((bool)filter)
			{
				filter.enabled = false;
			}
		}

		private void ApplyPresetInterpolator()
		{
			presetInterpolator = Mathf.Clamp01(presetInterpolator);
			float t = curve.Evaluate(presetInterpolator);
			filter.dryLevel = Mathf.Lerp(normalHealthPreset.DryLevel, lowHealthPreset.DryLevel, t);
			filter.room = Mathf.Lerp(normalHealthPreset.Room, lowHealthPreset.Room, t);
			filter.roomHF = Mathf.Lerp(normalHealthPreset.RoomHf, lowHealthPreset.RoomHf, t);
			filter.roomLF = Mathf.Lerp(normalHealthPreset.RoomLf, lowHealthPreset.RoomLf, t);
			filter.decayTime = Mathf.Lerp(normalHealthPreset.DecayTime, lowHealthPreset.DecayTime, t);
			filter.decayHFRatio = Mathf.Lerp(normalHealthPreset.DecayHfRatio, lowHealthPreset.DecayHfRatio, t);
			filter.reflectionsLevel = Mathf.Lerp(normalHealthPreset.ReflectionsLevel, lowHealthPreset.ReflectionsLevel, t);
			filter.reflectionsDelay = Mathf.Lerp(normalHealthPreset.ReflectionsDelay, lowHealthPreset.ReflectionsDelay, t);
			filter.reverbLevel = Mathf.Lerp(normalHealthPreset.ReverbLevel, lowHealthPreset.ReverbLevel, t);
			filter.reverbDelay = Mathf.Lerp(normalHealthPreset.ReverbDelay, lowHealthPreset.ReverbDelay, t);
			filter.hfReference = Mathf.Lerp(normalHealthPreset.HfReference, lowHealthPreset.HfReference, t);
			filter.lfReference = Mathf.Lerp(normalHealthPreset.LfReference, lowHealthPreset.LfReference, t);
			filter.diffusion = Mathf.Lerp(normalHealthPreset.Diffusion, lowHealthPreset.Diffusion, t);
			filter.density = Mathf.Lerp(normalHealthPreset.Density, lowHealthPreset.Density, t);
		}

		public void SwitchToLowHealthMode()
		{
			StartRunning(1f / enterTimeSec, toLowHealthStateCurve);
		}

		public void SwitchToNormalHealthMode()
		{
			StartRunning(-1f / exitTimeSec, toNormalHealthStateCurve);
		}

		public void ResetHealthFeedbackData()
		{
			base.enabled = false;
			speed = 0f;
			presetInterpolator = 0f;
		}

		private void StartRunning(float speed, AnimationCurve curve)
		{
			this.speed = speed;
			this.curve = curve;
			ApplyPresetInterpolator();
			base.enabled = true;
		}

		private void Update()
		{
			bool flag = presetInterpolator >= 1f;
			presetInterpolator += speed * Time.deltaTime;
			bool flag2 = presetInterpolator >= 1f;
			if (presetInterpolator <= 0f)
			{
				base.enabled = false;
			}
			else if (!flag || !flag2)
			{
				ApplyPresetInterpolator();
			}
		}
	}
}
