using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class NameplatePositionComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public float sqrDistance;

		public Vector3 previousPosition;
	}
}
