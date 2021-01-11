using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class IsisGraphicsComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject rayPrefab;

		public GameObject RayPrefab
		{
			get
			{
				return rayPrefab;
			}
			set
			{
				rayPrefab = value;
			}
		}

		public IsisRayEffectBehaviour Ray
		{
			get;
			set;
		}
	}
}
