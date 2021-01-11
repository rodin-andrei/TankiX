using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class WeaponStreamHitGraphicsEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private ParticleSystem hitStaticPrefab;

		[SerializeField]
		private ParticleSystem hitTargetPrefab;

		[SerializeField]
		private float hitOffset;

		public ParticleSystem HitStatic
		{
			get;
			set;
		}

		public ParticleSystem HitTarget
		{
			get;
			set;
		}

		public Light HitStaticLight
		{
			get;
			set;
		}

		public Light HitTargetLight
		{
			get;
			set;
		}

		public float HitOffset
		{
			get
			{
				return hitOffset;
			}
			set
			{
				hitOffset = value;
			}
		}

		public ParticleSystem HitStaticPrefab
		{
			get
			{
				return hitStaticPrefab;
			}
			set
			{
				hitStaticPrefab = value;
			}
		}

		public ParticleSystem HitTargetPrefab
		{
			get
			{
				return hitTargetPrefab;
			}
			set
			{
				hitTargetPrefab = value;
			}
		}

		public void Init(Transform parent)
		{
			HitStatic = Object.Instantiate(HitStaticPrefab);
			HitTarget = Object.Instantiate(HitTargetPrefab);
			HitStaticLight = HitStatic.GetComponent<Light>();
			HitTargetLight = HitTarget.GetComponent<Light>();
			HitStatic.transform.parent = parent;
			HitTarget.transform.parent = parent;
			HitStatic.Stop(true);
			HitTarget.Stop(true);
			HitStaticLight.enabled = false;
			HitTargetLight.enabled = false;
		}
	}
}
