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
		private float explosionTime = 1f;

		[SerializeField]
		private float explosionOffset = 0.5f;

		public GameObject BulletPrefab
		{
			get
			{
				return bulletPrefab;
			}
			set
			{
				bulletPrefab = value;
			}
		}

		public GameObject ExplosionPrefab
		{
			get
			{
				return explosionPrefab;
			}
			set
			{
				explosionPrefab = value;
			}
		}

		public float ExplosionTime
		{
			get
			{
				return explosionTime;
			}
			set
			{
				explosionTime = value;
			}
		}

		public float ExplosionOffset
		{
			get
			{
				return explosionOffset;
			}
			set
			{
				explosionOffset = value;
			}
		}
	}
}
