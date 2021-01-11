using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[SerialVersionUID(635824352002755226L)]
	public class WeaponRotationSoundComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject asset;

		public GameObject Asset
		{
			get
			{
				return asset;
			}
			set
			{
				asset = value;
			}
		}

		public AudioSource StartAudioSource
		{
			get;
			set;
		}

		public AudioSource LoopAudioSource
		{
			get;
			set;
		}

		public AudioSource StopAudioSource
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}
	}
}
