using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class MineExplosionGraphicsComponent : MonoBehaviour
	{
		[SerializeField]
		private GameObject effectPrefab;
		[SerializeField]
		private float explosionLifeTime;
		[SerializeField]
		private Vector3 origin;
	}
}
