using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics
{
	public class TankDeathExplosionPrefabsComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject soundPrefab;

		[SerializeField]
		private ParticleSystem explosionPrefab;

		[SerializeField]
		private ParticleSystem firePrefab;

		public GameObject SoundPrefab
		{
			get
			{
				return soundPrefab;
			}
		}

		public ParticleSystem ExplosionPrefab
		{
			get
			{
				return explosionPrefab;
			}
		}

		public ParticleSystem FirePrefab
		{
			get
			{
				return firePrefab;
			}
		}
	}
}
