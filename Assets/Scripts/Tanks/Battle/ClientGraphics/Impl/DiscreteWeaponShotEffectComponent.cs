using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class DiscreteWeaponShotEffectComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject asset;

		public GameObject Asset
		{
			get
			{
				return asset;
			}
			set
			{
				asset = value;
			}
		}

		public AudioSource[] AudioSources
		{
			get;
			set;
		}
	}
}
