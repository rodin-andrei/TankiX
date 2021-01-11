using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class RailgunTrailComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject prefab;

		[SerializeField]
		private GameObject tipPrefab;

		public GameObject Prefab
		{
			get
			{
				return prefab;
			}
		}

		public GameObject TipPrefab
		{
			get
			{
				return tipPrefab;
			}
		}
	}
}
