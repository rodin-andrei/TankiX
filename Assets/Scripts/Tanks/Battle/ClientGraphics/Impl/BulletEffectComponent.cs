using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class BulletEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject bulletPrefab;
		[SerializeField]
		private GameObject explosionPrefab;
		[SerializeField]
		private float explosionTime;
		[SerializeField]
		private float explosionOffset;
	}
}
