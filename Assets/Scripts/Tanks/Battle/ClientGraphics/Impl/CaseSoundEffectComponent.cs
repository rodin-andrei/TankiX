using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public abstract class CaseSoundEffectComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject caseSoundAsset;

		public GameObject CaseSoundAsset
		{
			get
			{
				return caseSoundAsset;
			}
			set
			{
				caseSoundAsset = value;
			}
		}

		public AudioSource Source
		{
			get;
			set;
		}
	}
}
