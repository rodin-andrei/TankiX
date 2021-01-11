using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class WeaponStreamHitSoundsEffectComponent : BaseStreamHitWeaponSoundEffect
	{
		[SerializeField]
		private AudioClip staticHitClip;

		[SerializeField]
		private AudioClip targetHitClip;

		private bool isStaticHit;

		public bool IsStaticHit
		{
			get
			{
				return isStaticHit;
			}
			set
			{
				isStaticHit = value;
			}
		}

		public AudioClip StaticHitClip
		{
			get
			{
				return staticHitClip;
			}
			set
			{
				staticHitClip = value;
			}
		}

		public AudioClip TargetHitClip
		{
			get
			{
				return targetHitClip;
			}
			set
			{
				targetHitClip = value;
			}
		}
	}
}
