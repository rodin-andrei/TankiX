using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class HUDWorldSpaceCanvas : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Canvas canvas;

		public GameObject nameplatePrefab;

		public Vector3 offset;

		[SerializeField]
		private GameObject damageInfoPrefab;

		public GameObject DamageInfoPrefab
		{
			get
			{
				return damageInfoPrefab;
			}
		}
	}
}
