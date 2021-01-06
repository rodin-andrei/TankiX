using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TankFrictionSoundEffectComponent : MonoBehaviour
	{
		[SerializeField]
		private float minValuableFrictionPower;
		[SerializeField]
		private float maxValuableFrictionPower;
		[SerializeField]
		private SoundController metallFrictionSourcePrefab;
		[SerializeField]
		private SoundController stoneFrictionSourcePrefab;
		[SerializeField]
		private SoundController frictionContactSourcePrefab;
	}
}
