using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class MinePlacingTransformComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public RaycastHit PlacingData
		{
			get;
			set;
		}

		public bool HasPlacingTransform
		{
			get;
			set;
		}
	}
}
