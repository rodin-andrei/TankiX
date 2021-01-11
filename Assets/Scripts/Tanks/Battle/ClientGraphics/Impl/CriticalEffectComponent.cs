using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class CriticalEffectComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject effectAsset;

		public GameObject EffectAsset
		{
			get
			{
				return effectAsset;
			}
			set
			{
				effectAsset = value;
			}
		}
	}
}
