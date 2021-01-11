using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class HitExplosionGraphicsComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject explosionAsset;

		[SerializeField]
		private float explosionDuration;

		[SerializeField]
		private float explosionOffset;

		[SerializeField]
		private bool useForBlockedWeapon = true;

		public bool UseForBlockedWeapon
		{
			get
			{
				return useForBlockedWeapon;
			}
			set
			{
				useForBlockedWeapon = value;
			}
		}

		public GameObject ExplosionAsset
		{
			get
			{
				return explosionAsset;
			}
			set
			{
				explosionAsset = value;
			}
		}

		public float ExplosionDuration
		{
			get
			{
				return explosionDuration;
			}
			set
			{
				explosionDuration = value;
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
