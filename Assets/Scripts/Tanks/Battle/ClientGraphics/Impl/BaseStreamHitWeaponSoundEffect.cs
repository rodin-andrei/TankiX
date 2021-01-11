using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public abstract class BaseStreamHitWeaponSoundEffect : BehaviourComponent
	{
		[SerializeField]
		private GameObject effectPrefab;

		private SoundController soundController;

		public SoundController SoundController
		{
			get
			{
				return soundController;
			}
			set
			{
				soundController = value;
			}
		}

		public GameObject EffectPrefab
		{
			get
			{
				return effectPrefab;
			}
		}
	}
}
