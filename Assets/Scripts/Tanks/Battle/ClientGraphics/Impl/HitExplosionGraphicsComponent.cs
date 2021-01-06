using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class HitExplosionGraphicsComponent : MonoBehaviour
	{
		[SerializeField]
		private GameObject explosionAsset;
		[SerializeField]
		private float explosionDuration;
		[SerializeField]
		private float explosionOffset;
		[SerializeField]
		private bool useForBlockedWeapon;
	}
}
