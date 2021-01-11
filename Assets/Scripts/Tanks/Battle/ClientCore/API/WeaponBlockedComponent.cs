using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class WeaponBlockedComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Vector3 BlockPoint
		{
			get;
			set;
		}

		public Vector3 BlockNormal
		{
			get;
			set;
		}

		public GameObject BlockGameObject
		{
			get;
			set;
		}
	}
}
