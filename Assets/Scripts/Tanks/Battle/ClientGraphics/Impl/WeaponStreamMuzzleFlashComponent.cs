using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class WeaponStreamMuzzleFlashComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject effectPrefab;

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

		public ParticleSystem EffectInstance
		{
			get;
			set;
		}

		public Light LightInstance
		{
			get;
			set;
		}
	}
}
