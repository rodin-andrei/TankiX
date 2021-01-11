using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public abstract class AbstractRPMSoundUpdater : MonoBehaviour
	{
		[SerializeField]
		protected bool alive;

		[SerializeField]
		protected HullSoundEngineController engine;

		[SerializeField]
		protected AbstractRPMSoundModifier parentModifier;

		[SerializeField]
		protected RPMSoundBehaviour rpmSoundBehaviour;

		private void OnApplicationQuit()
		{
			alive = false;
		}

		protected virtual void Awake()
		{
			Stop();
			alive = true;
		}

		protected virtual void OnEnable()
		{
			parentModifier.Source.Play();
		}

		protected virtual void OnDisable()
		{
			if (alive)
			{
				parentModifier.Source.Pause();
			}
		}

		public virtual void Build(HullSoundEngineController engine, AbstractRPMSoundModifier abstractRPMSoundModifier, RPMSoundBehaviour rpmSoundBehaviour)
		{
			RPMVolumeUpdaterFinishBehaviour component = base.gameObject.GetComponent<RPMVolumeUpdaterFinishBehaviour>();
			if (component != null)
			{
				Object.DestroyImmediate(component);
			}
			this.engine = engine;
			parentModifier = abstractRPMSoundModifier;
			this.rpmSoundBehaviour = rpmSoundBehaviour;
		}

		public virtual void Play()
		{
			base.enabled = true;
		}

		public virtual void Stop()
		{
			base.enabled = false;
		}
	}
}
