using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class HitExplosionSoundComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject soundPrefab;

		[SerializeField]
		private float duration = 2f;

		public float Duration
		{
			get
			{
				return duration;
			}
			set
			{
				duration = value;
			}
		}

		public GameObject SoundPrefab
		{
			get
			{
				return soundPrefab;
			}
			set
			{
				soundPrefab = value;
			}
		}
	}
}
