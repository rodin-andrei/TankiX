using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class MouseOrbitCameraComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public float distance = MouseOrbitCameraConstants.DEFAULT_MOUSE_ORBIT_DISTANCE;

		public Quaternion targetRotation
		{
			get;
			set;
		}
	}
}
