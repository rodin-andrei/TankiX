using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class InitMinePlacingTransformEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event {
		public InitMinePlacingTransformEvent(Vector3 position)
		{
		}

	}
}
