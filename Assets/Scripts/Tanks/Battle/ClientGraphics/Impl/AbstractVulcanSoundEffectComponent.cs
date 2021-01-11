using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public abstract class AbstractVulcanSoundEffectComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject effectPrefab;

		[SerializeField]
		private float startTimePerSec;

		[SerializeField]
		private float delayPerSec;

		private AudioSource soundSource;

		public float DelayPerSec
		{
			get
			{
				return delayPerSec;
			}
			set
			{
				delayPerSec = value;
			}
		}

		public AudioSource SoundSource
		{
			get
			{
				return soundSource;
			}
			set
			{
				soundSource = value;
			}
		}

		public GameObject EffectPrefab
		{
			get
			{
				return effectPrefab;
			}
			set
			{
				effectPrefab = value;
			}
		}

		public float StartTimePerSec
		{
			get
			{
				return startTimePerSec;
			}
			set
			{
				startTimePerSec = value;
			}
		}
	}
}
