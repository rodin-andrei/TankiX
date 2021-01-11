using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class RPMVolumeUpdater : AbstractRPMSoundUpdater
	{
		[SerializeField]
		private RPMVolumeUpdaterFinishBehaviour rpmVolumeUpdaterFinishBehaviour;

		private void UpdateVolume()
		{
			AudioSource source = parentModifier.Source;
			float engineRpm = engine.EngineRpm;
			float engineLoad = engine.EngineLoad;
			float rpmSoundVolume = parentModifier.RpmSoundVolume;
			if (!engine.IsRPMWithinRange(rpmSoundBehaviour, engine.EngineRpm))
			{
				source.volume = 0f;
				parentModifier.NeedToStop = true;
			}
			else if (!parentModifier.CheckLoad(engine.EngineLoad))
			{
				source.volume = 0f;
			}
			else
			{
				float num2 = (source.volume = rpmSoundVolume * parentModifier.CalculateModifier(engineRpm, engineLoad));
			}
		}

		private void Update()
		{
			UpdateVolume();
		}

		public override void Build(HullSoundEngineController engine, AbstractRPMSoundModifier abstractRPMSoundModifier, RPMSoundBehaviour rpmSoundBehaviour)
		{
			base.Build(engine, abstractRPMSoundModifier, rpmSoundBehaviour);
			rpmVolumeUpdaterFinishBehaviour = base.gameObject.AddComponent<RPMVolumeUpdaterFinishBehaviour>();
			rpmVolumeUpdaterFinishBehaviour.Build(parentModifier.Source);
		}

		protected override void OnEnable()
		{
			UpdateVolume();
			rpmVolumeUpdaterFinishBehaviour.enabled = false;
			AudioSource source = parentModifier.Source;
			if (!source.isPlaying)
			{
				source.Play();
			}
		}

		protected override void OnDisable()
		{
			if (alive)
			{
				rpmVolumeUpdaterFinishBehaviour.enabled = true;
			}
		}
	}
}
