using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class IceTrapExplosionSoundComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject explosionSoundAsset;

		[SerializeField]
		private float lifetime = 7f;

		public float Lifetime
		{
			get
			{
				return lifetime;
			}
		}

		public GameObject ExplosionSoundAsset
		{
			get
			{
				return explosionSoundAsset;
			}
		}
	}
}
