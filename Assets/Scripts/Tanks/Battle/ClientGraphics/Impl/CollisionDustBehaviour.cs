using System;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class CollisionDustBehaviour : MonoBehaviour
	{
		[NonSerialized]
		public MapDustComponent mapDust;

		private float delay;

		private DustEffectBehaviour effect;

		public DustEffectBehaviour Effect
		{
			get
			{
				return effect;
			}
		}

		private void Update()
		{
			delay -= Time.deltaTime;
		}

		private void OnCollisionStay(Collision collision)
		{
			effect = mapDust.GetEffectByTag(collision.transform, Vector2.zero);
			if (!(effect == null) && !(delay > 0f))
			{
				delay = 1f / effect.collisionEmissionRate.RandomValue;
				ContactPoint[] contacts = collision.contacts;
				foreach (ContactPoint contactPoint in contacts)
				{
					effect.TryEmitParticle(contactPoint.point, collision.relativeVelocity);
				}
			}
		}
	}
}
