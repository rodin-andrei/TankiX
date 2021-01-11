using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public abstract class AbstractIsisSoundEffectComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
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

		public SoundController SoundController
		{
			get;
			set;
		}
	}
}
