using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftAimingCameraComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Vector3 WorldInitialCameraPosition
		{
			get;
			set;
		}

		public Quaternion WorldInitialCameraRotation
		{
			get;
			set;
		}

		public float InitialFOV
		{
			get;
			set;
		}
	}
}
