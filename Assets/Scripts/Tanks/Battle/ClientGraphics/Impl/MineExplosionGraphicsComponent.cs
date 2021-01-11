using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class MineExplosionGraphicsComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject effectPrefab;

		[SerializeField]
		private float explosionLifeTime = 2f;

		[SerializeField]
		private Vector3 origin = Vector3.up;

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

		public float ExplosionLifeTime
		{
			get
			{
				return explosionLifeTime;
			}
		}

		public Vector3 Origin
		{
			get
			{
				return origin;
			}
		}
	}
}
