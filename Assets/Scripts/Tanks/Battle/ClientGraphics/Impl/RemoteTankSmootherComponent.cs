using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class RemoteTankSmootherComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public float smoothingCoeff = 20f;

		public Vector3 prevVisualPosition = Vector3.zero;

		public Quaternion prevVisualRotation = Quaternion.identity;
	}
}
