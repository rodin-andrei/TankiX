using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftAimingCameraKickbackComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Vector3 LastPosition
		{
			get;
			set;
		}

		public Quaternion LastRotation
		{
			get;
			set;
		}

		public ShaftAimingCameraKickbackComponent(Vector3 lastPosition, Quaternion lastRotation)
		{
			LastPosition = lastPosition;
			LastRotation = lastRotation;
		}
	}
}
