using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class WeaponStreamHitSoundsEffectComponent : BaseStreamHitWeaponSoundEffect
	{
		[SerializeField]
		private AudioClip staticHitClip;
		[SerializeField]
		private AudioClip targetHitClip;
	}
}
