using UnityEngine;

namespace Tanks.Battle.ClientGraphics
{
	public class TankDeathExplosionPrefabsComponent : MonoBehaviour
	{
		[SerializeField]
		private GameObject soundPrefab;
		[SerializeField]
		private ParticleSystem explosionPrefab;
		[SerializeField]
		private ParticleSystem firePrefab;
	}
}
